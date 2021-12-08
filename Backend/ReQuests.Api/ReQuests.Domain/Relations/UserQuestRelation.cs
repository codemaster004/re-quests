using ReQuests.Domain.Models;

namespace ReQuests.Domain.Relations;

public class UserQuestRelation
{
	public UserQuestRelation( string userUuid )
	{
		UserUuid = userUuid;
	}

	public int Id { get; set; }
	public string UserUuid { get; set; }
	public int QuestId { get; set; }
	public DateTimeOffset DateStarted { get; set; }

	public UserModel? User { get; set; }
	public QuestModel? Quest { get; set; }
}
