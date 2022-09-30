using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Migrations
{
    public partial class AbstractColShape : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AbstractRoom_ColShape_EntranceId",
                table: "AbstractRoom");

            migrationBuilder.DropForeignKey(
                name: "FK_AbstractRoom_ColShape_ExitId",
                table: "AbstractRoom");

            migrationBuilder.DropForeignKey(
                name: "FK_AbstractRoom_Characters_OwnerId1",
                table: "AbstractRoom");

            migrationBuilder.DropForeignKey(
                name: "FK_AbstractRoom_Characters_OwnerId",
                table: "AbstractRoom");

            migrationBuilder.DropTable(
                name: "ColShape");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AbstractRoom",
                table: "AbstractRoom");

            migrationBuilder.DropIndex(
                name: "IX_AbstractRoom_ExitId",
                table: "AbstractRoom");

            migrationBuilder.DropColumn(
                name: "ExitId",
                table: "AbstractRoom");

            migrationBuilder.RenameTable(
                name: "AbstractRoom",
                newName: "Rooms");

            migrationBuilder.RenameIndex(
                name: "IX_AbstractRoom_OwnerId",
                table: "Rooms",
                newName: "IX_Rooms_OwnerId");

            migrationBuilder.RenameIndex(
                name: "IX_AbstractRoom_OwnerId1",
                table: "Rooms",
                newName: "IX_Rooms_OwnerId1");

            migrationBuilder.RenameIndex(
                name: "IX_AbstractRoom_EntranceId",
                table: "Rooms",
                newName: "IX_Rooms_EntranceId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rooms",
                table: "Rooms",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "ColShapes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    Center = table.Column<string>(nullable: true),
                    Radius = table.Column<float>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    IsInternal = table.Column<bool>(nullable: true),
                    OwnerId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ColShapes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ColShapes_Rooms_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ColShapes_OwnerId",
                table: "ColShapes",
                column: "OwnerId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_ColShapes_EntranceId",
                table: "Rooms",
                column: "EntranceId",
                principalTable: "ColShapes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_Characters_OwnerId1",
                table: "Rooms",
                column: "OwnerId1",
                principalTable: "Characters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_Characters_OwnerId",
                table: "Rooms",
                column: "OwnerId",
                principalTable: "Characters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_ColShapes_EntranceId",
                table: "Rooms");

            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Characters_OwnerId1",
                table: "Rooms");

            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Characters_OwnerId",
                table: "Rooms");

            migrationBuilder.DropTable(
                name: "ColShapes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rooms",
                table: "Rooms");

            migrationBuilder.RenameTable(
                name: "Rooms",
                newName: "AbstractRoom");

            migrationBuilder.RenameIndex(
                name: "IX_Rooms_OwnerId",
                table: "AbstractRoom",
                newName: "IX_AbstractRoom_OwnerId");

            migrationBuilder.RenameIndex(
                name: "IX_Rooms_OwnerId1",
                table: "AbstractRoom",
                newName: "IX_AbstractRoom_OwnerId1");

            migrationBuilder.RenameIndex(
                name: "IX_Rooms_EntranceId",
                table: "AbstractRoom",
                newName: "IX_AbstractRoom_EntranceId");

            migrationBuilder.AddColumn<Guid>(
                name: "ExitId",
                table: "AbstractRoom",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_AbstractRoom",
                table: "AbstractRoom",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "ColShape",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Center = table.Column<string>(type: "text", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Radius = table.Column<float>(type: "real", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ColShape", x => x.Id);
                });

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
    }
}
