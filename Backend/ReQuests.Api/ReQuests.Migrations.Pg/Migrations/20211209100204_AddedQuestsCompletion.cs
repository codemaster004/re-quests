using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReQuests.Migrations.Pg.Migrations
{
    public partial class AddedQuestsCompletion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
			_ = migrationBuilder.AddColumn<int>(
				name: "Attempts",
				table: "UsersQuests",
				type: "integer",
				nullable: false,
				defaultValue: 1 );

			_ = migrationBuilder.AddColumn<DateTimeOffset>(
				name: "DateCompleted",
				table: "UsersQuests",
				type: "timestamp with time zone",
				nullable: true );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
			_ = migrationBuilder.DropColumn(
				name: "Attempts",
				table: "UsersQuests" );

			_ = migrationBuilder.DropColumn(
				name: "DateCompleted",
				table: "UsersQuests" );
        }
    }
}
