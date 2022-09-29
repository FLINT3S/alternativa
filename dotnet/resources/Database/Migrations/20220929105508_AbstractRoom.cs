using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Migrations
{
    public partial class AbstractRoom : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AbstractRealEstate_Characters_OwnerId",
                table: "AbstractRealEstate");

            migrationBuilder.DropForeignKey(
                name: "FK_AbstractRealEstate_Characters_House_OwnerId",
                table: "AbstractRealEstate");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AbstractRealEstate",
                table: "AbstractRealEstate");

            migrationBuilder.DropIndex(
                name: "IX_AbstractRealEstate_House_OwnerId",
                table: "AbstractRealEstate");

            migrationBuilder.DropColumn(
                name: "House_OwnerId",
                table: "AbstractRealEstate");

            migrationBuilder.RenameTable(
                name: "AbstractRealEstate",
                newName: "AbstractRoom");

            migrationBuilder.RenameIndex(
                name: "IX_AbstractRealEstate_OwnerId",
                table: "AbstractRoom",
                newName: "IX_AbstractRoom_OwnerId");

            migrationBuilder.AlterColumn<long>(
                name: "Cost",
                table: "AbstractRoom",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<string>(
                name: "Exit",
                table: "AbstractRoom",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "OwnerId1",
                table: "AbstractRoom",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_AbstractRoom",
                table: "AbstractRoom",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_AbstractRoom_OwnerId1",
                table: "AbstractRoom",
                column: "OwnerId1");

            migrationBuilder.AddForeignKey(
                name: "FK_AbstractRoom_Characters_OwnerId1",
                table: "AbstractRoom",
                column: "OwnerId1",
                principalTable: "Characters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AbstractRoom_Characters_OwnerId",
                table: "AbstractRoom",
                column: "OwnerId",
                principalTable: "Characters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AbstractRoom_Characters_OwnerId1",
                table: "AbstractRoom");

            migrationBuilder.DropForeignKey(
                name: "FK_AbstractRoom_Characters_OwnerId",
                table: "AbstractRoom");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AbstractRoom",
                table: "AbstractRoom");

            migrationBuilder.DropIndex(
                name: "IX_AbstractRoom_OwnerId1",
                table: "AbstractRoom");

            migrationBuilder.DropColumn(
                name: "Exit",
                table: "AbstractRoom");

            migrationBuilder.DropColumn(
                name: "OwnerId1",
                table: "AbstractRoom");

            migrationBuilder.RenameTable(
                name: "AbstractRoom",
                newName: "AbstractRealEstate");

            migrationBuilder.RenameIndex(
                name: "IX_AbstractRoom_OwnerId",
                table: "AbstractRealEstate",
                newName: "IX_AbstractRealEstate_OwnerId");

            migrationBuilder.AlterColumn<long>(
                name: "Cost",
                table: "AbstractRealEstate",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "House_OwnerId",
                table: "AbstractRealEstate",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_AbstractRealEstate",
                table: "AbstractRealEstate",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_AbstractRealEstate_House_OwnerId",
                table: "AbstractRealEstate",
                column: "House_OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_AbstractRealEstate_Characters_OwnerId",
                table: "AbstractRealEstate",
                column: "OwnerId",
                principalTable: "Characters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AbstractRealEstate_Characters_House_OwnerId",
                table: "AbstractRealEstate",
                column: "House_OwnerId",
                principalTable: "Characters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
