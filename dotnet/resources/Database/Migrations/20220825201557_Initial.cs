using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Database.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccountEvents",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    DateTime = table.Column<DateTime>(nullable: false),
                    Ip = table.Column<string>(nullable: true),
                    HWID = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    Type = table.Column<int>(nullable: true),
                    AccountSocialClubId = table.Column<decimal>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountEvents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bans",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    Reason = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    GivenBySocialClubId = table.Column<decimal>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    AccountId = table.Column<decimal>(nullable: true),
                    HWID = table.Column<string>(nullable: true),
                    GivenToSocialClubId = table.Column<decimal>(nullable: true),
                    Duration = table.Column<TimeSpan>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bans", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Characters",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    AccountSocialClubId = table.Column<decimal>(nullable: true),
                    LastPosition = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Birthday = table.Column<DateTime>(nullable: false),
                    Cash = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    SocialClubId = table.Column<decimal>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    Username = table.Column<string>(nullable: true),
                    PasswordHash = table.Column<string>(nullable: true),
                    PasswordSalt = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    LastHwid = table.Column<string>(nullable: true),
                    ActiveCharacterId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.SocialClubId);
                    table.ForeignKey(
                        name: "FK_Accounts_Characters_ActiveCharacterId",
                        column: x => x.ActiveCharacterId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccountEvents_AccountSocialClubId",
                table: "AccountEvents",
                column: "AccountSocialClubId");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_ActiveCharacterId",
                table: "Accounts",
                column: "ActiveCharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_Bans_GivenBySocialClubId",
                table: "Bans",
                column: "GivenBySocialClubId");

            migrationBuilder.CreateIndex(
                name: "IX_Bans_AccountId",
                table: "Bans",
                column: "AccountId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bans_GivenToSocialClubId",
                table: "Bans",
                column: "GivenToSocialClubId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_AccountSocialClubId",
                table: "Characters",
                column: "AccountSocialClubId");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountEvents_Accounts_AccountSocialClubId",
                table: "AccountEvents",
                column: "AccountSocialClubId",
                principalTable: "Accounts",
                principalColumn: "SocialClubId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Bans_Accounts_GivenBySocialClubId",
                table: "Bans",
                column: "GivenBySocialClubId",
                principalTable: "Accounts",
                principalColumn: "SocialClubId",
                onDelete: ReferentialAction.Restrict);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_Accounts_AccountSocialClubId",
                table: "Characters",
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

            migrationBuilder.DropTable(
                name: "AccountEvents");

            migrationBuilder.DropTable(
                name: "Bans");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "Characters");
        }
    }
}
