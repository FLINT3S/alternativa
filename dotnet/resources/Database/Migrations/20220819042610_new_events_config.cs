using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Migrations
{
    public partial class new_events_config : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConnectionEvents_Accounts_AccountSocialClubId",
                table: "ConnectionEvents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ConnectionEvents",
                table: "ConnectionEvents");

            migrationBuilder.RenameTable(
                name: "ConnectionEvents",
                newName: "AccountEvents");

            migrationBuilder.RenameIndex(
                name: "IX_ConnectionEvents_AccountSocialClubId",
                table: "AccountEvents",
                newName: "IX_AccountEvents_AccountSocialClubId");

            migrationBuilder.AlterColumn<int>(
                name: "Type",
                table: "AccountEvents",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AccountEvents",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AccountEvents",
                table: "AccountEvents",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountEvents_Accounts_AccountSocialClubId",
                table: "AccountEvents",
                column: "AccountSocialClubId",
                principalTable: "Accounts",
                principalColumn: "SocialClubId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountEvents_Accounts_AccountSocialClubId",
                table: "AccountEvents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AccountEvents",
                table: "AccountEvents");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AccountEvents");

            migrationBuilder.RenameTable(
                name: "AccountEvents",
                newName: "ConnectionEvents");

            migrationBuilder.RenameIndex(
                name: "IX_AccountEvents_AccountSocialClubId",
                table: "ConnectionEvents",
                newName: "IX_ConnectionEvents_AccountSocialClubId");

            migrationBuilder.AlterColumn<int>(
                name: "Type",
                table: "ConnectionEvents",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ConnectionEvents",
                table: "ConnectionEvents",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ConnectionEvents_Accounts_AccountSocialClubId",
                table: "ConnectionEvents",
                column: "AccountSocialClubId",
                principalTable: "Accounts",
                principalColumn: "SocialClubId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
