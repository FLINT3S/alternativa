using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Migrations
{
    public partial class character_appearance : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateIndex(
                name: "IX_CharacterAppearance_CharacterId",
                table: "CharacterAppearance",
                column: "CharacterId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CharacterAppearance");
        }
    }
}
