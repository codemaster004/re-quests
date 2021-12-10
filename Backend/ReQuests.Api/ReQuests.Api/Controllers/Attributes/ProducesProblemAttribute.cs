using Microsoft.AspNetCore.Mvc;

namespace ReQuests.Api.Controllers.Attributes;

[AttributeUsage( AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = true )]
sealed class ProducesProblemAttribute : ProducesResponseTypeAttribute
{
	public ProducesProblemAttribute( int statusCode )
		: base( typeof( ProblemDetails ), statusCode )
	{
	}

	public ProducesProblemAttribute( int statusCode, string contentType, params string[] additionalContentTypes )
		: base( typeof( ProblemDetails ), statusCode, contentType, additionalContentTypes )
	{
	}
}
