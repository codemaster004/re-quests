using Microsoft.EntityFrameworkCore;
using ReQuests.Domain.Models;

namespace ReQuests.Data;

public class AppDbContext : DbContext
{
	public AppDbContext( DbContextOptions options ) 
		: base( options )
	{
		ArgumentNullException.ThrowIfNull( Users );
	}

	public DbSet<UserModel> Users { get; set; }
}
