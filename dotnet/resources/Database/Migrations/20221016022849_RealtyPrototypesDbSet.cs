using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Migrations
{
    public partial class RealtyPrototypesDbSet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Realty_RealtyPrototype_PrototypeId",
                table: "Realty");

            migrationBuilder.DropForeignKey(
                name: "FK_RealtyPrototype_Interior_InteriorId",
                table: "RealtyPrototype");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RealtyPrototype",
                table: "RealtyPrototype");

            migrationBuilder.RenameTable(
                name: "RealtyPrototype",
                newName: "RealityPrototypes");

            migrationBuilder.RenameIndex(
                name: "IX_RealtyPrototype_InteriorId",
                table: "RealityPrototypes",
                newName: "IX_RealityPrototypes_InteriorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RealityPrototypes",
                table: "RealityPrototypes",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Interior",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 10, 16, 5, 28, 47, 467, DateTimeKind.Local).AddTicks(9921), new DateTime(2022, 10, 16, 5, 28, 47, 473, DateTimeKind.Local).AddTicks(1268) });

            migrationBuilder.UpdateData(
                table: "Interior",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 10, 16, 5, 28, 47, 473, DateTimeKind.Local).AddTicks(4461), new DateTime(2022, 10, 16, 5, 28, 47, 473, DateTimeKind.Local).AddTicks(4475) });

            migrationBuilder.UpdateData(
                table: "Interior",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 10, 16, 5, 28, 47, 473, DateTimeKind.Local).AddTicks(4545), new DateTime(2022, 10, 16, 5, 28, 47, 473, DateTimeKind.Local).AddTicks(4547) });

            migrationBuilder.AddForeignKey(
                name: "FK_RealityPrototypes_Interior_InteriorId",
                table: "RealityPrototypes",
                column: "InteriorId",
                principalTable: "Interior",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Realty_RealityPrototypes_PrototypeId",
                table: "Realty",
                column: "PrototypeId",
                principalTable: "RealityPrototypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RealityPrototypes_Interior_InteriorId",
                table: "RealityPrototypes");

            migrationBuilder.DropForeignKey(
                name: "FK_Realty_RealityPrototypes_PrototypeId",
                table: "Realty");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RealityPrototypes",
                table: "RealityPrototypes");

            migrationBuilder.RenameTable(
                name: "RealityPrototypes",
                newName: "RealtyPrototype");

            migrationBuilder.RenameIndex(
                name: "IX_RealityPrototypes_InteriorId",
                table: "RealtyPrototype",
                newName: "IX_RealtyPrototype_InteriorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RealtyPrototype",
                table: "RealtyPrototype",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Interior",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 10, 16, 5, 9, 38, 577, DateTimeKind.Local).AddTicks(126), new DateTime(2022, 10, 16, 5, 9, 38, 578, DateTimeKind.Local).AddTicks(639) });

            migrationBuilder.UpdateData(
                table: "Interior",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 10, 16, 5, 9, 38, 578, DateTimeKind.Local).AddTicks(3045), new DateTime(2022, 10, 16, 5, 9, 38, 578, DateTimeKind.Local).AddTicks(3053) });

            migrationBuilder.UpdateData(
                table: "Interior",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 10, 16, 5, 9, 38, 578, DateTimeKind.Local).AddTicks(3121), new DateTime(2022, 10, 16, 5, 9, 38, 578, DateTimeKind.Local).AddTicks(3122) });

            migrationBuilder.AddForeignKey(
                name: "FK_Realty_RealtyPrototype_PrototypeId",
                table: "Realty",
                column: "PrototypeId",
                principalTable: "RealtyPrototype",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RealtyPrototype_Interior_InteriorId",
                table: "RealtyPrototype",
                column: "InteriorId",
                principalTable: "Interior",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
