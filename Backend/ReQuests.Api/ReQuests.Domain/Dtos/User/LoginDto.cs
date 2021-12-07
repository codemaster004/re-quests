using System.ComponentModel.DataAnnotations;

namespace ReQuests.Domain.Dtos.User;

public class LoginDto
{
#nullable disable warnings
	[Required]
	public string Username { get; set; }
	[Required]
	[MinLength( 8 )]
	public string Password { get; set; }
#nullable restore
}
