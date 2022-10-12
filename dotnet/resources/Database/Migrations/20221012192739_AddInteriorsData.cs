using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Migrations
{
    public partial class AddInteriorsData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Interior",
                columns: new[] { "Id", "CreatedDate", "Entrance", "Exit", "IplName", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000001"), new DateTime(2022, 10, 12, 22, 27, 38, 15, DateTimeKind.Local).AddTicks(7731), "{\"x\":1973.35,\"y\":3816.34,\"z\":33.43}", "{\"x\":1973.35,\"y\":3816.34,\"z\":33.43}", "TrevorsTrailerTidy", new DateTime(2022, 10, 12, 22, 27, 38, 17, DateTimeKind.Local).AddTicks(901) },
                    { new Guid("00000000-0000-0000-0000-000000000002"), new DateTime(2022, 10, 12, 22, 27, 38, 17, DateTimeKind.Local).AddTicks(3095), "{\"x\":266.3,\"y\":-1007.4,\"z\":-101.0}", "{\"x\":266.3,\"y\":-1007.4,\"z\":-101.0}", "", new DateTime(2022, 10, 12, 22, 27, 38, 17, DateTimeKind.Local).AddTicks(3107) }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Interior",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "Interior",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"));
        }
    }
}
