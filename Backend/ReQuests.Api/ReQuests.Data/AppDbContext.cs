using Microsoft.EntityFrameworkCore;
using ReQuests.Domain.Models;
using ReQuests.Domain.Relations;

namespace ReQuests.Data;

public class AppDbContext : DbContext
{
	public AppDbContext( DbContextOptions options )
		: base( options )
	{
		ArgumentNullException.ThrowIfNull( Users );
		ArgumentNullException.ThrowIfNull( Tokens );
		ArgumentNullException.ThrowIfNull( Roles );
		ArgumentNullException.ThrowIfNull( UsersRoles );
	}

	protected override void OnModelCreating( ModelBuilder modelBuilder )
	{
		_ = modelBuilder.Entity<TokenModel>()
			.HasOne( t => t.User )
			.WithMany( u => u.Tokens )
			.HasForeignKey( t => t.UserUuid )
			.HasPrincipalKey( u => u.Uuid );

		// user <=_=> role
		_ = modelBuilder.Entity<RoleModel>()
			.HasMany( r => r.Users )
			.WithMany( u => u.Roles )
			.UsingEntity<UserRoleRelation>(
			j =>
			{
				return j.HasOne( t => t.User )
				.WithMany( r => r.RolesR )
				.HasForeignKey( r => r.UserUuid )
				.HasPrincipalKey( u => u.Uuid );
			},
			j =>
			{
				return j.HasOne( t => t.Role )
				.WithMany( r => r.UsersR )
				.HasForeignKey( r => r.RoleId );
			} );
	}


	public DbSet<UserModel> Users { get; set; }
	public DbSet<TokenModel> Tokens { get; set; }
	public DbSet<RoleModel> Roles { get; set; }
	public DbSet<UserRoleRelation> UsersRoles { get; set; }
}
