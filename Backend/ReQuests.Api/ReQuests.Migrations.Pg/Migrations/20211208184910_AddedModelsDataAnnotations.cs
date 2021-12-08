using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReQuests.Migrations.Pg.Migrations
{
    public partial class AddedModelsDataAnnotations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
			_ = migrationBuilder.DropIndex(
				name: "IX_UsersRoles_UserUuid",
				table: "UsersRoles" );

			_ = migrationBuilder.DropIndex(
				name: "IX_UsersQuests_UserUuid",
				table: "UsersQuests" );

			_ = migrationBuilder.AlterColumn<string>(
				name: "UserUuid",
				table: "UsersRoles",
				type: "character varying(24)",
				nullable: false,
				oldClrType: typeof( string ),
				oldType: "text" );

			_ = migrationBuilder.AlterColumn<string>(
				name: "UserUuid",
				table: "UsersQuests",
				type: "character varying(24)",
				nullable: false,
				oldClrType: typeof( string ),
				oldType: "text" );

			_ = migrationBuilder.AlterColumn<string>(
				name: "Uuid",
				table: "Users",
				type: "character varying(24)",
				maxLength: 24,
				nullable: false,
				oldClrType: typeof( string ),
				oldType: "text" );

			_ = migrationBuilder.AlterColumn<string>(
				name: "Username",
				table: "Users",
				type: "character varying(50)",
				maxLength: 50,
				nullable: false,
				oldClrType: typeof( string ),
				oldType: "text" );

			_ = migrationBuilder.AlterColumn<string>(
				name: "Email",
				table: "Users",
				type: "character varying(50)",
				maxLength: 50,
				nullable: false,
				oldClrType: typeof( string ),
				oldType: "text" );

			_ = migrationBuilder.AlterColumn<string>(
				name: "UserUuid",
				table: "Tokens",
				type: "character varying(24)",
				nullable: false,
				oldClrType: typeof( string ),
				oldType: "text" );

			_ = migrationBuilder.AlterColumn<string>(
				name: "RefreshToken",
				table: "Tokens",
				type: "character varying(24)",
				maxLength: 24,
				nullable: false,
				oldClrType: typeof( string ),
				oldType: "text" );

			_ = migrationBuilder.AlterColumn<string>(
				name: "AccessToken",
				table: "Tokens",
				type: "character varying(24)",
				maxLength: 24,
				nullable: false,
				oldClrType: typeof( string ),
				oldType: "text" );

			_ = migrationBuilder.AlterColumn<string>(
				name: "Name",
				table: "Roles",
				type: "character varying(24)",
				maxLength: 24,
				nullable: false,
				oldClrType: typeof( string ),
				oldType: "text" );

			_ = migrationBuilder.AlterColumn<string>(
				name: "Name",
				table: "Quests",
				type: "character varying(24)",
				maxLength: 24,
				nullable: false,
				oldClrType: typeof( string ),
				oldType: "text" );

			_ = migrationBuilder.CreateIndex(
				name: "IX_UsersRoles_UserUuid_RoleId",
				table: "UsersRoles",
				columns: new[] { "UserUuid", "RoleId" },
				unique: true );

			_ = migrationBuilder.CreateIndex(
				name: "IX_UsersQuests_UserUuid_QuestId",
				table: "UsersQuests",
				columns: new[] { "UserUuid", "QuestId" },
				unique: true );

			_ = migrationBuilder.CreateIndex(
				name: "IX_Tokens_AccessToken",
				table: "Tokens",
				column: "AccessToken",
				unique: true );

			_ = migrationBuilder.CreateIndex(
				name: "IX_Tokens_RefreshToken",
				table: "Tokens",
				column: "RefreshToken",
				unique: true );

			_ = migrationBuilder.CreateIndex(
				name: "IX_Roles_Name",
				table: "Roles",
				column: "Name",
				unique: true );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
			_ = migrationBuilder.DropIndex(
				name: "IX_UsersRoles_UserUuid_RoleId",
				table: "UsersRoles" );

			_ = migrationBuilder.DropIndex(
				name: "IX_UsersQuests_UserUuid_QuestId",
				table: "UsersQuests" );

			_ = migrationBuilder.DropIndex(
				name: "IX_Tokens_AccessToken",
				table: "Tokens" );

			_ = migrationBuilder.DropIndex(
				name: "IX_Tokens_RefreshToken",
				table: "Tokens" );

			_ = migrationBuilder.DropIndex(
				name: "IX_Roles_Name",
				table: "Roles" );

			_ = migrationBuilder.AlterColumn<string>(
				name: "UserUuid",
				table: "UsersRoles",
				type: "text",
				nullable: false,
				oldClrType: typeof( string ),
				oldType: "character varying(24)" );

			_ = migrationBuilder.AlterColumn<string>(
				name: "UserUuid",
				table: "UsersQuests",
				type: "text",
				nullable: false,
				oldClrType: typeof( string ),
				oldType: "character varying(24)" );

			_ = migrationBuilder.AlterColumn<string>(
				name: "Uuid",
				table: "Users",
				type: "text",
				nullable: false,
				oldClrType: typeof( string ),
				oldType: "character varying(24)",
				oldMaxLength: 24 );

			_ = migrationBuilder.AlterColumn<string>(
				name: "Username",
				table: "Users",
				type: "text",
				nullable: false,
				oldClrType: typeof( string ),
				oldType: "character varying(50)",
				oldMaxLength: 50 );

			_ = migrationBuilder.AlterColumn<string>(
				name: "Email",
				table: "Users",
				type: "text",
				nullable: false,
				oldClrType: typeof( string ),
				oldType: "character varying(50)",
				oldMaxLength: 50 );

			_ = migrationBuilder.AlterColumn<string>(
				name: "UserUuid",
				table: "Tokens",
				type: "text",
				nullable: false,
				oldClrType: typeof( string ),
				oldType: "character varying(24)" );

			_ = migrationBuilder.AlterColumn<string>(
				name: "RefreshToken",
				table: "Tokens",
				type: "text",
				nullable: false,
				oldClrType: typeof( string ),
				oldType: "character varying(24)",
				oldMaxLength: 24 );

			_ = migrationBuilder.AlterColumn<string>(
				name: "AccessToken",
				table: "Tokens",
				type: "text",
				nullable: false,
				oldClrType: typeof( string ),
				oldType: "character varying(24)",
				oldMaxLength: 24 );

			_ = migrationBuilder.AlterColumn<string>(
				name: "Name",
				table: "Roles",
				type: "text",
				nullable: false,
				oldClrType: typeof( string ),
				oldType: "character varying(24)",
				oldMaxLength: 24 );

			_ = migrationBuilder.AlterColumn<string>(
				name: "Name",
				table: "Quests",
				type: "text",
				nullable: false,
				oldClrType: typeof( string ),
				oldType: "character varying(24)",
				oldMaxLength: 24 );

			_ = migrationBuilder.CreateIndex(
				name: "IX_UsersRoles_UserUuid",
				table: "UsersRoles",
				column: "UserUuid" );

			_ = migrationBuilder.CreateIndex(
				name: "IX_UsersQuests_UserUuid",
				table: "UsersQuests",
				column: "UserUuid" );
        }
    }
}
