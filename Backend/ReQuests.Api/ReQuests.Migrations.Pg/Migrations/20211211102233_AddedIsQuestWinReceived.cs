using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReQuests.Migrations.Pg.Migrations
{
    public partial class AddedIsQuestWinReceived : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
			_ = migrationBuilder.AddColumn<bool>(
				name: "WasWinReceived",
				table: "UsersQuests",
				type: "boolean",
				nullable: false,
				defaultValue: false );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
			_ = migrationBuilder.DropColumn(
				name: "WasWinReceived",
				table: "UsersQuests" );
        }
    }
}
