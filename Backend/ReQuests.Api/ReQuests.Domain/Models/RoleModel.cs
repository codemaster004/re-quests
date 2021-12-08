using ReQuests.Domain.Relations;

namespace ReQuests.Domain.Models;

public class RoleModel
{
	public RoleModel(string name)
	{
		Name = name;
	}
	public int Id { get; set; }
	public string Name { get; set; }

	public List<UserModel>? Users { get; set; }
	public List<UserRoleRelation>? UsersR { get; set; }
}
