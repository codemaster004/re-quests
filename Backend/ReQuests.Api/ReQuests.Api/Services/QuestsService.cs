using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using ReQuests.Data;
using ReQuests.Domain.Dtos.Quest;
using ReQuests.Domain.Dtos.UserQuest;
using ReQuests.Domain.Models;
using ReQuests.Domain.Relations;
using System.Linq.Expressions;

namespace ReQuests.Api.Services;

public interface IQuestsService
{
	Task<GetQuestDto[]> GetQuests( int[]? ids, QuestsOrderBy orderBy = default );
	Task<GetQuestDto?> GetQuest( int id );
	Task<GetQuestDto> CreateQuest( CreateQuestDto dto );
	Task UpdateQuest( int id, CreateQuestDto dto );
	Task DeleteQuest( int id );

	Task<GetQuestDto[]> GetAvailable( string userUuid, QuestsOrderBy orderBy = default );

	Task BeginQuest( int questId, string userUuid );
	Task<GetUserQuestDto[]> GetBegun( int[]? questIds, string uuid );
	Task<GetUserQuestDto?> GetBegun( int questId, string uuid );

	Task AbortQuest( int questId, string userUuid );
	Task ResetQuest( int questId, string userUuid );
	Task<bool> CheckQuestCompletion( int questId, string userUuid );
	Task<GetUserQuestDto[]> GetCompleted( string uuid );
	Task<GetUserQuestDto[]> GetUncompleted( string uuid );
	Task MarkAsReceived( int questId, string userUuid );
}

public class QuestsService : IQuestsService
{
	private static readonly Dictionary<QuestsOrderBy, Expression<Func<QuestModel, object>>> OrderExps = new()
	{
		{ QuestsOrderBy.None, x => x.Id },
		{ QuestsOrderBy.Name, x => x.Name },
		{ QuestsOrderBy.Difficulty, x => x.Difficulty },
	};

	private readonly AppDbContext _dbContext;
	private readonly ISystemClock _clock;

	public QuestsService( AppDbContext dbContext, ISystemClock clock )
	{
		_dbContext = dbContext;
		_clock = clock;
	}

