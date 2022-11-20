using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MachineBuildingFactory.Migrations
{
    public partial class WorkingAssembly : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Quantaty",
                table: "AssemblyProductionParts",
                newName: "Quantity");

            migrationBuilder.UpdateData(
                table: "Assemblies",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2022, 11, 20, 9, 44, 6, 81, DateTimeKind.Local).AddTicks(218));

            migrationBuilder.UpdateData(
                table: "Assemblies",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2022, 11, 20, 9, 44, 6, 81, DateTimeKind.Local).AddTicks(227));

            migrationBuilder.UpdateData(
                table: "Assemblies",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2022, 11, 20, 9, 44, 6, 81, DateTimeKind.Local).AddTicks(236));

            migrationBuilder.UpdateData(
                table: "Assemblies",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2022, 11, 20, 9, 44, 6, 81, DateTimeKind.Local).AddTicks(250));

            migrationBuilder.UpdateData(
                table: "Assemblies",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2022, 11, 20, 9, 44, 6, 81, DateTimeKind.Local).AddTicks(262));

            migrationBuilder.UpdateData(
                table: "ProductionParts",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2022, 11, 20, 9, 44, 6, 80, DateTimeKind.Local).AddTicks(9746));

            migrationBuilder.UpdateData(
                table: "ProductionParts",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2022, 11, 20, 9, 44, 6, 80, DateTimeKind.Local).AddTicks(9761));

            migrationBuilder.UpdateData(
                table: "ProductionParts",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2022, 11, 20, 9, 44, 6, 80, DateTimeKind.Local).AddTicks(9772));

            migrationBuilder.UpdateData(
                table: "ProductionParts",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2022, 11, 20, 9, 44, 6, 80, DateTimeKind.Local).AddTicks(9784));

            migrationBuilder.UpdateData(
                table: "ProductionParts",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedOn",
                value: new DateTime(2022, 11, 20, 9, 44, 6, 80, DateTimeKind.Local).AddTicks(9794));

            migrationBuilder.UpdateData(
                table: "ProductionParts",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedOn",
                value: new DateTime(2022, 11, 20, 9, 44, 6, 80, DateTimeKind.Local).AddTicks(9804));

            migrationBuilder.UpdateData(
                table: "ProductionParts",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedOn",
                value: new DateTime(2022, 11, 20, 9, 44, 6, 80, DateTimeKind.Local).AddTicks(9814));

            migrationBuilder.UpdateData(
                table: "ProductionParts",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedOn",
                value: new DateTime(2022, 11, 20, 9, 44, 6, 80, DateTimeKind.Local).AddTicks(9824));

            migrationBuilder.UpdateData(
                table: "ProductionParts",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedOn",
                value: new DateTime(2022, 11, 20, 9, 44, 6, 80, DateTimeKind.Local).AddTicks(9834));

            migrationBuilder.UpdateData(
                table: "PurchasedParts",
                keyColumn: "Id",
                keyValue: 5,
                column: "Image",
                value: "https://files.fm/thumb_show.php?i=zbkja84dh");

            migrationBuilder.UpdateData(
                table: "PurchasedParts",
                keyColumn: "Id",
                keyValue: 6,
                column: "Image",
                value: "https://files.fm/thumb_show.php?i=bduy24ra6");

            migrationBuilder.UpdateData(
                table: "PurchasedParts",
                keyColumn: "Id",
                keyValue: 7,
                column: "Image",
                value: "https://files.fm/thumb_show.php?i=a62t5h3r2");

            migrationBuilder.UpdateData(
                table: "PurchasedParts",
                keyColumn: "Id",
                keyValue: 8,
                column: "Image",
                value: "https://files.fm/thumb_show.php?i=sh76p8cgu");

            migrationBuilder.UpdateData(
                table: "PurchasedParts",
                keyColumn: "Id",
                keyValue: 9,
                column: "Image",
                value: "https://files.fm/thumb_show.php?i=thrgt2tfr");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "AssemblyProductionParts",
                newName: "Quantaty");

            migrationBuilder.UpdateData(
                table: "Assemblies",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2022, 11, 16, 22, 40, 46, 781, DateTimeKind.Local).AddTicks(3727));

            migrationBuilder.UpdateData(
                table: "Assemblies",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2022, 11, 16, 22, 40, 46, 781, DateTimeKind.Local).AddTicks(3736));

            migrationBuilder.UpdateData(
                table: "Assemblies",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2022, 11, 16, 22, 40, 46, 781, DateTimeKind.Local).AddTicks(3744));

            migrationBuilder.UpdateData(
                table: "Assemblies",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2022, 11, 16, 22, 40, 46, 781, DateTimeKind.Local).AddTicks(3753));

            migrationBuilder.UpdateData(
                table: "Assemblies",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2022, 11, 16, 22, 40, 46, 781, DateTimeKind.Local).AddTicks(3762));

            migrationBuilder.UpdateData(
                table: "ProductionParts",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2022, 11, 16, 22, 40, 46, 781, DateTimeKind.Local).AddTicks(3234));

            migrationBuilder.UpdateData(
                table: "ProductionParts",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2022, 11, 16, 22, 40, 46, 781, DateTimeKind.Local).AddTicks(3251));

            migrationBuilder.UpdateData(
                table: "ProductionParts",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2022, 11, 16, 22, 40, 46, 781, DateTimeKind.Local).AddTicks(3261));

            migrationBuilder.UpdateData(
                table: "ProductionParts",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2022, 11, 16, 22, 40, 46, 781, DateTimeKind.Local).AddTicks(3271));

            migrationBuilder.UpdateData(
                table: "ProductionParts",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedOn",
                value: new DateTime(2022, 11, 16, 22, 40, 46, 781, DateTimeKind.Local).AddTicks(3281));

            migrationBuilder.UpdateData(
                table: "ProductionParts",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedOn",
                value: new DateTime(2022, 11, 16, 22, 40, 46, 781, DateTimeKind.Local).AddTicks(3290));

            migrationBuilder.UpdateData(
                table: "ProductionParts",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedOn",
                value: new DateTime(2022, 11, 16, 22, 40, 46, 781, DateTimeKind.Local).AddTicks(3371));

            migrationBuilder.UpdateData(
                table: "ProductionParts",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedOn",
                value: new DateTime(2022, 11, 16, 22, 40, 46, 781, DateTimeKind.Local).AddTicks(3382));

            migrationBuilder.UpdateData(
                table: "ProductionParts",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedOn",
                value: new DateTime(2022, 11, 16, 22, 40, 46, 781, DateTimeKind.Local).AddTicks(3392));

            migrationBuilder.UpdateData(
                table: "PurchasedParts",
                keyColumn: "Id",
                keyValue: 5,
                column: "Image",
                value: "Picture");

            migrationBuilder.UpdateData(
                table: "PurchasedParts",
                keyColumn: "Id",
                keyValue: 6,
                column: "Image",
                value: "Picture");

            migrationBuilder.UpdateData(
                table: "PurchasedParts",
                keyColumn: "Id",
                keyValue: 7,
                column: "Image",
                value: "Picture");

            migrationBuilder.UpdateData(
                table: "PurchasedParts",
                keyColumn: "Id",
                keyValue: 8,
                column: "Image",
                value: "Picture");

            migrationBuilder.UpdateData(
                table: "PurchasedParts",
                keyColumn: "Id",
                keyValue: 9,
                column: "Image",
                value: "Picture");
        }
    }
}
