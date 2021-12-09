using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ReQuests.Api.Auth.Attributes;

[AttributeUsage( AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = true )]
sealed class SuperAdminOnlyAttribute : AuthorizeAttribute
{
	public SuperAdminOnlyAttribute()
		: base()
	{
		Roles = Constants.Auth.SuperAdminRole;
	}
}
