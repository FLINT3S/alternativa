using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Migrations
{
    public partial class timespans : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndTime",
                table: "Bans");

            migrationBuilder.AddColumn<TimeSpan>(
                name: "Duration",
                table: "Bans",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Duration",
                table: "Bans");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndTime",
                table: "Bans",
                type: "timestamp without time zone",
                nullable: true);
        }
    }
}
