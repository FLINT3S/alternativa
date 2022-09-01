using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Migrations
{
    public partial class removedLazyLoadingAndActiveCharacter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Characters_ActiveCharacterId",
                table: "Accounts");

            migrationBuilder.DropIndex(
                name: "IX_Accounts_ActiveCharacterId",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "ActiveCharacterId",
                table: "Accounts");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ActiveCharacterId",
                table: "Accounts",
                type: "uuid",
                nullable: true);

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
        }
    }
}
