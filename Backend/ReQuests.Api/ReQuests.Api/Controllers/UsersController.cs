using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReQuests.Api.Extensions;
using ReQuests.Domain.Dtos.User;
using System.Net.Mime;

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
	[Authorize( Roles = Constants.Auth.SuperAdminRole )]

	[Produces( MediaTypeNames.Application.Json, MediaTypeNames.Application.Xml )]
	[ProducesResponseType( typeof( GetUserDto[] ), 200 )]
	[ProducesResponseType( typeof( ProblemDetails ), 403 )]
	public async Task<ActionResult<GetUserDto[]>> GetUsers()
	{
		return await _usersService.GetUsersAsync();
	}

	// GET api/users/12ab==
	[HttpGet( "{uuid}" )]
	[Authorize( Roles = Constants.Auth.SuperAdminRole )]

	[Produces( MediaTypeNames.Application.Json, MediaTypeNames.Application.Xml )]
	[ProducesResponseType( typeof( GetUserDto ), 200 )]
	[ProducesResponseType( typeof( ProblemDetails ), 403 )]
	[ProducesResponseType( typeof( ProblemDetails ), 404 )]
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

	[Consumes( MediaTypeNames.Application.Json )]
	[Produces( MediaTypeNames.Application.Json, MediaTypeNames.Application.Xml )]
	[ProducesResponseType( typeof( string ), 201 )]
	[ProducesResponseType( typeof( ProblemDetails ), 409 )]
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
	[Authorize( Roles = Constants.Auth.SuperAdminRole )]

	[Produces( MediaTypeNames.Application.Json, MediaTypeNames.Application.Xml )]
	[ProducesResponseType( 204 )]
	[ProducesResponseType( typeof( ProblemDetails ), 403 )]
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

	[Produces( MediaTypeNames.Application.Json, MediaTypeNames.Application.Xml )]
	[ProducesResponseType( typeof( GetUserDto ), 200 )]
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

	[Produces( MediaTypeNames.Application.Json, MediaTypeNames.Application.Xml )]
	[ProducesResponseType( 204 )]
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
