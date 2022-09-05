using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Database.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    LastHwid = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.SocialClubId);
                });

            migrationBuilder.CreateTable(
                name: "Bank",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    Money = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bank", x => x.Id);
                });

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
                    table.ForeignKey(
                        name: "FK_AccountEvents_Accounts_AccountSocialClubId",
                        column: x => x.AccountSocialClubId,
                        principalTable: "Accounts",
                        principalColumn: "SocialClubId",
                        onDelete: ReferentialAction.Cascade);
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
                    GivenToSocialClubId = table.Column<decimal>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bans_Accounts_GivenBySocialClubId",
                        column: x => x.GivenBySocialClubId,
                        principalTable: "Accounts",
                        principalColumn: "SocialClubId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Bans_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "SocialClubId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bans_Accounts_GivenToSocialClubId",
                        column: x => x.GivenToSocialClubId,
                        principalTable: "Accounts",
                        principalColumn: "SocialClubId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Characters",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    LastPosition = table.Column<string>(nullable: true),
                    TimeToReborn = table.Column<TimeSpan>(nullable: false),
                    Cash = table.Column<long>(nullable: false),
                    MainBankAccountId = table.Column<long>(nullable: true),
                    AccountSocialClubId = table.Column<decimal>(nullable: true),
                    InGameTime = table.Column<TimeSpan>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Sex = table.Column<int>(nullable: false),
                    Birthday = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Characters_Accounts_AccountSocialClubId",
                        column: x => x.AccountSocialClubId,
                        principalTable: "Accounts",
                        principalColumn: "SocialClubId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BankAccounts",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    Sum = table.Column<double>(nullable: false),
                    Rate = table.Column<double>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    OwnerId = table.Column<Guid>(nullable: true),
                    BankId1 = table.Column<long>(nullable: true),
                    BankId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankAccounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BankAccounts_Bank_BankId",
                        column: x => x.BankId,
                        principalTable: "Bank",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BankAccounts_Bank_BankId1",
                        column: x => x.BankId1,
                        principalTable: "Bank",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BankAccounts_Characters_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CharacterAppearance",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CharacterId = table.Column<Guid>(nullable: false),
                    MotherId = table.Column<int>(nullable: false),
                    FatherId = table.Column<int>(nullable: false),
                    Similarity = table.Column<float>(nullable: false),
                    SkinSimilarity = table.Column<float>(nullable: false),
                    FaceFeatures = table.Column<List<float>>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterAppearance", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CharacterAppearance_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CryptoWallets",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    Sum = table.Column<double>(nullable: false),
                    CharacterId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CryptoWallets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CryptoWallets_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BankTransactions",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    Sum = table.Column<double>(nullable: false),
                    FromId = table.Column<long>(nullable: true),
                    ToId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankTransactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BankTransactions_BankAccounts_FromId",
                        column: x => x.FromId,
                        principalTable: "BankAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BankTransactions_BankAccounts_ToId",
                        column: x => x.ToId,
                        principalTable: "BankAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CryptoTransactions",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    Sum = table.Column<double>(nullable: false),
                    FromId = table.Column<long>(nullable: true),
                    ToId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CryptoTransactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CryptoTransactions_CryptoWallets_FromId",
                        column: x => x.FromId,
                        principalTable: "CryptoWallets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CryptoTransactions_CryptoWallets_ToId",
                        column: x => x.ToId,
                        principalTable: "CryptoWallets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccountEvents_AccountSocialClubId",
                table: "AccountEvents",
                column: "AccountSocialClubId");

            migrationBuilder.CreateIndex(
                name: "IX_BankAccounts_BankId",
                table: "BankAccounts",
                column: "BankId");

            migrationBuilder.CreateIndex(
                name: "IX_BankAccounts_BankId1",
                table: "BankAccounts",
                column: "BankId1");

            migrationBuilder.CreateIndex(
                name: "IX_BankAccounts_OwnerId",
                table: "BankAccounts",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_BankTransactions_FromId",
                table: "BankTransactions",
                column: "FromId");

            migrationBuilder.CreateIndex(
                name: "IX_BankTransactions_ToId",
                table: "BankTransactions",
                column: "ToId");

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
                name: "IX_CharacterAppearance_CharacterId",
                table: "CharacterAppearance",
                column: "CharacterId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Characters_AccountSocialClubId",
                table: "Characters",
                column: "AccountSocialClubId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_MainBankAccountId",
                table: "Characters",
                column: "MainBankAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_CryptoTransactions_FromId",
                table: "CryptoTransactions",
                column: "FromId");

            migrationBuilder.CreateIndex(
                name: "IX_CryptoTransactions_ToId",
                table: "CryptoTransactions",
                column: "ToId");

            migrationBuilder.CreateIndex(
                name: "IX_CryptoWallets_CharacterId",
                table: "CryptoWallets",
                column: "CharacterId");

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
                name: "FK_Characters_Accounts_AccountSocialClubId",
                table: "Characters");

            migrationBuilder.DropForeignKey(
                name: "FK_BankAccounts_Bank_BankId",
                table: "BankAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_BankAccounts_Bank_BankId1",
                table: "BankAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_BankAccounts_Characters_OwnerId",
                table: "BankAccounts");

            migrationBuilder.DropTable(
                name: "AccountEvents");

            migrationBuilder.DropTable(
                name: "BankTransactions");

            migrationBuilder.DropTable(
                name: "Bans");

            migrationBuilder.DropTable(
                name: "CharacterAppearance");

            migrationBuilder.DropTable(
                name: "CryptoTransactions");

            migrationBuilder.DropTable(
                name: "CryptoWallets");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "Bank");

            migrationBuilder.DropTable(
                name: "Characters");

            migrationBuilder.DropTable(
                name: "BankAccounts");
        }
    }
}
