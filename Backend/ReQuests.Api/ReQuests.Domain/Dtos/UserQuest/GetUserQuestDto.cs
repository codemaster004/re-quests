using ReQuests.Domain.Relations;
using System.Linq.Expressions;

namespace ReQuests.Domain.Dtos.UserQuest;

public class GetUserQuestDto
{
#nullable disable warnings
	public int Id { get; set; }
	public int QuestId { get; set; }
	public DateTimeOffset DateStarted { get; set; }
	public DateTimeOffset? DateCompleted { get; set; }
	public int Attempts { get; set; }

#nullable restore

	public static Expression<Func<UserQuestRelation, GetUserQuestDto>> FromUserQuestExp => fromUserQuestExp;
	private static readonly Expression<Func<UserQuestRelation, GetUserQuestDto>> fromUserQuestExp = ( UserQuestRelation userQuest ) => new GetUserQuestDto()
	{
		Id = userQuest.Id,
		QuestId = userQuest.QuestId,
		DateStarted = userQuest.DateStarted,
		DateCompleted = userQuest.DateCompleted,
		Attempts = userQuest.Attempts,
	};

	private static readonly Func<UserQuestRelation, GetUserQuestDto> fromUserQuestFunc = fromUserQuestExp.Compile();
	public static GetUserQuestDto FromUserQuest( UserQuestRelation userQuest )
	{
		return fromUserQuestFunc( userQuest );
	}
}
