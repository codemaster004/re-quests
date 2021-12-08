using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ReQuests.Migrations.Pg.Migrations
{
    public partial class AddedQuests : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
			_ = migrationBuilder.CreateTable(
				name: "Quests",
				columns: table => new
				{
					Id = table.Column<int>( type: "integer", nullable: false )
						.Annotation( "Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn ),
					Name = table.Column<string>( type: "text", nullable: false ),
					Description = table.Column<string>( type: "text", nullable: false ),
					Duration = table.Column<string>( type: "text", nullable: false )
				},
				constraints: table =>
				{
					_ = table.PrimaryKey( "PK_Quests", x => x.Id );
				} );

			_ = migrationBuilder.CreateTable(
				name: "UsersQuests",
				columns: table => new
				{
					Id = table.Column<int>( type: "integer", nullable: false )
						.Annotation( "Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn ),
					UserUuid = table.Column<string>( type: "text", nullable: false ),
					QuestId = table.Column<int>( type: "integer", nullable: false ),
					DateStarted = table.Column<DateTimeOffset>( type: "timestamp with time zone", nullable: false )
				},
				constraints: table =>
				{
					_ = table.PrimaryKey( "PK_UsersQuests", x => x.Id );
					_ = table.ForeignKey(
						name: "FK_UsersQuests_Quests_QuestId",
						column: x => x.QuestId,
						principalTable: "Quests",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade );
					_ = table.ForeignKey(
						name: "FK_UsersQuests_Users_UserUuid",
						column: x => x.UserUuid,
						principalTable: "Users",
						principalColumn: "Uuid",
						onDelete: ReferentialAction.Cascade );
				} );

			_ = migrationBuilder.CreateIndex(
				name: "IX_UsersQuests_QuestId",
				table: "UsersQuests",
				column: "QuestId" );

			_ = migrationBuilder.CreateIndex(
				name: "IX_UsersQuests_UserUuid",
				table: "UsersQuests",
				column: "UserUuid" );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
			_ = migrationBuilder.DropTable(
				name: "UsersQuests" );

			_ = migrationBuilder.DropTable(
				name: "Quests" );
        }
    }
}
