using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MachineBuildingFactory.Migrations
{
    public partial class ititial3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ProductionParts",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2022, 11, 6, 11, 41, 16, 587, DateTimeKind.Local).AddTicks(6557));

            migrationBuilder.InsertData(
                table: "ProductionParts",
                columns: new[] { "Id", "AuthorSignature", "ColorOfPaintRal", "CreatedOn", "Description", "DrawingNumber", "Image", "LaserCutLength", "MaterialId", "Name", "SurfaceArea", "SurfaceTreatment", "TypeOfPaint", "TypeOfProductionPartId", "Weight" },
                values: new object[] { 6, "TT", 1, new DateTime(2022, 11, 6, 11, 41, 16, 587, DateTimeKind.Local).AddTicks(6564), "Shaft for all target.", "CL-025-002", "Picture", 5.9000000000000004, 3, "Shaft", 1.3, 2, 3, 2, 8.5999999999999996 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProductionParts",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.UpdateData(
                table: "ProductionParts",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2022, 11, 6, 9, 57, 49, 917, DateTimeKind.Local).AddTicks(613));
        }
    }
}
