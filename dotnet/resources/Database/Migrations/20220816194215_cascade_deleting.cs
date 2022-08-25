using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Migrations
{
    public partial class cascade_deleting : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Characters_Accounts_AccountSocialClubId",
                table: "Characters");

            migrationBuilder.DropForeignKey(
                name: "FK_ConnectionEvents_Accounts_AccountSocialClubId",
                table: "ConnectionEvents");

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_Accounts_AccountSocialClubId",
                table: "Characters",
                column: "AccountSocialClubId",
                principalTable: "Accounts",
                principalColumn: "SocialClubId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ConnectionEvents_Accounts_AccountSocialClubId",
                table: "ConnectionEvents",
                column: "AccountSocialClubId",
                principalTable: "Accounts",
                principalColumn: "SocialClubId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Characters_Accounts_AccountSocialClubId",
                table: "Characters");

            migrationBuilder.DropForeignKey(
                name: "FK_ConnectionEvents_Accounts_AccountSocialClubId",
                table: "ConnectionEvents");

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_Accounts_AccountSocialClubId",
                table: "Characters",
                column: "AccountSocialClubId",
                principalTable: "Accounts",
                principalColumn: "SocialClubId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ConnectionEvents_Accounts_AccountSocialClubId",
                table: "ConnectionEvents",
                column: "AccountSocialClubId",
                principalTable: "Accounts",
                principalColumn: "SocialClubId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
