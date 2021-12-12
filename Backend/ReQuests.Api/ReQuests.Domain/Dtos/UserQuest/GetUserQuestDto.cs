using ReQuests.Domain.Converters;
using ReQuests.Domain.Relations;
using System.ComponentModel.DataAnnotations;
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
	public bool WasWinReceived { get; set; }

	[JsonConverter( typeof( TimeSpanDaysCountJsonConverter ) )]
	public TimeSpan Duration { get; set; }
	[JsonConverter( typeof( TimeSpanDaysCountJsonConverter ) )]
	public TimeSpan SinceStart => DateTimeOffset.UtcNow - DateStarted;

	[StringLength( 24 )]
	public string QuestName { get; set; }
	public string QuestDescription { get; set; }
	public int QuestDifficulty { get; set; }
	public string QuestExplanation { get; set; }
	public string QuestImageUrl { get; set; }
	public string QuestAwardUrl { get; set; }
	[StringLength( 20 )]
	public string QuestColor { get; set; }

#nullable restore

	public static Expression<Func<UserQuestRelation, GetUserQuestDto>> FromUserQuestExp => fromUserQuestExp;
	private static readonly Expression<Func<UserQuestRelation, GetUserQuestDto>> fromUserQuestExp = ( UserQuestRelation userQuest ) => new GetUserQuestDto()
	{
		QuestId = userQuest.QuestId,
		DateStarted = userQuest.DateStarted,
		DateCompleted = userQuest.DateCompleted,
		Attempts = userQuest.Attempts,
		WasWinReceived = userQuest.WasWinReceived,

		Duration = userQuest.Quest!.Duration,
		QuestName = userQuest.Quest.Name,
		QuestDescription = userQuest.Quest.Description,
		QuestDifficulty = userQuest.Quest.Difficulty,
		QuestExplanation = userQuest.Quest.Explanation,
		QuestImageUrl = userQuest.Quest.ImageUrl,
		QuestAwardUrl = userQuest.Quest.AwardUrl,
		QuestColor = userQuest.Quest.Color,
	};

	private static readonly Func<UserQuestRelation, GetUserQuestDto> fromUserQuestFunc = fromUserQuestExp.Compile();
	public static GetUserQuestDto FromUserQuest( UserQuestRelation userQuest )
	{
		return fromUserQuestFunc( userQuest );
	}
}
