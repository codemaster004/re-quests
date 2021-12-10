using ReQuests.Domain.Models;
using System.Linq.Expressions;

namespace ReQuests.Domain.Dtos.Token;

public record GetTokenDto
{
#nullable disable warnings
	public string AccessToken { get; set; }
	public string RefreshToken { get; set; }
	public DateTimeOffset ValidUntil { get; set; }
#nullable restore

	public static Expression<Func<TokenModel, GetTokenDto>> FromTokenExp => fromTokenExp;
	private static readonly Expression<Func<TokenModel, GetTokenDto>> fromTokenExp = ( TokenModel token ) => new GetTokenDto()
	{
		AccessToken = token.AccessToken,
		RefreshToken = token.RefreshToken,
		ValidUntil = token.ValidUntil,
	};

	private static readonly Func<TokenModel, GetTokenDto> fromTokenFunc = fromTokenExp.Compile();
	public static GetTokenDto FromToken( TokenModel token )
	{
		return fromTokenFunc( token );
	}
}
