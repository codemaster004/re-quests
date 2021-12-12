using ReQuests.Domain.Converters;
using ReQuests.Domain.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ReQuests.Domain.Dtos.Quest;

public record CreateQuestDto
{
#nullable disable warnings
	[Required]
	[StringLength( 24 )]
	public string Name { get; set; }
	[Required]
	public string Description { get; set; }

	[Required]
	[JsonConverter( typeof( TimeSpanRfc8601JsonConverter ) )]
	public TimeSpan Duration { get; set; }

	[Required]
	public int Difficulty { get; set; }

	[Required]
	public string Explanation { get; set; }

	[Required]
	public string ImageUrl { get; set; }
	public string AwardUrl { get; set; }
	[StringLength( 20 )]
	public string Color { get; set; }

#nullable restore

	public QuestModel ToQuest()
	{
		return new( Name, Description, Explanation, ImageUrl, AwardUrl, Color ) { Duration = Duration, Difficulty = Difficulty };
	}
}
