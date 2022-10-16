using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Migrations
{
    public partial class StaticInteriorCreateUpdateDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Interior",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Interior",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Interior",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
