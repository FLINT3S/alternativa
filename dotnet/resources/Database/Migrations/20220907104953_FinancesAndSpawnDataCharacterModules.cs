using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Migrations
{
    public partial class FinancesAndSpawnDataCharacterModules : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BankAccounts_Characters_OwnerId",
                table: "BankAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_CharacterAppearance_Characters_CharacterId",
                table: "CharacterAppearance");

            migrationBuilder.DropForeignKey(
                name: "FK_Characters_BankAccounts_MainBankAccountId",
                table: "Characters");

            migrationBuilder.DropForeignKey(
                name: "FK_CryptoWallets_Characters_CharacterId",
                table: "CryptoWallets");

            migrationBuilder.DropIndex(
                name: "IX_CryptoWallets_CharacterId",
                table: "CryptoWallets");

            migrationBuilder.DropIndex(
                name: "IX_Characters_MainBankAccountId",
                table: "Characters");

            migrationBuilder.DropIndex(
                name: "IX_CharacterAppearance_CharacterId",
                table: "CharacterAppearance");

            migrationBuilder.DropIndex(
                name: "IX_BankAccounts_OwnerId",
                table: "BankAccounts");

            migrationBuilder.DropColumn(
                name: "CharacterId",
                table: "CryptoWallets");

            migrationBuilder.DropColumn(
                name: "Cash",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "LastPosition",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "MainBankAccountId",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "CharacterId",
                table: "CharacterAppearance");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "BankAccounts");

            migrationBuilder.AddColumn<Guid>(
                name: "CharacterFinancesId",
                table: "CryptoWallets",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "OwnderId",
                table: "CharacterAppearance",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "OwnerFinancesId",
                table: "BankAccounts",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CharacterFinances",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    OwnerId = table.Column<Guid>(nullable: false),
                    Cash = table.Column<long>(nullable: false),
                    MainBankAccountId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterFinances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CharacterFinances_BankAccounts_MainBankAccountId",
                        column: x => x.MainBankAccountId,
                        principalTable: "BankAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CharacterFinances_Characters_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CharacterSpawnData",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    OwnerId = table.Column<Guid>(nullable: false),
                    Armor = table.Column<int>(nullable: false),
                    Health = table.Column<int>(nullable: false),
                    Position = table.Column<string>(nullable: true),
                    Heading = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterSpawnData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CharacterSpawnData_Characters_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CryptoWallets_CharacterFinancesId",
                table: "CryptoWallets",
                column: "CharacterFinancesId");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterAppearance_OwnderId",
                table: "CharacterAppearance",
                column: "OwnderId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BankAccounts_OwnerFinancesId",
                table: "BankAccounts",
                column: "OwnerFinancesId");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterFinances_MainBankAccountId",
                table: "CharacterFinances",
                column: "MainBankAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterFinances_OwnerId",
                table: "CharacterFinances",
                column: "OwnerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CharacterSpawnData_OwnerId",
                table: "CharacterSpawnData",
                column: "OwnerId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BankAccounts_CharacterFinances_OwnerFinancesId",
                table: "BankAccounts",
                column: "OwnerFinancesId",
                principalTable: "CharacterFinances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterAppearance_Characters_OwnderId",
                table: "CharacterAppearance",
                column: "OwnderId",
                principalTable: "Characters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CryptoWallets_CharacterFinances_CharacterFinancesId",
                table: "CryptoWallets",
                column: "CharacterFinancesId",
                principalTable: "CharacterFinances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BankAccounts_CharacterFinances_OwnerFinancesId",
                table: "BankAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_CharacterAppearance_Characters_OwnderId",
                table: "CharacterAppearance");

            migrationBuilder.DropForeignKey(
                name: "FK_CryptoWallets_CharacterFinances_CharacterFinancesId",
                table: "CryptoWallets");

            migrationBuilder.DropTable(
                name: "CharacterFinances");

            migrationBuilder.DropTable(
                name: "CharacterSpawnData");

            migrationBuilder.DropIndex(
                name: "IX_CryptoWallets_CharacterFinancesId",
                table: "CryptoWallets");

            migrationBuilder.DropIndex(
                name: "IX_CharacterAppearance_OwnderId",
                table: "CharacterAppearance");

            migrationBuilder.DropIndex(
                name: "IX_BankAccounts_OwnerFinancesId",
                table: "BankAccounts");

            migrationBuilder.DropColumn(
                name: "CharacterFinancesId",
                table: "CryptoWallets");

            migrationBuilder.DropColumn(
                name: "OwnderId",
                table: "CharacterAppearance");

            migrationBuilder.DropColumn(
                name: "OwnerFinancesId",
                table: "BankAccounts");

            migrationBuilder.AddColumn<Guid>(
                name: "CharacterId",
                table: "CryptoWallets",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "Cash",
                table: "Characters",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "LastPosition",
                table: "Characters",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "MainBankAccountId",
                table: "Characters",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CharacterId",
                table: "CharacterAppearance",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "OwnerId",
                table: "BankAccounts",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CryptoWallets_CharacterId",
                table: "CryptoWallets",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_MainBankAccountId",
                table: "Characters",
                column: "MainBankAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterAppearance_CharacterId",
                table: "CharacterAppearance",
                column: "CharacterId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BankAccounts_OwnerId",
                table: "BankAccounts",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_BankAccounts_Characters_OwnerId",
                table: "BankAccounts",
                column: "OwnerId",
                principalTable: "Characters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterAppearance_Characters_CharacterId",
                table: "CharacterAppearance",
                column: "CharacterId",
                principalTable: "Characters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_BankAccounts_MainBankAccountId",
                table: "Characters",
                column: "MainBankAccountId",
                principalTable: "BankAccounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CryptoWallets_Characters_CharacterId",
                table: "CryptoWallets",
                column: "CharacterId",
                principalTable: "Characters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
