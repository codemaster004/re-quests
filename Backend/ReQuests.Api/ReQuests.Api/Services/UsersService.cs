using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using ReQuests.Api.Exceptions;
using ReQuests.Data;
using ReQuests.Domain.Dtos.User;
using System.Security.Cryptography;

namespace ReQuests.Api.Services;

public interface IUsersService
{
	Task<GetUserDto[]> GetUsersAsync();
	Task<GetUserDto?> GetUserAsync( string uuid );
	Task<GetUserDto> CreateUserAsync( CreateUserDto dto );
	Task DeleteUserAsync( string uuid );
}

public class UsersService : IUsersService
{
	private readonly AppDbContext _dbContext;
	private readonly IAuthService _authService;

	public UsersService( AppDbContext dbContext, IAuthService authService )
	{
		_dbContext = dbContext;
		_authService = authService;
	}

	public async Task<GetUserDto[]> GetUsersAsync()
	{
		return await _dbContext.Users
			.Select( GetUserDto.FromUserExp )
			.ToArrayAsync();
	}
	public async Task<GetUserDto?> GetUserAsync( string uuid )
	{
		return await _dbContext.Users
			.Where( u => u.Uuid == uuid )
			.Select( GetUserDto.FromUserExp )
			.FirstOrDefaultAsync();
	}
	public async Task<GetUserDto> CreateUserAsync( CreateUserDto dto )
	{
		var existing =
			( from u in _dbContext.Users
			  where u.Email == dto.Email || u.Username == dto.Username
			  let isEmail = u.Email == dto.Email
			  let isUsername = u.Username == dto.Username
			  select new { isEmail, isUsername } )
				.FirstOrDefault();

		if ( existing is not null )
		{
			if ( existing.isEmail )
			{
				throw new ConflictException( nameof( dto.Email ) );
			}
			throw new ConflictException( nameof( dto.Username ) );
		}

		var uuid = await GenerateUuidAsync();
		var hash = _authService.HashNewPassword( dto.Password );

		var user = dto.ToUser( uuid, hash );

		_ = _dbContext.Users.Add( user );
		_ = await _dbContext.SaveChangesAsync();

		return GetUserDto.FromUser( user );
	}
	public async Task DeleteUserAsync( string uuid )
	{
		var user = await _dbContext.Users
			.Where( u => u.Uuid == uuid )
			.FirstOrDefaultAsync();

		if ( user is null )
		{
			throw new ArgumentException( null, nameof( uuid ) );
		}

		_ = _dbContext.Users.Remove( user );
		_ = await _dbContext.SaveChangesAsync();

	}

	private async Task<string> GenerateUuidAsync()
	{
		string uuid;
		do
		{
			var guid = Guid.NewGuid();
			uuid = Base64UrlTextEncoder.Encode( guid.ToByteArray() );
		} while ( await _dbContext.Users.Where(u=>u.Uuid == uuid).AnyAsync() );

		return uuid;
	}
}
