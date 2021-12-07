using Microsoft.EntityFrameworkCore;
using ReQuests.Domain.Models;

namespace ReQuests.Data;

public class AppDbContext : DbContext
{
	public AppDbContext( DbContextOptions options )
		: base( options )
	{
		ArgumentNullException.ThrowIfNull( Users );
		ArgumentNullException.ThrowIfNull( Tokens );
	}

	protected override void OnModelCreating( ModelBuilder modelBuilder )
	{
		_ = modelBuilder.Entity<TokenModel>()
			.HasOne( t => t.User )
			.WithMany( u => u.Tokens )
			.HasForeignKey( t => t.UserUuid )
			.HasPrincipalKey( u => u.Uuid );
	}


	public DbSet<UserModel> Users { get; set; }
	public DbSet<TokenModel> Tokens { get; set; }
}
