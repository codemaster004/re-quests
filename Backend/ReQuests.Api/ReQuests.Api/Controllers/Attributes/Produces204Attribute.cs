using Microsoft.AspNetCore.Mvc;

namespace ReQuests.Api.Controllers.Attributes;

[AttributeUsage( AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = false )]
sealed class Produces204Attribute : ProducesResponseTypeAttribute
{
	public Produces204Attribute()
		: base( typeof( void ), 204 )
	{
	}
}
