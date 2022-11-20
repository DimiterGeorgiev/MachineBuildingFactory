using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MachineBuildingFactory.Migrations
{
    public partial class WorkingAssembly1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApplicationUserWorkingAssemblies",
                columns: table => new
                {
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AssemblyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUserWorkingAssemblies", x => new { x.ApplicationUserId, x.AssemblyId });
                    table.ForeignKey(
                        name: "FK_ApplicationUserWorkingAssemblies_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicationUserWorkingAssemblies_Assemblies_AssemblyId",
                        column: x => x.AssemblyId,
                        principalTable: "Assemblies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Assemblies",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2022, 11, 20, 10, 34, 57, 405, DateTimeKind.Local).AddTicks(1787));

            migrationBuilder.UpdateData(
                table: "Assemblies",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2022, 11, 20, 10, 34, 57, 405, DateTimeKind.Local).AddTicks(1795));

            migrationBuilder.UpdateData(
                table: "Assemblies",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2022, 11, 20, 10, 34, 57, 405, DateTimeKind.Local).AddTicks(1804));

            migrationBuilder.UpdateData(
                table: "Assemblies",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2022, 11, 20, 10, 34, 57, 405, DateTimeKind.Local).AddTicks(1812));

            migrationBuilder.UpdateData(
                table: "Assemblies",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2022, 11, 20, 10, 34, 57, 405, DateTimeKind.Local).AddTicks(1821));

            migrationBuilder.UpdateData(
                table: "ProductionParts",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2022, 11, 20, 10, 34, 57, 405, DateTimeKind.Local).AddTicks(886));

            migrationBuilder.UpdateData(
                table: "ProductionParts",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2022, 11, 20, 10, 34, 57, 405, DateTimeKind.Local).AddTicks(901));

            migrationBuilder.UpdateData(
                table: "ProductionParts",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2022, 11, 20, 10, 34, 57, 405, DateTimeKind.Local).AddTicks(911));

            migrationBuilder.UpdateData(
                table: "ProductionParts",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2022, 11, 20, 10, 34, 57, 405, DateTimeKind.Local).AddTicks(922));

            migrationBuilder.UpdateData(
                table: "ProductionParts",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedOn",
                value: new DateTime(2022, 11, 20, 10, 34, 57, 405, DateTimeKind.Local).AddTicks(932));

            migrationBuilder.UpdateData(
                table: "ProductionParts",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedOn",
                value: new DateTime(2022, 11, 20, 10, 34, 57, 405, DateTimeKind.Local).AddTicks(942));

            migrationBuilder.UpdateData(
                table: "ProductionParts",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedOn",
                value: new DateTime(2022, 11, 20, 10, 34, 57, 405, DateTimeKind.Local).AddTicks(953));

            migrationBuilder.UpdateData(
                table: "ProductionParts",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedOn",
                value: new DateTime(2022, 11, 20, 10, 34, 57, 405, DateTimeKind.Local).AddTicks(963));

            migrationBuilder.UpdateData(
                table: "ProductionParts",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2022, 11, 20, 10, 34, 57, 405, DateTimeKind.Local).AddTicks(973), "https://files.fm/thumb_show.php?i=wzjth76ag" });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserWorkingAssemblies_AssemblyId",
                table: "ApplicationUserWorkingAssemblies",
                column: "AssemblyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationUserWorkingAssemblies");

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
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2022, 11, 20, 9, 44, 6, 80, DateTimeKind.Local).AddTicks(9834), "Picture" });
        }
    }
}
