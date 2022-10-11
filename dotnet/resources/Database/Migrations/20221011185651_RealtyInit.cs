using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Migrations
{
    public partial class RealtyInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ColShapes_Rooms_OwnerId",
                table: "ColShapes");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "ColShapes");

            migrationBuilder.CreateTable(
                name: "Entrances",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Entrance = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entrances", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Interior",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    IplName = table.Column<string>(nullable: true),
                    Entrance = table.Column<string>(nullable: true),
                    Exit = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interior", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RealtyPrototype",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    InteriorId = table.Column<Guid>(nullable: true),
                    Type = table.Column<byte>(nullable: false),
                    PriceSegment = table.Column<byte>(nullable: false),
                    GovernmentPrice = table.Column<long>(nullable: false),
                    ParkingPlaces = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RealtyPrototype", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RealtyPrototype_Interior_InteriorId",
                        column: x => x.InteriorId,
                        principalTable: "Interior",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Realty",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    PrototypeId = table.Column<Guid>(nullable: true),
                    EntranceId = table.Column<Guid>(nullable: true),
                    OwnerId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Realty", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Realty_Entrances_EntranceId",
                        column: x => x.EntranceId,
                        principalTable: "Entrances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Realty_Characters_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Realty_RealtyPrototype_PrototypeId",
                        column: x => x.PrototypeId,
                        principalTable: "RealtyPrototype",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Realty_EntranceId",
                table: "Realty",
                column: "EntranceId");

            migrationBuilder.CreateIndex(
                name: "IX_Realty_OwnerId",
                table: "Realty",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Realty_PrototypeId",
                table: "Realty",
                column: "PrototypeId");

            migrationBuilder.CreateIndex(
                name: "IX_RealtyPrototype_InteriorId",
                table: "RealtyPrototype",
                column: "InteriorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Realty");

            migrationBuilder.DropTable(
                name: "Entrances");

            migrationBuilder.DropTable(
                name: "RealtyPrototype");

            migrationBuilder.DropTable(
                name: "Interior");

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Discriminator = table.Column<string>(type: "text", nullable: false),
                    EntranceId = table.Column<Guid>(type: "uuid", nullable: true),
                    Interior = table.Column<string>(type: "text", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Cost = table.Column<long>(type: "bigint", nullable: true),
                    OwnerId1 = table.Column<Guid>(type: "uuid", nullable: true),
                    OwnerId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rooms_Characters_OwnerId1",
                        column: x => x.OwnerId1,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Rooms_Characters_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ColShapes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Center = table.Column<string>(type: "text", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Discriminator = table.Column<string>(type: "text", nullable: false),
                    Radius = table.Column<float>(type: "real", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsInternal = table.Column<bool>(type: "boolean", nullable: true),
                    OwnerId = table.Column<Guid>(type: "uuid", nullable: true)
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

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_EntranceId",
                table: "Rooms",
                column: "EntranceId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_OwnerId1",
                table: "Rooms",
                column: "OwnerId1");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_OwnerId",
                table: "Rooms",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_ColShapes_EntranceId",
                table: "Rooms",
                column: "EntranceId",
                principalTable: "ColShapes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
