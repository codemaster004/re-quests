using ReQuests.Domain.Relations;
using System.ComponentModel.DataAnnotations;

namespace ReQuests.Domain.Models;

public class QuestModel
{
	public QuestModel( string name, string description, string explanation, string imageUrl )
	{
		Name = name;
		Description = description;
		Explanation = explanation;
		ImageUrl = imageUrl;
	}

	public int Id { get; set; }

	[StringLength( 24 )]
	public string Name { get; set; }
	public string Description { get; set; }
	public string Explanation { get; set; }
	public string ImageUrl { get; set; }

	public TimeSpan Duration { get; set; }
	public int Difficulty { get; set; }

	public List<UserModel>? Users { get; set; }
	public List<UserQuestRelation>? UsersR { get; set; }
}
