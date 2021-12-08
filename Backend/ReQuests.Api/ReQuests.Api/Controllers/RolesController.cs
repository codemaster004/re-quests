using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReQuests.Domain.Models;
using System.Net.Mime;

namespace ReQuests.Api.Controllers;

[ApiController]
[Authorize( Constants.Auth.SuperAdminRole )]
[Route( "auth/[controller]" )]
public class RolesController : ControllerBase
{
	private readonly IRolesService _rolesService;

	public RolesController( IRolesService rolesService )
	{
		_rolesService = rolesService;
	}


	// POST auth/roles
	[HttpPost]

	[Produces( MediaTypeNames.Application.Json, MediaTypeNames.Application.Xml )]
	[ProducesResponseType( 204 )]
	[ProducesResponseType( typeof( ProblemDetails ), 409 )]
	public async Task<IActionResult> CreateRole( [FromBody] string name )
	{
		RoleModel role;
		try
		{
			role = await _rolesService.CreateRole( name );
		}
		catch ( ConflictException )
		{
			return Conflict( "role already exists" );
		}
		return NoContent();
	}
}
