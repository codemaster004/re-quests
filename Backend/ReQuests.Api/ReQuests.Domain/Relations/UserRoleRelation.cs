using Microsoft.EntityFrameworkCore;
using ReQuests.Domain.Models;

namespace ReQuests.Domain.Relations;

[Index( nameof( UserUuid ), nameof( RoleId ), IsUnique = true )]
public class UserRoleRelation
{
	public UserRoleRelation( string userUuid )
	{
		UserUuid = userUuid;
	}

	public int Id { get; set; }
	public string UserUuid { get; set; }
	public int RoleId { get; set; }

	public UserModel? User { get; set; }
	public RoleModel? Role { get; set; }
}
