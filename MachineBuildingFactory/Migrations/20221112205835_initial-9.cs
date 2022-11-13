using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MachineBuildingFactory.Migrations
{
    public partial class initial9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Assemblies",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2022, 11, 12, 21, 58, 34, 804, DateTimeKind.Local).AddTicks(5668));

            migrationBuilder.UpdateData(
                table: "Assemblies",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2022, 11, 12, 21, 58, 34, 804, DateTimeKind.Local).AddTicks(5681));

            migrationBuilder.UpdateData(
                table: "ProductionParts",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2022, 11, 12, 21, 58, 34, 804, DateTimeKind.Local).AddTicks(5212));

            migrationBuilder.UpdateData(
                table: "ProductionParts",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2022, 11, 12, 21, 58, 34, 804, DateTimeKind.Local).AddTicks(5232));

            migrationBuilder.InsertData(
                table: "PurchasedParts",
                columns: new[] { "Id", "Description", "Image", "ItemNumber", "ManufacturerId", "Name", "Standard", "SupplierId", "Weight" },
                values: new object[,]
                {
                    { 5, "Gear motor of SEW, Supplier: Misumi", "Picture", "GM-100/25-368A", 5, "Gearbox", "ISO 36264", 12, 56.799999999999997 },
                    { 6, "Compact cylinders ADN-S, double-acting", "Picture", "ADN-S-12-25-I-P", 6, "Compact cylinders ADN-S", "ISO 21287", 14, 2.2999999999999998 },
                    { 7, "For material handling applications", "Picture", "SKF SY 35 TR", 7, "Pillow block bearing", "ISO 22564", 13, 1.3 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PurchasedParts",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "PurchasedParts",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "PurchasedParts",
                keyColumn: "Id",
                keyValue: 7);

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
        }
    }
}
