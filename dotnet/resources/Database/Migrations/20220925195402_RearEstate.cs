using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Migrations
{
    public partial class RearEstate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AbstractRealEstate",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    Cost = table.Column<long>(nullable: false),
                    Entrance = table.Column<string>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    OwnerId = table.Column<Guid>(nullable: true),
                    House_OwnerId = table.Column<Guid>(nullable: true),
                    Interior = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbstractRealEstate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AbstractRealEstate_Characters_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AbstractRealEstate_Characters_House_OwnerId",
                        column: x => x.House_OwnerId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AbstractRealEstate_OwnerId",
                table: "AbstractRealEstate",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_AbstractRealEstate_House_OwnerId",
                table: "AbstractRealEstate",
                column: "House_OwnerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AbstractRealEstate");
        }
    }
}
