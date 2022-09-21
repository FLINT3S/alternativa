using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Migrations
{
    public partial class AccessRights : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AdminLevel",
                table: "Accounts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "VipLevel",
                table: "Accounts",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdminLevel",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "VipLevel",
                table: "Accounts");
        }
    }
}
