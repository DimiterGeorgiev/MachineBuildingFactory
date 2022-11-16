using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MachineBuildingFactory.Migrations
{
    public partial class initial11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Assemblies",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2022, 11, 16, 22, 40, 46, 781, DateTimeKind.Local).AddTicks(3727), "https://files.fm/thumb_show.php?i=e3en9mxbj" });

            migrationBuilder.UpdateData(
                table: "Assemblies",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2022, 11, 16, 22, 40, 46, 781, DateTimeKind.Local).AddTicks(3736), "https://files.fm/thumb_show.php?i=rcgp3g9nf" });

            migrationBuilder.UpdateData(
                table: "Assemblies",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2022, 11, 16, 22, 40, 46, 781, DateTimeKind.Local).AddTicks(3744), "https://files.fm/thumb_show.php?i=rafszmvtu" });

            migrationBuilder.UpdateData(
                table: "Assemblies",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2022, 11, 16, 22, 40, 46, 781, DateTimeKind.Local).AddTicks(3753), "https://files.fm/thumb_show.php?i=zqg8235n3" });

            migrationBuilder.UpdateData(
                table: "Assemblies",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2022, 11, 16, 22, 40, 46, 781, DateTimeKind.Local).AddTicks(3762), "https://files.fm/thumb_show.php?i=8ug7rbkqh" });

            migrationBuilder.UpdateData(
                table: "ProductionParts",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2022, 11, 16, 22, 40, 46, 781, DateTimeKind.Local).AddTicks(3234), "https://files.fm/thumb_show.php?i=wuvwwvyyu" });

            migrationBuilder.UpdateData(
                table: "ProductionParts",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2022, 11, 16, 22, 40, 46, 781, DateTimeKind.Local).AddTicks(3251), "https://files.fm/thumb_show.php?i=yanftmubg" });

            migrationBuilder.UpdateData(
                table: "ProductionParts",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2022, 11, 16, 22, 40, 46, 781, DateTimeKind.Local).AddTicks(3261), "https://files.fm/thumb_show.php?i=avqbb8jgk" });

            migrationBuilder.UpdateData(
                table: "ProductionParts",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2022, 11, 16, 22, 40, 46, 781, DateTimeKind.Local).AddTicks(3271), "https://files.fm/thumb_show.php?i=n62awsh2s" });

            migrationBuilder.UpdateData(
                table: "ProductionParts",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2022, 11, 16, 22, 40, 46, 781, DateTimeKind.Local).AddTicks(3281), "https://files.fm/thumb_show.php?i=qjugekfuf" });

            migrationBuilder.UpdateData(
                table: "ProductionParts",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2022, 11, 16, 22, 40, 46, 781, DateTimeKind.Local).AddTicks(3290), "https://files.fm/thumb_show.php?i=2y4zzx6pb" });

            migrationBuilder.UpdateData(
                table: "ProductionParts",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2022, 11, 16, 22, 40, 46, 781, DateTimeKind.Local).AddTicks(3371), "https://files.fm/thumb_show.php?i=8a2t5t9z9" });

            migrationBuilder.UpdateData(
                table: "ProductionParts",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2022, 11, 16, 22, 40, 46, 781, DateTimeKind.Local).AddTicks(3382), "https://files.fm/thumb_show.php?i=2gqgfmt48" });

            migrationBuilder.InsertData(
                table: "ProductionParts",
                columns: new[] { "Id", "AuthorSignature", "ColorOfPaintRal", "CreatedOn", "Description", "DrawingNumber", "Image", "LaserCutLength", "MaterialId", "Name", "SurfaceArea", "SurfaceTreatment", "TypeOfPaint", "TypeOfProductionPartId", "Weight" },
                values: new object[] { 13, "DD", 1, new DateTime(2022, 11, 16, 22, 40, 46, 781, DateTimeKind.Local).AddTicks(3392), "Thsi Part breaks the DetailView", "BV-000-001", "Picture", 0.0, 1, "Break Details", 1.2, 1, 1, 2, 5.5999999999999996 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProductionParts",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.UpdateData(
                table: "Assemblies",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2022, 11, 13, 10, 25, 37, 458, DateTimeKind.Local).AddTicks(7901), "link to something that I have no yet" });

            migrationBuilder.UpdateData(
                table: "Assemblies",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2022, 11, 13, 10, 25, 37, 458, DateTimeKind.Local).AddTicks(7905), "link to picture" });

            migrationBuilder.UpdateData(
                table: "Assemblies",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2022, 11, 13, 10, 25, 37, 458, DateTimeKind.Local).AddTicks(7909), "link to picture" });

            migrationBuilder.UpdateData(
                table: "Assemblies",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2022, 11, 13, 10, 25, 37, 458, DateTimeKind.Local).AddTicks(7913), "link to picture" });

            migrationBuilder.UpdateData(
                table: "Assemblies",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2022, 11, 13, 10, 25, 37, 458, DateTimeKind.Local).AddTicks(7917), "link to picture" });

            migrationBuilder.UpdateData(
                table: "ProductionParts",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2022, 11, 13, 10, 25, 37, 458, DateTimeKind.Local).AddTicks(7669), "Picture" });

            migrationBuilder.UpdateData(
                table: "ProductionParts",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2022, 11, 13, 10, 25, 37, 458, DateTimeKind.Local).AddTicks(7677), "Picture" });

            migrationBuilder.UpdateData(
                table: "ProductionParts",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2022, 11, 13, 10, 25, 37, 458, DateTimeKind.Local).AddTicks(7681), "Picture" });

            migrationBuilder.UpdateData(
                table: "ProductionParts",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2022, 11, 13, 10, 25, 37, 458, DateTimeKind.Local).AddTicks(7686), "Picture" });

            migrationBuilder.UpdateData(
                table: "ProductionParts",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2022, 11, 13, 10, 25, 37, 458, DateTimeKind.Local).AddTicks(7691), "Picture" });

            migrationBuilder.UpdateData(
                table: "ProductionParts",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2022, 11, 13, 10, 25, 37, 458, DateTimeKind.Local).AddTicks(7695), "Picture" });

            migrationBuilder.UpdateData(
                table: "ProductionParts",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2022, 11, 13, 10, 25, 37, 458, DateTimeKind.Local).AddTicks(7700), "Picture" });

            migrationBuilder.UpdateData(
                table: "ProductionParts",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2022, 11, 13, 10, 25, 37, 458, DateTimeKind.Local).AddTicks(7705), "Picture" });
        }
    }
}
