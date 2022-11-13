using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MachineBuildingFactory.Migrations
{
    public partial class initial7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                table: "PurchasedParts",
                newName: "Name");

            migrationBuilder.AlterColumn<string>(
                name: "Standard",
                table: "PurchasedParts",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Assemblies",
                columns: new[] { "Id", "AuthorSignature", "CreatedOn", "Description", "DrawingNumber", "Image", "Name" },
                values: new object[,]
                {
                    { 3, "GG", new DateTime(2022, 11, 12, 10, 26, 53, 572, DateTimeKind.Local).AddTicks(1520), "Base support for hole construction", "CW-001-00", "link to something that I have no yet", "Weld construction" },
                    { 4, "PP", new DateTime(2022, 11, 12, 10, 26, 53, 572, DateTimeKind.Local).AddTicks(1524), "Rotational casting is the best way to make hollow resin parts", "CF-050-00", "link to picture", "Rotational casting machine" }
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Assemblies",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Assemblies",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "PurchasedParts",
                newName: "Title");

            migrationBuilder.AlterColumn<string>(
                name: "Standard",
                table: "PurchasedParts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "ProductionParts",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2022, 11, 9, 19, 37, 5, 967, DateTimeKind.Local).AddTicks(4895));

            migrationBuilder.UpdateData(
                table: "ProductionParts",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2022, 11, 9, 19, 37, 5, 967, DateTimeKind.Local).AddTicks(4907));
        }
    }
}
