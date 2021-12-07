using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using ReQuests.Data;
using ReQuests.Domain.Dtos.Token;
using ReQuests.Domain.Models;
using System.Security.Cryptography;

namespace ReQuests.Api.Services;

public interface IAuthService
{
	Task<GetTokenDto> LogInAsync( string username, string password );
	bool CheckPassword( string password, string hashString );
	string HashNewPassword( string password );
	Task<TokenModel?> GetTokenWithDataAsync( string accessToken );
}

public class AuthService : IAuthService
{
	private readonly AppDbContext _dbContext;
	private readonly ISystemClock _clock;

	public AuthService( AppDbContext dbContext, ISystemClock clock )
	{
		_dbContext = dbContext;
		_clock = clock;
	}

	const int tokenValidityMinutes = 1440;
	public async Task<GetTokenDto> LogInAsync( string username, string password )
	{
		UserModel? user;
		if ( username.Contains( '@' ) )
		{
			user = await _dbContext.Users
				.Where( u => u.Email == username )
				.FirstOrDefaultAsync();
		}
		else
		{
			user = await _dbContext.Users
				.Where( u => u.Username == username )
				.FirstOrDefaultAsync();
		}

		if ( user is null )
		{
			throw new NotFoundException();
		}

		var passwordValid = CheckPassword( password, user.PasswordHash );
		if ( !passwordValid )
		{
			throw new AuthorizationException();
		}

		var (access, refresh) = await GenerateTokensAsync();
		TokenModel token = new( user.Uuid, access, refresh )
		{
			ValidUntil = _clock.UtcNow.AddMinutes( tokenValidityMinutes )
		};

		_ = _dbContext.Tokens.Add( token );
		_ = await _dbContext.SaveChangesAsync();

		return GetTokenDto.FromToken( token );

	}
	private async Task<(string access, string refresh)> GenerateTokensAsync()
	{
		string access;
		string refresh;
		bool exists;
		do
		{
			var accessGuid = Guid.NewGuid();
			var refreshGuid = Guid.NewGuid();
			access = Base64UrlTextEncoder.Encode( accessGuid.ToByteArray() );
			refresh = Base64UrlTextEncoder.Encode( refreshGuid.ToByteArray() );

			exists = await _dbContext.Tokens
				.Where( t => t.AccessToken == access || t.RefreshToken == refresh )
				.AnyAsync();

		} while ( exists );

		return (access, refresh);
	}

	public async Task<TokenModel?> GetTokenWithDataAsync( string accessToken )
	{
		return await _dbContext.Tokens
			.Include( t => t.User )
			.Where( t => t.AccessToken == accessToken )
			.FirstOrDefaultAsync();
	}


	const char hashSplitChar = ':';
	public string HashNewPassword( string password )
	{
		var salt = GenerateSalt();
		var hash = HashPassword( password, salt );
		var saltString = Convert.ToBase64String( salt );
		return $"{hash}{hashSplitChar}{saltString}";
	}
	public bool CheckPassword( string password, string hashString )
	{
		var values = hashString.Split( hashSplitChar );
		if ( values.Length != 2 )
		{
			throw new ArgumentException( null, nameof( hashString ) );
		}
		var validHash = values[0];
		var salt = Convert.FromBase64String( values[1] );

		var passedHash = HashPassword( password, salt );
		return passedHash == validHash;
	}

	static readonly RandomNumberGenerator rng = RandomNumberGenerator.Create();
	private static byte[] GenerateSalt()
	{
		var buffer = new byte[32];
		rng.GetBytes( buffer );
		return buffer;
	}
	private static string HashPassword( string password, byte[] salt )
	{
		var bytes = Rfc2898DeriveBytes.Pbkdf2( password, salt, 8192, HashAlgorithmName.SHA512, 512 );
		return Convert.ToBase64String( bytes );
	}
}
