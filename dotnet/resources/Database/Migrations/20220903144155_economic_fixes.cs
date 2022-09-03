using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Migrations
{
    public partial class economic_fixes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "MainBankAccountId",
                table: "Characters",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Sex",
                table: "Characters",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "Rate",
                table: "BankAccounts",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "BankAccounts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Characters_MainBankAccountId",
                table: "Characters",
                column: "MainBankAccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_BankAccounts_MainBankAccountId",
                table: "Characters",
                column: "MainBankAccountId",
                principalTable: "BankAccounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Characters_BankAccounts_MainBankAccountId",
                table: "Characters");

            migrationBuilder.DropIndex(
                name: "IX_Characters_MainBankAccountId",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "MainBankAccountId",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "Sex",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "Rate",
                table: "BankAccounts");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "BankAccounts");
        }
    }
}
