using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Migrations
{
    public partial class RenameFieldInAppearance : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CharacterAppearance_Characters_OwnderId",
                table: "CharacterAppearance");

            migrationBuilder.DropIndex(
                name: "IX_CharacterAppearance_OwnderId",
                table: "CharacterAppearance");

            migrationBuilder.DropColumn(
                name: "OwnderId",
                table: "CharacterAppearance");

            migrationBuilder.AlterColumn<byte>(
                name: "MotherId",
                table: "CharacterAppearance",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<byte>(
                name: "FatherId",
                table: "CharacterAppearance",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<Guid>(
                name: "OwnerId",
                table: "CharacterAppearance",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_CharacterAppearance_OwnerId",
                table: "CharacterAppearance",
                column: "OwnerId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterAppearance_Characters_OwnerId",
                table: "CharacterAppearance",
                column: "OwnerId",
                principalTable: "Characters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CharacterAppearance_Characters_OwnerId",
                table: "CharacterAppearance");

            migrationBuilder.DropIndex(
                name: "IX_CharacterAppearance_OwnerId",
                table: "CharacterAppearance");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "CharacterAppearance");

            migrationBuilder.AlterColumn<int>(
                name: "MotherId",
                table: "CharacterAppearance",
                type: "integer",
                nullable: false,
                oldClrType: typeof(byte));

            migrationBuilder.AlterColumn<int>(
                name: "FatherId",
                table: "CharacterAppearance",
                type: "integer",
                nullable: false,
                oldClrType: typeof(byte));

            migrationBuilder.AddColumn<Guid>(
                name: "OwnderId",
                table: "CharacterAppearance",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_CharacterAppearance_OwnderId",
                table: "CharacterAppearance",
                column: "OwnderId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterAppearance_Characters_OwnderId",
                table: "CharacterAppearance",
                column: "OwnderId",
                principalTable: "Characters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
