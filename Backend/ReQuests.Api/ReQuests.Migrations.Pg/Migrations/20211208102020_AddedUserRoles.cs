using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ReQuests.Migrations.Pg.Migrations
{
    public partial class AddedUserRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
			_ = migrationBuilder.CreateTable(
				name: "Roles",
				columns: table => new
				{
					Id = table.Column<int>( type: "integer", nullable: false )
						.Annotation( "Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn ),
					Name = table.Column<string>( type: "text", nullable: false )
				},
				constraints: table =>
				{
					_ = table.PrimaryKey( "PK_Roles", x => x.Id );
				} );

			_ = migrationBuilder.CreateTable(
				name: "UsersRoles",
				columns: table => new
				{
					Id = table.Column<int>( type: "integer", nullable: false )
						.Annotation( "Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn ),
					UserUuid = table.Column<string>( type: "text", nullable: false ),
					RoleId = table.Column<int>( type: "integer", nullable: false )
				},
				constraints: table =>
				{
					_ = table.PrimaryKey( "PK_UsersRoles", x => x.Id );
					_ = table.ForeignKey(
						name: "FK_UsersRoles_Roles_RoleId",
						column: x => x.RoleId,
						principalTable: "Roles",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade );
					_ = table.ForeignKey(
						name: "FK_UsersRoles_Users_UserUuid",
						column: x => x.UserUuid,
						principalTable: "Users",
						principalColumn: "Uuid",
						onDelete: ReferentialAction.Cascade );
				} );

			_ = migrationBuilder.CreateIndex(
				name: "IX_UsersRoles_RoleId",
				table: "UsersRoles",
				column: "RoleId" );

			_ = migrationBuilder.CreateIndex(
				name: "IX_UsersRoles_UserUuid",
				table: "UsersRoles",
				column: "UserUuid" );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
			_ = migrationBuilder.DropTable(
				name: "UsersRoles" );

			_ = migrationBuilder.DropTable(
				name: "Roles" );
        }
    }
}
