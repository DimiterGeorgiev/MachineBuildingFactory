using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MachineBuildingFactory.Migrations
{
    public partial class initial5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Image",
                table: "ProductionParts",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "DrawingNumber",
                table: "ProductionParts",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "AuthorSignature",
                table: "ProductionParts",
                type: "nvarchar(3)",
                maxLength: 3,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "ProductionParts",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2022, 11, 7, 22, 46, 12, 141, DateTimeKind.Local).AddTicks(2877));

            migrationBuilder.UpdateData(
                table: "ProductionParts",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2022, 11, 7, 22, 46, 12, 141, DateTimeKind.Local).AddTicks(2893));

            migrationBuilder.UpdateData(
                table: "TypeOfProductionParts",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Mechanically processed");

            migrationBuilder.UpdateData(
                table: "TypeOfProductionParts",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Sheet metal");

            migrationBuilder.UpdateData(
                table: "TypeOfProductionParts",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Weld construction");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Image",
                table: "ProductionParts",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "DrawingNumber",
                table: "ProductionParts",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldMaxLength: 15);

            migrationBuilder.AlterColumn<string>(
                name: "AuthorSignature",
                table: "ProductionParts",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(3)",
                oldMaxLength: 3);

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

            migrationBuilder.UpdateData(
                table: "TypeOfProductionParts",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "MechanicallyProcessed");

            migrationBuilder.UpdateData(
                table: "TypeOfProductionParts",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Sheetmetal");

            migrationBuilder.UpdateData(
                table: "TypeOfProductionParts",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Weldconstruction");
        }
    }
}
