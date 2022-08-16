using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Migrations
{
    public partial class account_character_relationships : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Characters_AccountSocialClubId",
                table: "Characters");

            migrationBuilder.AddColumn<decimal>(
                name: "AccountSocialClubId1",
                table: "Characters",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ActiveCharacterId",
                table: "Accounts",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Characters_AccountSocialClubId",
                table: "Characters",
                column: "AccountSocialClubId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Characters_AccountSocialClubId1",
                table: "Characters",
                column: "AccountSocialClubId1");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_ActiveCharacterId",
                table: "Accounts",
                column: "ActiveCharacterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Characters_ActiveCharacterId",
                table: "Accounts",
                column: "ActiveCharacterId",
                principalTable: "Characters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_Accounts_AccountSocialClubId1",
                table: "Characters",
                column: "AccountSocialClubId1",
                principalTable: "Accounts",
                principalColumn: "SocialClubId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Characters_ActiveCharacterId",
                table: "Accounts");

            migrationBuilder.DropForeignKey(
                name: "FK_Characters_Accounts_AccountSocialClubId1",
                table: "Characters");

            migrationBuilder.DropIndex(
                name: "IX_Characters_AccountSocialClubId",
                table: "Characters");

            migrationBuilder.DropIndex(
                name: "IX_Characters_AccountSocialClubId1",
                table: "Characters");

            migrationBuilder.DropIndex(
                name: "IX_Accounts_ActiveCharacterId",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "AccountSocialClubId1",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "ActiveCharacterId",
                table: "Accounts");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_AccountSocialClubId",
                table: "Characters",
                column: "AccountSocialClubId");
        }
    }
}
