using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReQuests.Api.Extensions;
using ReQuests.Domain.Dtos.Quest;
using ReQuests.Domain.Dtos.UserQuest;

namespace ReQuests.Api.Controllers;

[Authorize]
[ApiController]
[Route( "api/[controller]" )]
public class QuestsController : ExtendedControllerBase
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
	[Authorize( Roles = Constants.Auth.SuperAdminRole )]
	public async Task<IActionResult> CreateQuest( [FromBody] CreateQuestDto dto )
	{
		var quest = await _questsService.CreateQuest( dto );

		return CreatedAtAction( nameof( GetQuest ), new { quest.Id }, quest );
	}

	[HttpDelete( "{id}" )]
	[Authorize( Roles = Constants.Auth.SuperAdminRole )]
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


	[HttpPost( "{id}/begin" )]
	public async Task<IActionResult> BeginQuest( int id )
	{
		var uuid = User.GetUuid();
		if ( uuid is null )
		{
			return InternalServerError( "Error occured" );
		}

		try
		{
			await _questsService.BeginQuest( id, uuid );
		}
		catch ( NotFoundException )
		{
			return NotFound( "quest not found" );
		}

		return NoContent();
	}

	[HttpGet( "begun" )]
	public async Task<ActionResult<GetUserQuestDto[]>> GetBegun()
	{
		var uuid = User.GetUuid();
		if ( uuid is null )
		{
			return InternalServerError( "Error occured" );
		}

		return await _questsService.GetBegun( uuid );
	}


}
