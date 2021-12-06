using Microsoft.EntityFrameworkCore;

namespace ReQuests.Data;

public class AppDbContext : DbContext
{
	public AppDbContext( DbContextOptions options ) 
		: base( options )
	{
	}


}
