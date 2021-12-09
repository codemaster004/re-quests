using Microsoft.AspNetCore.Mvc;

namespace ReQuests.Api.Controllers.Attributes;

[AttributeUsage( AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = true )]
sealed class Produces200Attribute : ProducesResponseTypeAttribute
{
	public Produces200Attribute( Type type )
		: base( type, 200 )
	{
	}

	public Produces200Attribute( Type type, string contentType, params string[] additionalContentTypes )
		: base( type, 200, contentType, additionalContentTypes )
	{
	}
}
