using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MachineBuildingFactory.Migrations
{
    public partial class initial8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Assemblies",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2022, 11, 12, 10, 56, 53, 178, DateTimeKind.Local).AddTicks(4389));

            migrationBuilder.UpdateData(
                table: "Assemblies",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2022, 11, 12, 10, 56, 53, 178, DateTimeKind.Local).AddTicks(4393));

            migrationBuilder.InsertData(
                table: "Manufacturers",
                columns: new[] { "Id", "Email", "Name", "UrlAddress" },
                values: new object[,]
                {
                    { 5, "office@festo.com", "Festo", "Festo.com" },
                    { 6, "office@sew.com", "SEW", "Sew.com" },
                    { 7, "office@siemens.com", "Siemens", "SEW.com" },
                    { 8, "office@valeo.com", "Valeo", "Valeo.com" }
                });

            migrationBuilder.UpdateData(
                table: "ProductionParts",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2022, 11, 12, 10, 56, 53, 178, DateTimeKind.Local).AddTicks(4223));

            migrationBuilder.UpdateData(
                table: "ProductionParts",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2022, 11, 12, 10, 56, 53, 178, DateTimeKind.Local).AddTicks(4230));

            migrationBuilder.InsertData(
                table: "Suppliers",
                columns: new[] { "Id", "Email", "Name", "UrlAddress" },
                values: new object[,]
                {
                    { 11, "office@norelem.com", "Norelem", "Norelem.com" },
                    { 12, "office@misumi.com", "Misumi", "Misumi.com" },
                    { 13, "office@maedler.com", "Maedler", "Maedler.com" },
                    { 14, "office@haberkorn.com", "Haberkorn", "Haberkorn.com" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.UpdateData(
                table: "Assemblies",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2022, 11, 12, 10, 26, 53, 572, DateTimeKind.Local).AddTicks(1520));

            migrationBuilder.UpdateData(
                table: "Assemblies",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2022, 11, 12, 10, 26, 53, 572, DateTimeKind.Local).AddTicks(1524));

            migrationBuilder.UpdateData(
                table: "ProductionParts",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2022, 11, 12, 10, 26, 53, 572, DateTimeKind.Local).AddTicks(1341));

            migrationBuilder.UpdateData(
                table: "ProductionParts",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2022, 11, 12, 10, 26, 53, 572, DateTimeKind.Local).AddTicks(1347));
        }
    }
}
