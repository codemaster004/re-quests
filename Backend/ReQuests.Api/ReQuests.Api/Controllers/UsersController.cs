using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReQuests.Api.Extensions;
using ReQuests.Domain.Dtos.User;

namespace ReQuests.Api.Controllers;

[ApiController]
[Authorize]
[Route( "api/[controller]" )]
public class UsersController : ExtendedControllerBase
{
	private readonly IUsersService _usersService;

	public UsersController( IUsersService usersService )
	{
		_usersService = usersService;
	}

	[HttpGet]
	[Authorize( Roles = Constants.Auth.SuperAdminRole )]
	public async Task<ActionResult<GetUserDto[]>> GetUsers()
	{
		return await _usersService.GetUsersAsync();
	}

	[HttpGet( "{uuid}" )]
	[Authorize( Roles = Constants.Auth.SuperAdminRole )]
	public async Task<ActionResult<GetUserDto>> GetUser( string uuid )
	{
		var user = await _usersService.GetUserAsync( uuid );
		if ( user is null )
		{
			return NotFound();
		}

		return user;
	}

	[HttpPost]
	[AllowAnonymous]
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

	[HttpDelete( "{uuid}" )]
	[Authorize( Roles = Constants.Auth.SuperAdminRole )]
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


	[HttpGet( "me" )]
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
			return NotFound();
		}

		return user;
	}

	[HttpDelete( "me" )]
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
