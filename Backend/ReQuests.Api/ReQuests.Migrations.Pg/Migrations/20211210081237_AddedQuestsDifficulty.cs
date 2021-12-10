using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReQuests.Migrations.Pg.Migrations
{
    public partial class AddedQuestsDifficulty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
			_ = migrationBuilder.AddColumn<int>(
				name: "Difficulty",
				table: "Quests",
				type: "integer",
				nullable: false,
				defaultValue: 0 );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
			_ = migrationBuilder.DropColumn(
				name: "Difficulty",
				table: "Quests" );
        }
    }
}
