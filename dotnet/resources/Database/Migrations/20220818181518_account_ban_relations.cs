using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Migrations
{
    public partial class account_ban_relations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "AccountId",
                table: "Bans",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "GivenToSocialClubId",
                table: "Bans",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bans_AccountId",
                table: "Bans",
                column: "AccountId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bans_GivenToSocialClubId",
                table: "Bans",
                column: "GivenToSocialClubId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bans_Accounts_AccountId",
                table: "Bans",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "SocialClubId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Bans_Accounts_GivenToSocialClubId",
                table: "Bans",
                column: "GivenToSocialClubId",
                principalTable: "Accounts",
                principalColumn: "SocialClubId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bans_Accounts_AccountId",
                table: "Bans");

            migrationBuilder.DropForeignKey(
                name: "FK_Bans_Accounts_GivenToSocialClubId",
                table: "Bans");

            migrationBuilder.DropIndex(
                name: "IX_Bans_AccountId",
                table: "Bans");

            migrationBuilder.DropIndex(
                name: "IX_Bans_GivenToSocialClubId",
                table: "Bans");

            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "Bans");

            migrationBuilder.DropColumn(
                name: "GivenToSocialClubId",
                table: "Bans");
        }
    }
}
