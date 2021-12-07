using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ReQuests.Migrations.Pg.Migrations
{
    public partial class AddedUserModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
			_ = migrationBuilder.CreateTable(
				name: "Users",
				columns: table => new
				{
					Id = table.Column<int>( type: "integer", nullable: false )
						.Annotation( "Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn ),
					Uuid = table.Column<string>( type: "text", nullable: false ),
					Username = table.Column<string>( type: "text", nullable: false ),
					Email = table.Column<string>( type: "text", nullable: false ),
					PasswordHash = table.Column<string>( type: "text", nullable: false )
				},
				constraints: table =>
				{
					_ = table.PrimaryKey( "PK_Users", x => x.Id );
				} );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
			_ = migrationBuilder.DropTable(
				name: "Users" );
        }
    }
}
