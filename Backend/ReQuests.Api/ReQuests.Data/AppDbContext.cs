using Microsoft.EntityFrameworkCore;
using ReQuests.Data.Converters;
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
		ArgumentNullException.ThrowIfNull( Quests );
		ArgumentNullException.ThrowIfNull( UsersQuests );
	}

	protected override void OnModelCreating( ModelBuilder modelBuilder )
	{
		_ = modelBuilder.Entity<UserQuestRelation>()
			.Property( q => q.Attempts )
			.HasDefaultValue( 1 );

		// user <= token
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
				return j.HasOne( ur => ur.User )
				.WithMany( u => u.RolesR )
				.HasForeignKey( ur => ur.UserUuid )
				.HasPrincipalKey( u => u.Uuid );
			},
			j =>
			{
				return j.HasOne( ur => ur.Role )
				.WithMany( r => r.UsersR )
				.HasForeignKey( ur => ur.RoleId );
			} );

		// user <=_=> quest
		_ = modelBuilder.Entity<QuestModel>()
			.HasMany( q => q.Users )
			.WithMany( u => u.Quests )
			.UsingEntity<UserQuestRelation>(
			j =>
			{
				return j.HasOne( uq => uq.User )
				.WithMany( u => u.QuestsR )
				.HasForeignKey( uq => uq.UserUuid )
				.HasPrincipalKey( u => u.Uuid );
			},
			j =>
			{
				return j.HasOne( uq => uq.Quest )
				.WithMany( q => q.UsersR )
				.HasForeignKey( uq => uq.QuestId );
			} );
	}


	public DbSet<UserModel> Users { get; set; }
	public DbSet<TokenModel> Tokens { get; set; }
	public DbSet<RoleModel> Roles { get; set; }
	public DbSet<UserRoleRelation> UsersRoles { get; set; }
	public DbSet<QuestModel> Quests { get; set; }
	public DbSet<UserQuestRelation> UsersQuests { get; set; }
}
