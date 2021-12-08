using ReQuests.Domain.Converters;
using ReQuests.Domain.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ReQuests.Domain.Dtos.Quest;

public record CreateQuestDto
{
#nullable disable warnings
	[Required]
	public string Name { get; set; }
	[Required]
	public string Description { get; set; }

	[Required]
	[JsonConverter( typeof( TimeSpanJsonConverter ) )]
	public TimeSpan Duration { get; set; }

#nullable restore

	public QuestModel ToQuest()
	{
		return new( Name, Description ) { Duration = Duration };
	}
}
