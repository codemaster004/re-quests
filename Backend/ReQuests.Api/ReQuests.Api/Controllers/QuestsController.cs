using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReQuests.Api.Extensions;
using ReQuests.Domain.Dtos.Quest;
using ReQuests.Domain.Dtos.UserQuest;
using System.Net.Mime;

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

	[Produces( MediaTypeNames.Application.Json, MediaTypeNames.Application.Xml )]
	[ProducesResponseType( typeof( GetQuestDto[] ), 200 )]
	public async Task<ActionResult<GetQuestDto[]>> GetQuests( [FromQuery] int[] ids )
	{
		if ( ids.Length > 0 )
		{
			return await _questsService.GetQuests( ids );
		}

		return await _questsService.GetQuests();
	}

	// GET api/quests/1
	[HttpGet( "{id}" )]

	[Produces( MediaTypeNames.Application.Json, MediaTypeNames.Application.Xml )]
	[ProducesResponseType( typeof( GetQuestDto ), 200 )]
	[ProducesResponseType( typeof( ProblemDetails ), 404 )]
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
	[Authorize( Roles = Constants.Auth.SuperAdminRole )]

	[Consumes( MediaTypeNames.Application.Json )]
	[Produces( MediaTypeNames.Application.Json, MediaTypeNames.Application.Xml )]
	[ProducesResponseType( typeof( string ), 201 )]
	[ProducesResponseType( typeof( ProblemDetails ), 403 )]
	public async Task<IActionResult> CreateQuest( [FromBody] CreateQuestDto dto )
	{
		var quest = await _questsService.CreateQuest( dto );

		return CreatedAtAction( nameof( GetQuest ), new { quest.Id }, quest );
	}

	// DELETE api/quests/1
	[HttpDelete( "{id}" )]
	[Authorize( Roles = Constants.Auth.SuperAdminRole )]

	[Produces( MediaTypeNames.Application.Json, MediaTypeNames.Application.Xml )]
	[ProducesResponseType( 204 )]
	[ProducesResponseType( typeof( ProblemDetails ), 403 )]
	[ProducesResponseType( typeof( ProblemDetails ), 404 )]
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


	// POST api/quests/1/begin
	[HttpPost( "{id}/begin" )]

	[Produces( MediaTypeNames.Application.Json, MediaTypeNames.Application.Xml )]
	[ProducesResponseType( 204 )]
	[ProducesResponseType( typeof( ProblemDetails ), 404 )]
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

	[Produces( MediaTypeNames.Application.Json, MediaTypeNames.Application.Xml )]
	[ProducesResponseType( typeof( GetQuestDto[] ), 200 )]
	public async Task<ActionResult<GetUserQuestDto[]>> GetBegun( [FromQuery] int[] ids )
	{
		var uuid = User.GetUuid();
		if ( uuid is null )
		{
			return InternalServerError( "Error occured" );
		}

		if ( ids.Length > 0 )
		{
			return await _questsService.GetBegun( uuid, ids );
		}

		return await _questsService.GetBegun( uuid );
	}

	// GET api/quests/begun
	[HttpGet( "begun/{id}" )]

	[Produces( MediaTypeNames.Application.Json, MediaTypeNames.Application.Xml )]
	[ProducesResponseType( typeof( GetQuestDto ), 200 )]
	[ProducesResponseType( typeof( ProblemDetails ), 404 )]
	public async Task<ActionResult<GetUserQuestDto>> GetBegun( int id )
	{
		var uuid = User.GetUuid();
		if ( uuid is null )
		{
			return InternalServerError( "Error occured" );
		}

		var userQuest = await _questsService.GetBegun( uuid, id );
		if ( userQuest is null )
		{
			return NotFound();
		}

		return userQuest;
	}


}
