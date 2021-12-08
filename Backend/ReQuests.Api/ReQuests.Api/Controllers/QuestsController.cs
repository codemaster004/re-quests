using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReQuests.Domain.Dtos.Quest;

namespace ReQuests.Api.Controllers;

[Authorize]
[ApiController]
[Route( "api/[controller]" )]
public class QuestsController : ControllerBase
{
	private readonly IQuestsService _questsService;

	public QuestsController( IQuestsService questsService )
	{
		_questsService = questsService;
	}

	[HttpGet]
	public async Task<ActionResult<GetQuestDto[]>> GetQuests()
	{
		return await _questsService.GetQuests();
	}

	[HttpGet( "{id}" )]
	public async Task<ActionResult<GetQuestDto>> GetQuest( int id )
	{
		var quest = await _questsService.GetQuest( id );
		if ( quest is null )
		{
			return NotFound();
		}

		return quest;
	}

	[HttpPost]
	[Authorize( Roles = "Admin" )]
	public async Task<IActionResult> CreateQuest( [FromBody] CreateQuestDto dto )
	{
		var quest = await _questsService.CreateQuest( dto );

		return CreatedAtAction( nameof( GetQuest ), new { quest.Id }, quest );
	}

	[HttpDelete( "{id}" )]
	[Authorize( Roles = "Admin" )]
	public async Task<IActionResult> DeleteQuest( int id )
	{
		try
		{
			await _questsService.DeleteQuest( id );
		}
		catch ( NotFoundException )
		{
			return NotFound();
		}

		return NoContent();
	}

}
