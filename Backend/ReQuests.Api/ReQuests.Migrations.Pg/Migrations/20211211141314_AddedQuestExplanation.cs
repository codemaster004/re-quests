using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReQuests.Migrations.Pg.Migrations
{
    public partial class AddedQuestExplanation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
			_ = migrationBuilder.AddColumn<string>(
				name: "Explanation",
				table: "Quests",
				type: "text",
				nullable: false,
				defaultValue: "" );

			_ = migrationBuilder.AddColumn<string>(
				name: "ImageUrl",
				table: "Quests",
				type: "text",
				nullable: false,
				defaultValue: "" );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
			_ = migrationBuilder.DropColumn(
				name: "Explanation",
				table: "Quests" );

			_ = migrationBuilder.DropColumn(
				name: "ImageUrl",
				table: "Quests" );
        }
    }
}
