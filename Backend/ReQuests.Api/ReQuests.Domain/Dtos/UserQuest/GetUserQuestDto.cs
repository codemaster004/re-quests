using ReQuests.Domain.Converters;
using ReQuests.Domain.Relations;
using System.Linq.Expressions;
using System.Text.Json.Serialization;

namespace ReQuests.Domain.Dtos.UserQuest;

public record GetUserQuestDto
{
#nullable disable warnings
	public int QuestId { get; set; }
	public DateTimeOffset DateStarted { get; set; }
	public DateTimeOffset? DateCompleted { get; set; }
	public int Attempts { get; set; }

	[JsonConverter( typeof( TimeSpanDaysCountJsonConverter ) )]
	public TimeSpan Duration { get; set; }
	[JsonConverter( typeof( TimeSpanDaysCountJsonConverter ) )]
	public TimeSpan SinceStart => DateTimeOffset.UtcNow - DateStarted;

#nullable restore

	public static Expression<Func<UserQuestRelation, GetUserQuestDto>> FromUserQuestExp => fromUserQuestExp;
	private static readonly Expression<Func<UserQuestRelation, GetUserQuestDto>> fromUserQuestExp = ( UserQuestRelation userQuest ) => new GetUserQuestDto()
	{
		QuestId = userQuest.QuestId,
		DateStarted = userQuest.DateStarted,
		DateCompleted = userQuest.DateCompleted,
		Attempts = userQuest.Attempts,
		Duration = userQuest.Quest!.Duration
	};

	private static readonly Func<UserQuestRelation, GetUserQuestDto> fromUserQuestFunc = fromUserQuestExp.Compile();
	public static GetUserQuestDto FromUserQuest( UserQuestRelation userQuest )
	{
		return fromUserQuestFunc( userQuest );
	}
}
