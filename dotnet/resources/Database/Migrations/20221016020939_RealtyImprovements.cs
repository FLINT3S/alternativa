using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Migrations
{
    public partial class RealtyImprovements : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "RealtyPrototype",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsWindowed",
                table: "Interior",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Interior",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Entrances",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Interior",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "CreatedDate", "IsWindowed", "Name", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 10, 16, 5, 9, 38, 577, DateTimeKind.Local).AddTicks(126), true, "Автодом Тревора", new DateTime(2022, 10, 16, 5, 9, 38, 578, DateTimeKind.Local).AddTicks(639) });

            migrationBuilder.UpdateData(
                table: "Interior",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                columns: new[] { "CreatedDate", "Name", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 10, 16, 5, 9, 38, 578, DateTimeKind.Local).AddTicks(3045), "Low End Apartment", new DateTime(2022, 10, 16, 5, 9, 38, 578, DateTimeKind.Local).AddTicks(3053) });

            migrationBuilder.InsertData(
                table: "Interior",
                columns: new[] { "Id", "CreatedDate", "Entrance", "Exit", "IplName", "IsWindowed", "Name", "UpdatedDate" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000003"), new DateTime(2022, 10, 16, 5, 9, 38, 578, DateTimeKind.Local).AddTicks(3121), "{\"x\":347.26,\"y\":-999.29,\"z\":-99.2}", "{\"x\":347.26,\"y\":-999.29,\"z\":-99.2}", "", false, "Medium End Apartment	", new DateTime(2022, 10, 16, 5, 9, 38, 578, DateTimeKind.Local).AddTicks(3122) });

            migrationBuilder.InsertData(
                table: "RealtyPrototype",
                columns: new[] { "Id", "CreatedDate", "GovernmentPrice", "InteriorId", "Name", "ParkingPlaces", "PriceSegment", "Type", "UpdatedDate" },
                values: new object[] { new Guid("00000000-0000-0000-0001-000000000001"), new DateTime(2022, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 100000000L, new Guid("00000000-0000-0000-0000-000000000001"), "Дом эконом-класса", (byte)2, (byte)1, (byte)0, new DateTime(2022, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Interior",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"));

            migrationBuilder.DeleteData(
                table: "RealtyPrototype",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000001"));

            migrationBuilder.DropColumn(
                name: "Name",
                table: "RealtyPrototype");

            migrationBuilder.DropColumn(
                name: "IsWindowed",
                table: "Interior");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Interior");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Entrances");

            migrationBuilder.UpdateData(
                table: "Interior",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 10, 12, 22, 27, 38, 15, DateTimeKind.Local).AddTicks(7731), new DateTime(2022, 10, 12, 22, 27, 38, 17, DateTimeKind.Local).AddTicks(901) });

            migrationBuilder.UpdateData(
                table: "Interior",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 10, 12, 22, 27, 38, 17, DateTimeKind.Local).AddTicks(3095), new DateTime(2022, 10, 12, 22, 27, 38, 17, DateTimeKind.Local).AddTicks(3107) });
        }
    }
}