	public async Task<GetQuestDto[]> GetQuests( int[]? ids, QuestsOrderBy orderBy = default )
	{
		return await ( ids is null ?
			_dbContext.Quests :
			_dbContext.Quests
				.Where( x => ids.Contains( x.Id ) )
			)
			.OrderBy( OrderExps[orderBy] )
			.Select( GetQuestDto.FromQuestExp )
			.ToArrayAsync();
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
	public async Task UpdateQuest( int id, CreateQuestDto dto )
	{
		var quest = await _dbContext.Quests
			.Where( q => q.Id == id )
			.FirstOrDefaultAsync();

		if ( quest is null )
		{
			throw new NotFoundException();
		}

		dto.UpdateQuest( quest );

		_ = _dbContext.Quests.Update( quest );
		_ = await _dbContext.SaveChangesAsync();
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


	public async Task<GetQuestDto[]> GetAvailable( string userUuid, QuestsOrderBy orderBy = default )
	{
		return await _dbContext.Quests
			.Where( q => !q.UsersR!.Where( uq => uq.UserUuid == userUuid ).Any() )
			.OrderBy( OrderExps[orderBy] )
			.Select( GetQuestDto.FromQuestExp )
			.ToArrayAsync();
	}

	public async Task BeginQuest( int questId, string userUuid )
	{
		var user = from u in _dbContext.Users
				   where u.Uuid == userUuid
				   select new { };

		var quest = from q in _dbContext.Quests
					where q.Id == questId
					select new { };

		var exist = await user.Concat( quest ).CountAsync() == 2;
		if ( !exist )
		{
			throw new NotFoundException();
		}

		UserQuestRelation userQuest = new( userUuid, _clock.UtcNow )
		{
			QuestId = questId,
			Attempts = 1
		};

		_ = _dbContext.UsersQuests.Add( userQuest );
		_ = await _dbContext.SaveChangesAsync();
	}
	public async Task<GetUserQuestDto[]> GetBegun( int[]? questIds, string uuid )
	{
		return await ( questIds is null ?
			_dbContext.UsersQuests :
			_dbContext.UsersQuests
			 .Where( uq => questIds.Contains( uq.QuestId ) )
			)
			.Where( uq => uq.UserUuid == uuid )
			.OrderBy( uq => uq.DateStarted )
			.Select( GetUserQuestDto.FromUserQuestExp )
			.ToArrayAsync();
	}
	public async Task<GetUserQuestDto?> GetBegun( int questId, string uuid )
	{
		return await _dbContext.UsersQuests
			.Where( uq => uq.UserUuid == uuid )
			.Where( uq => uq.QuestId == questId )
			.OrderBy( uq => uq.DateStarted )
			.Select( GetUserQuestDto.FromUserQuestExp )
			.FirstOrDefaultAsync();
	}

	public async Task AbortQuest( int questId, string userUuid )
	{
		var userQuest = await _dbContext.UsersQuests
			.Where( uq => uq.UserUuid == userUuid )
			.Where( uq => uq.QuestId == questId )
			.FirstOrDefaultAsync();

		if ( userQuest is null )
		{
			throw new NotFoundException();
		}

		_ = _dbContext.UsersQuests.Remove( userQuest );
		_ = await _dbContext.SaveChangesAsync();
	}
	public async Task ResetQuest( int questId, string userUuid )
	{
		var userQuest = await _dbContext.UsersQuests
			.Where( uq => uq.UserUuid == userUuid )
			.Where( uq => uq.QuestId == questId )
			.FirstOrDefaultAsync();

		if ( userQuest is null )
		{
			throw new NotFoundException();
		}

		userQuest.DateStarted = _clock.UtcNow;
		userQuest.Attempts += 1;

		_ = await _dbContext.SaveChangesAsync();
	}
	public async Task<bool> CheckQuestCompletion( int questId, string userUuid )
	{
		var userQuest = await _dbContext.UsersQuests
			.Include( uq => uq.Quest )
			.Where( uq => uq.UserUuid == userUuid )
			.Where( uq => uq.QuestId == questId )
			.FirstOrDefaultAsync();

		if ( userQuest is null )
		{
			throw new NotFoundException();
		}

		if ( userQuest.DateCompleted is not null )
		{
			return true;
		}

		if ( userQuest.DateStarted + userQuest.Quest!.Duration <= _clock.UtcNow )
		{
			userQuest.DateCompleted = userQuest.DateStarted + userQuest.Quest!.Duration;
			_ = await _dbContext.SaveChangesAsync();
			return true;
		}

		return false;
	}
	public async Task<GetUserQuestDto[]> GetCompleted( string uuid )
	{
		return await _dbContext.UsersQuests
			.Where( uq => uq.UserUuid == uuid )
			.Where( uq => uq.DateCompleted != null )
			.OrderBy( uq => uq.DateCompleted )
			.Select( GetUserQuestDto.FromUserQuestExp )
			.ToArrayAsync();
	}
	public async Task<GetUserQuestDto[]> GetUncompleted( string uuid )
	{
		return await _dbContext.UsersQuests
			.Where( uq => uq.UserUuid == uuid )
			.Where( uq => uq.DateCompleted == null )
			.OrderBy( uq => uq.DateStarted )
			.Select( GetUserQuestDto.FromUserQuestExp )
			.ToArrayAsync();
	}

	public async Task MarkAsReceived( int questId, string userUuid )
	{
		var userQuest = await _dbContext.UsersQuests
			.Where( uq => uq.UserUuid == userUuid )
			.Where( uq => uq.QuestId == questId )
			.FirstOrDefaultAsync();

		if ( userQuest is null )
		{
			throw new NotFoundException();
		}

		if ( userQuest.DateCompleted is null )
		{
			throw new ConflictException();
		}

		userQuest.WasWinReceived = true;

		_ = await _dbContext.SaveChangesAsync();
	}


}

public enum QuestsOrderBy
{
	None = default,
	Name,
	Difficulty,
}
