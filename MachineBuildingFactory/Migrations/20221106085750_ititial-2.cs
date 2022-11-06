using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MachineBuildingFactory.Migrations
{
    public partial class ititial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductionParts_TypeOfProductionPart_TypeOfProductionPartId",
                table: "ProductionParts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TypeOfProductionPart",
                table: "TypeOfProductionPart");

            migrationBuilder.DropColumn(
                name: "SecondTitle",
                table: "ProductionParts");

            migrationBuilder.RenameTable(
                name: "TypeOfProductionPart",
                newName: "TypeOfProductionParts");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "ProductionParts",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Surface",
                table: "ProductionParts",
                newName: "SurfaceArea");

            migrationBuilder.AlterColumn<string>(
                name: "MaterialNumber",
                table: "Materials",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 50);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TypeOfProductionParts",
                table: "TypeOfProductionParts",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Materials",
                columns: new[] { "Id", "MaterialNumber" },
                values: new object[,]
                {
                    { 1, "1.0038" },
                    { 2, "1.8714" },
                    { 3, "1.5786" },
                    { 4, "1.4302" },
                    { 5, "1.7025" }
                });

            migrationBuilder.InsertData(
                table: "TypeOfProductionParts",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "MechanicallyProcessed" },
                    { 2, "Sheetmetal" },
                    { 3, "Weldconstruction" },
                    { 4, "Lasercut" },
                    { 5, "Cast" }
                });

            migrationBuilder.InsertData(
                table: "ProductionParts",
                columns: new[] { "Id", "AuthorSignature", "ColorOfPaintRal", "CreatedOn", "Description", "DrawingNumber", "Image", "LaserCutLength", "MaterialId", "Name", "SurfaceArea", "SurfaceTreatment", "TypeOfPaint", "TypeOfProductionPartId", "Weight" },
                values: new object[] { 5, "PP", 3, new DateTime(2022, 11, 6, 9, 57, 49, 917, DateTimeKind.Local).AddTicks(613), "This is just a probe part.", "CL-025-001", "Picture", 4.2999999999999998, 2, "Consol", 2.2999999999999998, 1, 2, 1, 5.5999999999999996 });

            migrationBuilder.AddForeignKey(
                name: "FK_ProductionParts_TypeOfProductionParts_TypeOfProductionPartId",
                table: "ProductionParts",
                column: "TypeOfProductionPartId",
                principalTable: "TypeOfProductionParts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductionParts_TypeOfProductionParts_TypeOfProductionPartId",
                table: "ProductionParts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TypeOfProductionParts",
                table: "TypeOfProductionParts");

            migrationBuilder.DeleteData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ProductionParts",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "TypeOfProductionParts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TypeOfProductionParts",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TypeOfProductionParts",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "TypeOfProductionParts",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TypeOfProductionParts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.RenameTable(
                name: "TypeOfProductionParts",
                newName: "TypeOfProductionPart");

            migrationBuilder.RenameColumn(
                name: "SurfaceArea",
                table: "ProductionParts",
                newName: "Surface");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "ProductionParts",
                newName: "Title");

            migrationBuilder.AddColumn<string>(
                name: "SecondTitle",
                table: "ProductionParts",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "MaterialNumber",
                table: "Materials",
                type: "int",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TypeOfProductionPart",
                table: "TypeOfProductionPart",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductionParts_TypeOfProductionPart_TypeOfProductionPartId",
                table: "ProductionParts",
                column: "TypeOfProductionPartId",
                principalTable: "TypeOfProductionPart",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
