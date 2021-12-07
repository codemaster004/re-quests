using ReQuests.Domain.Models;

namespace ReQuests.Domain.Dtos.User;

public record CreateUserDto
{
#nullable disable warnings
	public string Username { get; set; }
	public string Email { get; set; }
	public string Password { get; set; }
#nullable restore

	public UserModel ToUser( string uuid, string hash )
	{
		return new UserModel( uuid, Username, Email, hash );
	}
}
