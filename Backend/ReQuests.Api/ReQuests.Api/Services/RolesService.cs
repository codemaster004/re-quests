using Microsoft.EntityFrameworkCore;
using ReQuests.Data;
using ReQuests.Domain.Models;

namespace ReQuests.Api.Services;

public interface IRolesService
{
	Task<RoleModel> CreateRole( string name );
}

public class RolesService : IRolesService
{
	private readonly AppDbContext _dbContext;

	public RolesService( AppDbContext dbContext )
	{
		_dbContext = dbContext;
	}


	public async Task<RoleModel> CreateRole( string name )
	{
		if ( await _dbContext.Roles.Where( r => r.Name == name ).AnyAsync() )
		{
			throw new ConflictException();
		}

		RoleModel role = new( name );
		_ = _dbContext.Roles.Add( role );
		_ = await _dbContext.SaveChangesAsync();

		return role;
	}
}
