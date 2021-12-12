using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReQuests.Migrations.Pg.Migrations
{
	public partial class AddedQuestAwardUrl : Migration
	{
		protected override void Up( MigrationBuilder migrationBuilder )
		{
			_ = migrationBuilder.AddColumn<string>(
				name: "AwardUrl",
				table: "Quests",
				type: "text",
				nullable: false,
				defaultValue: "" );

			_ = migrationBuilder.AddColumn<string>(
				name: "Color",
				table: "Quests",
				type: "character varying(20)",
				maxLength: 20,
				nullable: false,
				defaultValue: "" );
		}

		protected override void Down( MigrationBuilder migrationBuilder )
		{
			_ = migrationBuilder.DropColumn(
				name: "AwardUrl",
				table: "Quests" );

			_ = migrationBuilder.DropColumn(
				name: "Color",
				table: "Quests" );
		}
	}
}
