using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ReQuests.Domain.Models;

[Index( nameof( AccessToken ), IsUnique = true )]
[Index( nameof( RefreshToken ), IsUnique = true )]
public class TokenModel
{
	public TokenModel( string userUuid, string accessToken, string refreshToken )
	{
		UserUuid = userUuid;
		AccessToken = accessToken;
		RefreshToken = refreshToken;
	}
	public int Id { get; set; }
	public string UserUuid { get; set; }
	public UserModel? User { get; set; }

	[StringLength( 24 )]
	public string AccessToken { get; set; }

	[StringLength( 24 )]
	public string RefreshToken { get; set; }
	public DateTimeOffset ValidUntil { get; set; }
}
