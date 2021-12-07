using ReQuests.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace ReQuests.Domain.Dtos.User;

public record CreateUserDto
{
#nullable disable warnings
	[Required]
	[MinLength( 4 )]
	[RegularExpression( @"^[^@]*$", ErrorMessage = "Username cannot contain @" )]
	public string Username { get; set; }

	[Required]
	[EmailAddress]
	public string Email { get; set; }

	[Required]
	[MinLength( 8 )]
	public string Password { get; set; }
#nullable restore

	public UserModel ToUser( string uuid, string hash )
	{
		return new UserModel( uuid, Username, Email, hash );
	}
}
