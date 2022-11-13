using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MachineBuildingFactory.Migrations
{
    public partial class initial10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Assemblies",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2022, 11, 13, 10, 25, 37, 458, DateTimeKind.Local).AddTicks(7901));

            migrationBuilder.UpdateData(
                table: "Assemblies",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2022, 11, 13, 10, 25, 37, 458, DateTimeKind.Local).AddTicks(7905));

            migrationBuilder.InsertData(
                table: "Assemblies",
                columns: new[] { "Id", "AuthorSignature", "CreatedOn", "Description", "DrawingNumber", "Image", "Name" },
                values: new object[,]
                {
                    { 5, "DD", new DateTime(2022, 11, 13, 10, 25, 37, 458, DateTimeKind.Local).AddTicks(7909), "Steam turbine 100 kW", "WM-026-100-R", "link to picture", "Steam turbine" },
                    { 6, "DD", new DateTime(2022, 11, 13, 10, 25, 37, 458, DateTimeKind.Local).AddTicks(7913), "Cooling system for industry", "CS-125-TF58-000", "link to picture", "Cooling system" },
                    { 7, "TT", new DateTime(2022, 11, 13, 10, 25, 37, 458, DateTimeKind.Local).AddTicks(7917), "High pressure reciprocating compressor", "CM-300-RF98-700", "link to picture", "Compressor" }
                });

            migrationBuilder.UpdateData(
                table: "ProductionParts",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2022, 11, 13, 10, 25, 37, 458, DateTimeKind.Local).AddTicks(7669));

            migrationBuilder.UpdateData(
                table: "ProductionParts",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2022, 11, 13, 10, 25, 37, 458, DateTimeKind.Local).AddTicks(7677));

            migrationBuilder.InsertData(
                table: "ProductionParts",
                columns: new[] { "Id", "AuthorSignature", "ColorOfPaintRal", "CreatedOn", "Description", "DrawingNumber", "Image", "LaserCutLength", "MaterialId", "Name", "SurfaceArea", "SurfaceTreatment", "TypeOfPaint", "TypeOfProductionPartId", "Weight" },
                values: new object[,]
                {
                    { 7, "DD", 3, new DateTime(2022, 11, 13, 10, 25, 37, 458, DateTimeKind.Local).AddTicks(7681), "For all type of construction", "BP-080-008", "Picture", 8.9000000000000004, 5, "Base plate", 5.2999999999999998, 3, 2, 2, 12.6 },
                    { 8, "TT", 1, new DateTime(2022, 11, 13, 10, 25, 37, 458, DateTimeKind.Local).AddTicks(7686), "Gear for gearbox", "GB-200-036", "Picture", 0.0, 4, "Gear 34/69", 8.3000000000000007, 3, 1, 1, 6.5999999999999996 },
                    { 9, "TT", 1, new DateTime(2022, 11, 13, 10, 25, 37, 458, DateTimeKind.Local).AddTicks(7691), "Brackets for Frame", "GB-200-036", "Picture", 0.0, 1, "Brackets", 8.3000000000000007, 3, 1, 2, 6.5999999999999996 },
                    { 10, "GG", 1, new DateTime(2022, 11, 13, 10, 25, 37, 458, DateTimeKind.Local).AddTicks(7695), "Frame big size", "FBS-2365-078", "Picture", 0.0, 1, "Frame 1000x200", 105.3, 3, 1, 3, 6.5999999999999996 },
                    { 11, "GG", 1, new DateTime(2022, 11, 13, 10, 25, 37, 458, DateTimeKind.Local).AddTicks(7700), "Toot 45, M=7, TRE-89", "RW-859-026", "Picture", 0.0, 1, "Rack-Wheel", 1.2, 1, 1, 1, 5.5999999999999996 },
                    { 12, "GG", 1, new DateTime(2022, 11, 13, 10, 25, 37, 458, DateTimeKind.Local).AddTicks(7705), "Toot 65, M=4, SPG-05", "RW-859-026", "Picture", 0.0, 1, "Sprocket", 1.2, 1, 1, 1, 5.5999999999999996 }
                });

            migrationBuilder.UpdateData(
                table: "PurchasedParts",
                keyColumn: "Id",
                keyValue: 7,
                column: "Standard",
                value: "ISO 55629");

            migrationBuilder.InsertData(
                table: "PurchasedParts",
                columns: new[] { "Id", "Description", "Image", "ItemNumber", "ManufacturerId", "Name", "Standard", "SupplierId", "Weight" },
                values: new object[,]
                {
                    { 8, "Read holding registers (03) 29 words", "Picture", "ATV310", 7, "Variable speed drive", "ISO 32685", 11, 1.3 },
                    { 9, "Linear Bearing with Round Flange", "Picture", "LMF 06UU", 7, "Linear Bearing", "ISO 36958", 13, 1.3 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Assemblies",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Assemblies",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Assemblies",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "ProductionParts",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "ProductionParts",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "ProductionParts",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "ProductionParts",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "ProductionParts",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "ProductionParts",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "PurchasedParts",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "PurchasedParts",
                keyColumn: "Id",
                keyValue: 9);

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

            migrationBuilder.UpdateData(
                table: "PurchasedParts",
                keyColumn: "Id",
                keyValue: 7,
                column: "Standard",
                value: "ISO 22564");
        }
    }
}
