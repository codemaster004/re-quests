using ReQuests.Domain.Converters;
using ReQuests.Domain.Models;
using System.Linq.Expressions;
using System.Text.Json.Serialization;

namespace ReQuests.Domain.Dtos.Quest;

public record GetQuestDto
{
#nullable disable warnings
	public int Id { get; set; }
	public string Name { get; set; }
	public string Description { get; set; }

	[JsonConverter( typeof( TimeSpanDaysCountJsonConverter ) )]
	public TimeSpan Duration { get; set; }
	public int Difficulty { get; set; }

#nullable restore

	public static Expression<Func<QuestModel, GetQuestDto>> FromQuestExp => fromQuestExp;
	private static readonly Expression<Func<QuestModel, GetQuestDto>> fromQuestExp = ( QuestModel quest ) => new GetQuestDto()
	{
		Id = quest.Id,
		Name = quest.Name,
		Description = quest.Description,
		Duration = quest.Duration,
		Difficulty = quest.Difficulty,
	};

	private static readonly Func<QuestModel, GetQuestDto> fromQuestFunc = fromQuestExp.Compile();
	public static GetQuestDto FromQuest( QuestModel quest )
	{
		return fromQuestFunc( quest );
	}
}
