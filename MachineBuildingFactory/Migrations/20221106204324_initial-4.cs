using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MachineBuildingFactory.Migrations
{
    public partial class initial4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ProductionParts",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2022, 11, 6, 21, 43, 23, 969, DateTimeKind.Local).AddTicks(7696));

            migrationBuilder.UpdateData(
                table: "ProductionParts",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2022, 11, 6, 21, 43, 23, 969, DateTimeKind.Local).AddTicks(7713));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ProductionParts",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2022, 11, 6, 11, 41, 16, 587, DateTimeKind.Local).AddTicks(6557));

            migrationBuilder.UpdateData(
                table: "ProductionParts",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2022, 11, 6, 11, 41, 16, 587, DateTimeKind.Local).AddTicks(6564));
        }
    }
}
