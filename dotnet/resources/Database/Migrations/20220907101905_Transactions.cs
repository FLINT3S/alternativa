using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Migrations
{
    public partial class Transactions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "BankTransactions",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "BankTransactions");
        }
    }
}
