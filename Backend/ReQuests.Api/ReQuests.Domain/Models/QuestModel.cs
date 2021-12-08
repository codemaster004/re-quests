using ReQuests.Domain.Relations;

namespace ReQuests.Domain.Models;

public class QuestModel
{
	public QuestModel( string name, string description )
	{
		Name = name;
		Description = description;
	}

	public int Id { get; set; }
	public string Name { get; set; }
	public string Description { get; set; }

	public TimeSpan Duration { get; set; }

	public List<UserModel>? Users { get; set; }
	public List<UserQuestRelation>? UsersR { get; set; }
}
