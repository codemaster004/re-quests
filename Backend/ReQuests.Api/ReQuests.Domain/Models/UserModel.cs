using Microsoft.EntityFrameworkCore;
using ReQuests.Domain.Relations;
using System.ComponentModel.DataAnnotations;

namespace ReQuests.Domain.Models;

[Index( nameof( Uuid ), IsUnique = true )]
[Index( nameof( Username ), IsUnique = true )]
[Index( nameof( Email ), IsUnique = true )]
public class UserModel
{
	public UserModel( string uuid, string username, string email, string passwordHash )
	{
		Uuid = uuid;
		Username = username;
		Email = email;
		PasswordHash = passwordHash;
	}

	public int Id { get; set; }

	[StringLength( 24 )]
	public string Uuid { get; set; }

	[StringLength( 50 )]
	public string Username { get; set; }

	[StringLength( 50 )]
	public string Email { get; set; }

	public string PasswordHash { get; set; }

	public List<TokenModel>? Tokens { get; set; }
	public List<RoleModel>? Roles { get; set; }
	public List<UserRoleRelation>? RolesR { get; set; }
	public List<QuestModel>? Quests { get; set; }
	public List<UserQuestRelation>? QuestsR { get; set; }
}
