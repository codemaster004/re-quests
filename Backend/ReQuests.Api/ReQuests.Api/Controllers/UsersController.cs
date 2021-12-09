using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReQuests.Api.Auth.Attributes;
using ReQuests.Api.Controllers.Attributes;
using ReQuests.Api.Extensions;
using ReQuests.Domain.Dtos.User;

using MtnA = System.Net.Mime.MediaTypeNames.Application;

namespace ReQuests.Api.Controllers;

[Authorize]
[ApiController]
[Route( "api/[controller]" )]
public class UsersController : ExtendedControllerBase
{
	private readonly IUsersService _usersService;

	public UsersController( IUsersService usersService )
	{
		_usersService = usersService;
	}

	// GET api/users
	[HttpGet]
	[SuperAdminOnly]

	[Produces( MtnA.Json, MtnA.Xml )]
	[Produces200( typeof( GetUserDto[] ) )]
	[ProducesProblem( 403 )]
	public async Task<ActionResult<GetUserDto[]>> GetUsers( [FromQuery] string[] uuids )
	{
		if ( uuids.Length > 0 )
		{
			return await _usersService.GetUsersAsync( uuids );
		}

		return await _usersService.GetUsersAsync();
	}

	// GET api/users/12ab==
	[HttpGet( "{uuid}" )]
	[SuperAdminOnly]

	[Produces( MtnA.Json, MtnA.Xml )]
	[Produces200( typeof( GetUserDto ) )]
	[ProducesProblem( 403 )]
	[ProducesProblem( 404 )]
	public async Task<ActionResult<GetUserDto>> GetUser( string uuid )
	{
		var user = await _usersService.GetUserAsync( uuid );
		if ( user is null )
		{
			return NotFound();
		}

		return user;
	}

	// POST api/users
	[HttpPost]
	[AllowAnonymous]

	[Consumes( MtnA.Json )]
	[Produces( MtnA.Json, MtnA.Xml )]
	[ProducesResponseType( typeof( string ), 201 )]
	[ProducesProblem( 409 )]
	public async Task<ActionResult<GetUserDto>> CreateUser( [FromBody] CreateUserDto dto )
	{
		GetUserDto user;
		try
		{
			user = await _usersService.CreateUserAsync( dto );
		}
		catch ( ConflictException e ) when ( e.Message == nameof( CreateUserDto.Email ) )
		{
			return Conflict( "There already exists account with this email" );
		}
		catch ( ConflictException e ) when ( e.Message == nameof( CreateUserDto.Username ) )
		{
			return Conflict( "There already exists account with this username" );
		}
		return CreatedAtAction( nameof( GetUser ), new { user.Uuid }, user );
	}

	// DELETE api/users/12ab==
	[HttpDelete( "{uuid}" )]
	[SuperAdminOnly]

	[Produces( MtnA.Json, MtnA.Xml )]
	[Produces204()]
	[ProducesProblem( 403 )]
	public async Task<IActionResult> DeleteUser( string uuid )
	{
		try
		{
			await _usersService.DeleteUserAsync( uuid );
		}
		catch ( NotFoundException )
		{
			return NotFound();
		}

		return NoContent();
	}


	// GET api/users/me
	[HttpGet( "me" )]

	[Produces( MtnA.Json, MtnA.Xml )]
	[Produces200( typeof( GetUserDto ) )]
	public async Task<ActionResult<GetUserDto>> GetCurrentUser()
	{
		var uuid = User.GetUuid();
		if ( uuid is null )
		{
			return InternalServerError( "Error occured" );
		}

		var user = await _usersService.GetUserAsync( uuid );
		if ( user is null )
		{
			return InternalServerError( "Error occured" );
		}

		return user;
	}

	// DELETE api/users/me
	[HttpDelete( "me" )]

	[Produces( MtnA.Json, MtnA.Xml )]
	[Produces204()]
	public async Task<IActionResult> DeleteCurrentUser()
	{
		var uuid = User.GetUuid();
		if ( uuid is null )
		{
			return InternalServerError( "Error occured" );
		}

		try
		{
			await _usersService.DeleteUserAsync( uuid );
		}
		catch ( NotFoundException )
		{
			return NotFound();
		}

		return NoContent();
	}

}
