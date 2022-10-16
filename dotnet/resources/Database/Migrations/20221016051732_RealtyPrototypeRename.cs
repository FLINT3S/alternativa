using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Migrations
{
    public partial class RealtyPrototypeRename : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                newName: "RealtyPrototypes");

            migrationBuilder.RenameIndex(
                name: "IX_RealityPrototypes_InteriorId",
                table: "RealtyPrototypes",
                newName: "IX_RealtyPrototypes_InteriorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RealtyPrototypes",
                table: "RealtyPrototypes",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Interior",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 10, 16, 8, 17, 31, 520, DateTimeKind.Local).AddTicks(7359), new DateTime(2022, 10, 16, 8, 17, 31, 525, DateTimeKind.Local).AddTicks(1782) });

            migrationBuilder.UpdateData(
                table: "Interior",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 10, 16, 8, 17, 31, 525, DateTimeKind.Local).AddTicks(7291), new DateTime(2022, 10, 16, 8, 17, 31, 525, DateTimeKind.Local).AddTicks(7313) });

            migrationBuilder.UpdateData(
                table: "Interior",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 10, 16, 8, 17, 31, 525, DateTimeKind.Local).AddTicks(7378), new DateTime(2022, 10, 16, 8, 17, 31, 525, DateTimeKind.Local).AddTicks(7379) });

            migrationBuilder.AddForeignKey(
                name: "FK_Realty_RealtyPrototypes_PrototypeId",
                table: "Realty",
                column: "PrototypeId",
                principalTable: "RealtyPrototypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RealtyPrototypes_Interior_InteriorId",
                table: "RealtyPrototypes",
                column: "InteriorId",
                principalTable: "Interior",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Realty_RealtyPrototypes_PrototypeId",
                table: "Realty");

            migrationBuilder.DropForeignKey(
                name: "FK_RealtyPrototypes_Interior_InteriorId",
                table: "RealtyPrototypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RealtyPrototypes",
                table: "RealtyPrototypes");

            migrationBuilder.RenameTable(
                name: "RealtyPrototypes",
                newName: "RealityPrototypes");

            migrationBuilder.RenameIndex(
                name: "IX_RealtyPrototypes_InteriorId",
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
    }
}
