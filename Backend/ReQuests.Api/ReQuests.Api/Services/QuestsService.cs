using Microsoft.EntityFrameworkCore;
using ReQuests.Data;
using ReQuests.Domain.Dtos.Quest;

namespace ReQuests.Api.Services;

public interface IQuestsService
{
	Task<GetQuestDto[]> GetQuests();
	Task<GetQuestDto?> GetQuest( int id );
	Task<GetQuestDto> CreateQuest( CreateQuestDto dto );
	Task DeleteQuest( int id );
}

public class QuestsService : IQuestsService
{
	private readonly AppDbContext _dbContext;

	public QuestsService( AppDbContext dbContext )
	{
		_dbContext = dbContext;
	}

	public async Task<GetQuestDto[]> GetQuests()
	{
		return await _dbContext.Quests.Select( GetQuestDto.FromQuestExp ).ToArrayAsync();
	}

	public async Task<GetQuestDto?> GetQuest( int id )
	{
		return await _dbContext.Quests
			.Where( q => q.Id == id )
			.Select( GetQuestDto.FromQuestExp )
			.FirstOrDefaultAsync();
	}

	public async Task<GetQuestDto> CreateQuest( CreateQuestDto dto )
	{
		var quest = dto.ToQuest();

		_ = _dbContext.Quests.Add( quest );
		_ = await _dbContext.SaveChangesAsync();

		return GetQuestDto.FromQuest( quest );
	}

	public async Task DeleteQuest( int id )
	{
		var quest = await _dbContext.Quests
			.Where( q => q.Id == id )
			.FirstOrDefaultAsync();

		if ( quest is null )
		{
			throw new NotFoundException();
		}

		_ = _dbContext.Quests.Remove( quest );
		_ = await _dbContext.SaveChangesAsync();
	}

}
