using ReQuests.Domain.Relations;
using System.ComponentModel.DataAnnotations;

namespace ReQuests.Domain.Models;

public class QuestModel
{
	public QuestModel( string name, string description, string explanation, string imageUrl, string awardUrl, string color )
	{
		Name = name;
		Description = description;
		Explanation = explanation;
		ImageUrl = imageUrl;
		AwardUrl = awardUrl;
		Color = color;
	}

	public int Id { get; set; }

	[StringLength( 24 )]
	public string Name { get; set; }
	public string Description { get; set; }
	public string Explanation { get; set; }
	public string ImageUrl { get; set; }
	public string AwardUrl { get; set; }
	[StringLength( 20 )]
	public string Color { get; set; }

	public TimeSpan Duration { get; set; }
	public int Difficulty { get; set; }

	public List<UserModel>? Users { get; set; }
	public List<UserQuestRelation>? UsersR { get; set; }
}
