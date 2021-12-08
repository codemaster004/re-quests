using Microsoft.EntityFrameworkCore;
using ReQuests.Domain.Relations;
using System.ComponentModel.DataAnnotations;

namespace ReQuests.Domain.Models;

[Index( nameof( Name ), IsUnique = true )]
public class RoleModel
{
	public RoleModel(string name)
	{
		Name = name;
	}
	public int Id { get; set; }

	[StringLength( 24 )]
	public string Name { get; set; }

	public List<UserModel>? Users { get; set; }
	public List<UserRoleRelation>? UsersR { get; set; }
}
