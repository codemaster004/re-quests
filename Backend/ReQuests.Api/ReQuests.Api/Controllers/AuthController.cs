using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReQuests.Api.Controllers.Attributes;
using ReQuests.Domain.Dtos.Token;
using ReQuests.Domain.Dtos.User;

using MtnA = System.Net.Mime.MediaTypeNames.Application;

namespace ReQuests.Api.Controllers;

[ApiController]
[Route( "auth" )]
public class AuthController : ExtendedControllerBase
{
	private readonly IAuthService _authService;

	public AuthController( IAuthService authService )
	{
		_authService = authService;
	}

	// POST auth/login
	[HttpPost( "login" )]

	[Consumes( MtnA.Json )]
	[Produces( MtnA.Json, MtnA.Xml )]
	[Produces200( typeof( GetTokenDto ) )]
	[ProducesProblem( 401 )]
	public async Task<ActionResult<GetTokenDto>> LogIn( [FromBody] LoginDto data )
	{
		try
		{
			return await _authService.LogInAsync( data.Username, data.Password );
		}
		catch ( NotFoundException )
		{
			return Unauthorized( "Invalid username" );
		}
		catch ( AuthorizationException )
		{
			return Unauthorized( "Invalid password" );
		}
	}


}
