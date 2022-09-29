using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Migrations
{
    public partial class ColShapes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Entrance",
                table: "AbstractRoom");

            migrationBuilder.DropColumn(
                name: "Exit",
                table: "AbstractRoom");

            migrationBuilder.AddColumn<Guid>(
                name: "EntranceId",
                table: "AbstractRoom",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ExitId",
                table: "AbstractRoom",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ColShape",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    Center = table.Column<string>(nullable: true),
                    Radius = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ColShape", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AbstractRoom_EntranceId",
                table: "AbstractRoom",
                column: "EntranceId");

            migrationBuilder.CreateIndex(
                name: "IX_AbstractRoom_ExitId",
                table: "AbstractRoom",
                column: "ExitId");

            migrationBuilder.AddForeignKey(
                name: "FK_AbstractRoom_ColShape_EntranceId",
                table: "AbstractRoom",
                column: "EntranceId",
                principalTable: "ColShape",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AbstractRoom_ColShape_ExitId",
                table: "AbstractRoom",
                column: "ExitId",
                principalTable: "ColShape",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AbstractRoom_ColShape_EntranceId",
                table: "AbstractRoom");

            migrationBuilder.DropForeignKey(
                name: "FK_AbstractRoom_ColShape_ExitId",
                table: "AbstractRoom");

            migrationBuilder.DropTable(
                name: "ColShape");

            migrationBuilder.DropIndex(
                name: "IX_AbstractRoom_EntranceId",
                table: "AbstractRoom");

            migrationBuilder.DropIndex(
                name: "IX_AbstractRoom_ExitId",
                table: "AbstractRoom");

            migrationBuilder.DropColumn(
                name: "EntranceId",
                table: "AbstractRoom");

            migrationBuilder.DropColumn(
                name: "ExitId",
                table: "AbstractRoom");

            migrationBuilder.AddColumn<string>(
                name: "Entrance",
                table: "AbstractRoom",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Exit",
                table: "AbstractRoom",
                type: "text",
                nullable: true);
        }
    }
}
