using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReQuests.Migrations.Pg.Migrations
{
    public partial class RemovedQuestDuration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
			_ = migrationBuilder.DropColumn(
				name: "Duration",
				table: "Quests" );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
			_ = migrationBuilder.AddColumn<string>(
				name: "Duration",
				table: "Quests",
				type: "text",
				nullable: false,
				defaultValue: "" );
        }
    }
}
