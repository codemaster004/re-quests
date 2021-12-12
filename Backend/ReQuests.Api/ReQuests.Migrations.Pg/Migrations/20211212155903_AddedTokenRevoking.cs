using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReQuests.Migrations.Pg.Migrations
{
    public partial class AddedTokenRevoking : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
			_ = migrationBuilder.AddColumn<bool>(
				name: "Revoked",
				table: "Tokens",
				type: "boolean",
				nullable: false,
				defaultValue: false );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
			_ = migrationBuilder.DropColumn(
				name: "Revoked",
				table: "Tokens" );
        }
    }
}
