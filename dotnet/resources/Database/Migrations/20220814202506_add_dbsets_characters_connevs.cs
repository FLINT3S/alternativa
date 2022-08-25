using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Migrations
{
    public partial class add_dbsets_characters_connevs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Character_Accounts_AccountSocialClubId",
                table: "Character");

            migrationBuilder.DropForeignKey(
                name: "FK_ConnectionEvent_Accounts_AccountSocialClubId",
                table: "ConnectionEvent");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ConnectionEvent",
                table: "ConnectionEvent");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Character",
                table: "Character");

            migrationBuilder.RenameTable(
                name: "ConnectionEvent",
                newName: "ConnectionEvents");

            migrationBuilder.RenameTable(
                name: "Character",
                newName: "Characters");

            migrationBuilder.RenameIndex(
                name: "IX_ConnectionEvent_AccountSocialClubId",
                table: "ConnectionEvents",
                newName: "IX_ConnectionEvents_AccountSocialClubId");

            migrationBuilder.RenameIndex(
                name: "IX_Character_AccountSocialClubId",
                table: "Characters",
                newName: "IX_Characters_AccountSocialClubId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ConnectionEvents",
                table: "ConnectionEvents",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Characters",
                table: "Characters",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_Accounts_AccountSocialClubId",
                table: "Characters",
                column: "AccountSocialClubId",
                principalTable: "Accounts",
                principalColumn: "SocialClubId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ConnectionEvents_Accounts_AccountSocialClubId",
                table: "ConnectionEvents",
                column: "AccountSocialClubId",
                principalTable: "Accounts",
                principalColumn: "SocialClubId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Characters_Accounts_AccountSocialClubId",
                table: "Characters");

            migrationBuilder.DropForeignKey(
                name: "FK_ConnectionEvents_Accounts_AccountSocialClubId",
                table: "ConnectionEvents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ConnectionEvents",
                table: "ConnectionEvents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Characters",
                table: "Characters");

            migrationBuilder.RenameTable(
                name: "ConnectionEvents",
                newName: "ConnectionEvent");

            migrationBuilder.RenameTable(
                name: "Characters",
                newName: "Character");

            migrationBuilder.RenameIndex(
                name: "IX_ConnectionEvents_AccountSocialClubId",
                table: "ConnectionEvent",
                newName: "IX_ConnectionEvent_AccountSocialClubId");

            migrationBuilder.RenameIndex(
                name: "IX_Characters_AccountSocialClubId",
                table: "Character",
                newName: "IX_Character_AccountSocialClubId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ConnectionEvent",
                table: "ConnectionEvent",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Character",
                table: "Character",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Character_Accounts_AccountSocialClubId",
                table: "Character",
                column: "AccountSocialClubId",
                principalTable: "Accounts",
                principalColumn: "SocialClubId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ConnectionEvent_Accounts_AccountSocialClubId",
                table: "ConnectionEvent",
                column: "AccountSocialClubId",
                principalTable: "Accounts",
                principalColumn: "SocialClubId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
