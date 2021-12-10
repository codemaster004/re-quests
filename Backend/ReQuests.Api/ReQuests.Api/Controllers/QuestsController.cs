using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReQuests.Api.Auth.Attributes;
using ReQuests.Api.Controllers.Attributes;
using ReQuests.Api.Extensions;
using ReQuests.Domain.Dtos.Quest;
using ReQuests.Domain.Dtos.UserQuest;

using MtnA = System.Net.Mime.MediaTypeNames.Application;

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

	// GET api/quests
	[HttpGet]

	[Produces( MtnA.Json, MtnA.Xml )]
	[Produces200( typeof( GetQuestDto[] ) )]
	public async Task<ActionResult<GetQuestDto[]>> GetQuests( [FromQuery] int[] ids, [FromQuery] QuestsOrderBy order )
	{
		return await _questsService.GetQuests( ids.Any() ? ids : null, order );
	}

	// GET api/quests/1
	[HttpGet( "{id}" )]

	[Produces( MtnA.Json, MtnA.Xml )]
	[Produces200( typeof( GetQuestDto ) )]
	[ProducesProblem( 404 )]
	public async Task<ActionResult<GetQuestDto>> GetQuest( int id )
	{
		var quest = await _questsService.GetQuest( id );
		if ( quest is null )
		{
			return NotFound();
		}

		return quest;
	}

	// POST api/quests
	[HttpPost]
	[SuperAdminOnly]

	[Consumes( MtnA.Json )]
	[Produces( MtnA.Json, MtnA.Xml )]
	[ProducesResponseType( typeof( string ), 201 )]
	[ProducesProblem( 403 )]
	public async Task<IActionResult> CreateQuest( [FromBody] CreateQuestDto dto )
	{
		var quest = await _questsService.CreateQuest( dto );

		return CreatedAtAction( nameof( GetQuest ), new { quest.Id }, quest );
	}

	// DELETE api/quests/1
	[HttpDelete( "{id}" )]
	[SuperAdminOnly]

	[Produces( MtnA.Json, MtnA.Xml )]
	[Produces204()]
	[ProducesProblem( 403 )]
	[ProducesProblem( 404 )]
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


	// GET api/quests/available
	[HttpGet( "available" )]

	[Produces( MtnA.Json, MtnA.Xml )]
	[Produces200( typeof( GetQuestDto[] ) )]
	public async Task<ActionResult<GetQuestDto[]>> GetAvailable( [FromQuery] QuestsOrderBy order )
	{
		var uuid = User.GetUuid();
		if ( uuid is null )
		{
			return InternalServerError( "Error occured" );
		}

		return await _questsService.GetAvailable( uuid, order );
	}


	// POST api/quests/1/begin
	[HttpPost( "{id}/begin" )]

	[Produces( MtnA.Json, MtnA.Xml )]
	[Produces204()]
	[ProducesProblem( 404 )]
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

	// GET api/quests/begun
	[HttpGet( "begun" )]

	[Produces( MtnA.Json, MtnA.Xml )]
	[Produces200( typeof( GetQuestDto[] ) )]
	public async Task<ActionResult<GetUserQuestDto[]>> GetBegun( [FromQuery] int[] ids )
	{
		var uuid = User.GetUuid();
		if ( uuid is null )
		{
			return InternalServerError( "Error occured" );
		}

		return await _questsService.GetBegun( ids.Any() ? ids : null, uuid );
	}

	// GET api/quests/begun
	[HttpGet( "begun/{id}" )]

	[Produces( MtnA.Json, MtnA.Xml )]
	[Produces200( typeof( GetQuestDto ) )]
	[ProducesProblem( 404 )]
	public async Task<ActionResult<GetUserQuestDto>> GetBegun( int id )
	{
		var uuid = User.GetUuid();
		if ( uuid is null )
		{
			return InternalServerError( "Error occured" );
		}

		var userQuest = await _questsService.GetBegun( id, uuid );
		if ( userQuest is null )
		{
			return NotFound();
		}

		return userQuest;
	}


	// POST api/quests/1/abort
	[HttpPost( "{id}/abort" )]

	[Produces( MtnA.Json, MtnA.Xml )]
	[Produces204()]
	[ProducesProblem( 404 )]
	public async Task<IActionResult> AbortQuest( int id )
	{
		var uuid = User.GetUuid();
		if ( uuid is null )
		{
			return InternalServerError( "Error occured" );
		}

		try
		{
			await _questsService.AbortQuest( id, uuid );
		}
		catch ( NotFoundException )
		{
			return NotFound( "quest not started" );
		}

		return NoContent();
	}

	// POST api/quests/1/reset
	[HttpPost( "{id}/reset" )]

	[Produces( MtnA.Json, MtnA.Xml )]
	[Produces204()]
	[ProducesProblem( 404 )]
	public async Task<IActionResult> ResetQuest( int id )
	{
		var uuid = User.GetUuid();
		if ( uuid is null )
		{
			return InternalServerError( "Error occured" );
		}

		try
		{
			await _questsService.ResetQuest( id, uuid );
		}
		catch ( NotFoundException )
		{
			return NotFound( "quest not started" );
		}

		return NoContent();
	}

	// POST api/quests/1/check
	[HttpPost( "{id}/check" )]

	[Produces( MtnA.Json, MtnA.Xml )]
	[Produces200( typeof( bool ) )]
	[ProducesProblem( 404 )]
	public async Task<ActionResult<bool>> CheckQuestCompletion( int id )
	{
		var uuid = User.GetUuid();
		if ( uuid is null )
		{
			return InternalServerError( "Error occured" );
		}

		try
		{
			return await _questsService.CheckQuestCompletion( id, uuid );
		}
		catch ( NotFoundException )
		{
			return NotFound( "quest not started" );
		}

	}


	// GET api/quests/completed
	[HttpGet( "completed" )]

	[Produces( MtnA.Json, MtnA.Xml )]
	[Produces200( typeof( GetUserQuestDto[] ) )]
	public async Task<ActionResult<GetUserQuestDto[]>> GetCompleted()
	{
		var uuid = User.GetUuid();
		if ( uuid is null )
		{
			return InternalServerError( "Error occured" );
		}

		return await _questsService.GetCompleted( uuid );
	}

	// GET api/quests/uncompleted
	[HttpGet( "uncompleted" )]

	[Produces( MtnA.Json, MtnA.Xml )]
	[Produces200( typeof( GetUserQuestDto[] ) )]
	public async Task<ActionResult<GetUserQuestDto[]>> GetUncompleted()
	{
		var uuid = User.GetUuid();
		if ( uuid is null )
		{
			return InternalServerError( "Error occured" );
		}

		return await _questsService.GetUncompleted( uuid );
	}

}
