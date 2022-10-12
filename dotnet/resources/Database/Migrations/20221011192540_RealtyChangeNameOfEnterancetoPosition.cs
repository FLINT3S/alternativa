using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Migrations
{
    public partial class RealtyChangeNameOfEnterancetoPosition : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Entrance",
                table: "Entrances");

            migrationBuilder.AddColumn<string>(
                name: "Position",
                table: "Entrances",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Position",
                table: "Entrances");

            migrationBuilder.AddColumn<string>(
                name: "Entrance",
                table: "Entrances",
                type: "text",
                nullable: true);
        }
    }
}