using System.Security.Claims;

namespace ReQuests.Api.Extensions;

public static class AuthenticationExtensions
{
	public static string? GetUuid( this ClaimsPrincipal principal )
	{
		return principal.Claims.Where( c => c.Type == ClaimTypes.Name ).FirstOrDefault()?.Value;
	}
}
