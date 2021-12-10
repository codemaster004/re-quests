using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReQuests.Migrations.Pg.Migrations
{
    public partial class ReaddedQuestDuration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
			_ = migrationBuilder.AddColumn<TimeSpan>(
				name: "Duration",
				table: "Quests",
				type: "interval",
				nullable: false,
				defaultValue: new TimeSpan( 0, 0, 0, 0, 0 ) );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
			_ = migrationBuilder.DropColumn(
				name: "Duration",
				table: "Quests" );
        }
    }
}
