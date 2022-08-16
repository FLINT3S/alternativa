using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Migrations
{
    public partial class added_salted_passwords : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Characters_Accounts_AccountSocialClubId1",
                table: "Characters");

            migrationBuilder.DropIndex(
                name: "IX_Characters_AccountSocialClubId",
                table: "Characters");

            migrationBuilder.DropIndex(
                name: "IX_Characters_AccountSocialClubId1",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "AccountSocialClubId1",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Accounts");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_AccountSocialClubId",
                table: "Characters",
                column: "AccountSocialClubId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Characters_AccountSocialClubId",
                table: "Characters");

            migrationBuilder.AddColumn<decimal>(
                name: "AccountSocialClubId1",
                table: "Characters",
                type: "numeric(20,0)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Accounts",
                type: "text",
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

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_Accounts_AccountSocialClubId1",
                table: "Characters",
                column: "AccountSocialClubId1",
                principalTable: "Accounts",
                principalColumn: "SocialClubId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
