using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using ReQuests.Data;
using Z.EntityFramework.Plus;

namespace ReQuests.Api.Services;

public class CleanupWorker : BackgroundService
{
	private readonly ILogger<CleanupWorker> _logger;
	private readonly IServiceProvider _serviceProvider;
	private readonly ISystemClock _clock;
	public CleanupWorker( IServiceProvider provider, ILogger<CleanupWorker> logger, ISystemClock clock )
	{
		_serviceProvider = provider;
		_logger = logger;
		_clock = clock;
	}

	const int milisecondsInterval = 60 * 1000;
	protected override async Task ExecuteAsync( CancellationToken stoppingToken )
	{
		while ( !stoppingToken.IsCancellationRequested )
		{
			try
			{
				_logger.LogInformation( "Cleanup worker running at: {time}", _clock.UtcNow );

				using ( var scope = _serviceProvider.CreateScope() )
				{
					using var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

					await RemoveOldTokens( dbContext );
					await UpdateQuestsCompletion( dbContext );
				}

			}
			catch ( Exception )
			{
				_logger.LogError( "Error occured in cleanup worker" );
			}
			await Task.Delay( milisecondsInterval, stoppingToken );
		}
	}

	static readonly TimeSpan outdatedTokenKeepTime = TimeSpan.FromHours( 3 );
	private async Task RemoveOldTokens( AppDbContext dbContext )
	{
		try
		{
			var removeBelow = _clock.UtcNow + outdatedTokenKeepTime;

			var count = await dbContext.Tokens
				.Where( t => t.ValidUntil <= removeBelow )
				.DeleteAsync();

			_logger.LogInformation( "Removed {count} outdated tokens", count );
		}
		catch ( Exception )
		{
			_logger.LogError( "Error occured while removing outdated tokens" );
		}
	}
	private async Task UpdateQuestsCompletion( AppDbContext dbContext )
	{
		try
		{
			var now = _clock.UtcNow;

			var count = await dbContext.UsersQuests
				.Include( uq => uq.Quest! )
				.Where( uq => uq.DateCompleted == null && uq.DateStarted + uq.Quest!.Duration <= now )
				.UpdateAsync( uq => new( uq.UserUuid, uq.DateStarted ) { DateCompleted = now } );

			_logger.LogInformation( "Updated {count} completed quests", count );
		}
		catch ( Exception )
		{
			_logger.LogError( "Error occured while updating completed quests" );
		}
	}

	class DateCompletedUpdater
	{
		public DateTimeOffset DateCompleted { get; set; }
	}

}
