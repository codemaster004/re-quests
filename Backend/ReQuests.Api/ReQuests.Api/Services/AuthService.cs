using System.Security.Cryptography;

namespace ReQuests.Api.Services;

public interface IAuthService
{
	bool ChackPassword( string password, string hashString );
	string HashNewPassword( string password );
}

public class AuthService : IAuthService
{


	const char hashSplitChar = ':';
	public string HashNewPassword( string password )
	{
		var salt = GenerateSalt();
		var hash = HashPassword( password, salt );
		var saltString = Convert.ToBase64String( salt );
		return $"{hash}{hashSplitChar}{saltString}";
	}
	public bool ChackPassword( string password, string hashString )
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
