using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Migrations
{
    public partial class added_last_position : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LastPosition",
                table: "Characters",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastPosition",
                table: "Characters");
        }
    }
}
