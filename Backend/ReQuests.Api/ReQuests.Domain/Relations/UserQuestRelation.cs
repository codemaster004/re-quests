using Microsoft.EntityFrameworkCore;
using ReQuests.Domain.Models;

namespace ReQuests.Domain.Relations;

[Index( nameof( UserUuid ), nameof( QuestId ), IsUnique = true )]
public class UserQuestRelation
{
	public UserQuestRelation( string userUuid, DateTimeOffset dateStarted )
	{
		UserUuid = userUuid;
		DateStarted = dateStarted;
	}

	public int Id { get; set; }
	public string UserUuid { get; set; }
	public int QuestId { get; set; }
	public DateTimeOffset DateStarted { get; set; }
	public DateTimeOffset? DateCompleted { get; set; }
	public int Attempts { get; set; }

	public UserModel? User { get; set; }
	public QuestModel? Quest { get; set; }
}
