using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ReQuests.Migrations.Pg.Migrations
{
    public partial class AddedTokenModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
			_ = migrationBuilder.AddUniqueConstraint(
				name: "AK_Users_Uuid",
				table: "Users",
				column: "Uuid" );

			_ = migrationBuilder.CreateTable(
				name: "Tokens",
				columns: table => new
				{
					Id = table.Column<int>( type: "integer", nullable: false )
						.Annotation( "Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn ),
					UserUuid = table.Column<string>( type: "text", nullable: false ),
					AccessToken = table.Column<string>( type: "text", nullable: false ),
					RefreshToken = table.Column<string>( type: "text", nullable: false ),
					ValidUntil = table.Column<DateTimeOffset>( type: "timestamp with time zone", nullable: false )
				},
				constraints: table =>
				{
					_ = table.PrimaryKey( "PK_Tokens", x => x.Id );
					_ = table.ForeignKey(
						name: "FK_Tokens_Users_UserUuid",
						column: x => x.UserUuid,
						principalTable: "Users",
						principalColumn: "Uuid",
						onDelete: ReferentialAction.Cascade );
				} );

			_ = migrationBuilder.CreateIndex(
				name: "IX_Users_Email",
				table: "Users",
				column: "Email",
				unique: true );

			_ = migrationBuilder.CreateIndex(
				name: "IX_Users_Username",
				table: "Users",
				column: "Username",
				unique: true );

			_ = migrationBuilder.CreateIndex(
				name: "IX_Users_Uuid",
				table: "Users",
				column: "Uuid",
				unique: true );

			_ = migrationBuilder.CreateIndex(
				name: "IX_Tokens_UserUuid",
				table: "Tokens",
				column: "UserUuid" );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
			_ = migrationBuilder.DropTable(
				name: "Tokens" );

			_ = migrationBuilder.DropUniqueConstraint(
				name: "AK_Users_Uuid",
				table: "Users" );

			_ = migrationBuilder.DropIndex(
				name: "IX_Users_Email",
				table: "Users" );

			_ = migrationBuilder.DropIndex(
				name: "IX_Users_Username",
				table: "Users" );

			_ = migrationBuilder.DropIndex(
				name: "IX_Users_Uuid",
				table: "Users" );
        }
    }
}
