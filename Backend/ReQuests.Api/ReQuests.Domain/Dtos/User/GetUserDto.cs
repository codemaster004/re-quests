using ReQuests.Domain.Models;
using System.Linq.Expressions;

namespace ReQuests.Domain.Dtos.User;

public record GetUserDto
{
#nullable disable warnings
	public string Uuid { get; set; }
	public string Username { get; set; }
	public string Email { get; set; }
#nullable restore

	public static Expression<Func<UserModel, GetUserDto>> FromUserExp => fromUserExp;
	private static readonly Expression<Func<UserModel, GetUserDto>> fromUserExp = ( UserModel user ) => new GetUserDto()
	{
		Uuid = user.Uuid,
		Username = user.Username,
		Email = user.Email,
	};

	private static readonly Func<UserModel, GetUserDto> fromUserFunc = fromUserExp.Compile();
	public static GetUserDto FromUser( UserModel user )
	{
		return fromUserFunc( user );
	}

}
