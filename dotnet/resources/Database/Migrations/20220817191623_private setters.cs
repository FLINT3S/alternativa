using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Migrations
{
    public partial class privatesetters : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateTime",
                table: "ConnectionEvents",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "ConnectionEvents",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HWID",
                table: "ConnectionEvents",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Ip",
                table: "ConnectionEvents",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "ConnectionEvents",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "Birthday",
                table: "Characters",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Characters",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Characters",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Characters",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Bans",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "GivenBySocialClubId",
                table: "Bans",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "Reason",
                table: "Bans",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Bans_GivenBySocialClubId",
                table: "Bans",
                column: "GivenBySocialClubId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bans_Accounts_GivenBySocialClubId",
                table: "Bans",
                column: "GivenBySocialClubId",
                principalTable: "Accounts",
                principalColumn: "SocialClubId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bans_Accounts_GivenBySocialClubId",
                table: "Bans");

            migrationBuilder.DropIndex(
                name: "IX_Bans_GivenBySocialClubId",
                table: "Bans");

            migrationBuilder.DropColumn(
                name: "DateTime",
                table: "ConnectionEvents");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "ConnectionEvents");

            migrationBuilder.DropColumn(
                name: "HWID",
                table: "ConnectionEvents");

            migrationBuilder.DropColumn(
                name: "Ip",
                table: "ConnectionEvents");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "ConnectionEvents");

            migrationBuilder.DropColumn(
                name: "Birthday",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Bans");

            migrationBuilder.DropColumn(
                name: "GivenBySocialClubId",
                table: "Bans");

            migrationBuilder.DropColumn(
                name: "Reason",
                table: "Bans");
        }
    }
}
