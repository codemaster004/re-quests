namespace ReQuests.Domain.Models;

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
	public string AccessToken { get; set; }
	public string RefreshToken { get; set; }
	public DateTimeOffset ValidUntil { get; set; }
}
