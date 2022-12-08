using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MachineBuildingFactory.Migrations
{
    public partial class RoleAdmin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cadc8910-5d74-4791-aad9-3523e2fd2468",
                columns: new[] { "Name", "NormalizedName" },
                values: new object[] { "Admin", "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5602dd52-6eb5-46b5-8e80-c9f88650067e", "3", "User", "User" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a719be14-6ee5-4a10-a1b6-382fc43c4d0b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "294ccad8-d876-4381-b093-ba6ce72fc8ef", "AQAAAAEAACcQAAAAENx/AZWkoCTnI91S5V2eHY/kZuFcmSzp0B6uZsfNIAZEOhHLmivLinqTNfA/F/nSAw==", "d0945652-3f9c-49ee-883e-dc962fc794d3" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Department", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "Phone", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Signature", "Title", "TwoFactorEnabled", "UserName" },
                values: new object[] { "a6fdd00e-8d80-4b98-894e-0fabfb3bab41", 0, "b57cd04f-3082-4280-8b66-2e2d195914a9", 4, "georgi@abv.bg", false, "Georgi", "Georgiev", true, null, "GEORGI@ABV.BG", "GEORGI", "AQAAAAEAACcQAAAAEKkzMs2OSQqyjMEOCbEofkSqRO+FKYa464fA9h5ZqsLA9L30wOceEX85WsoPGei/8w==", "+3596578569", null, false, "aa4a6a72-dbad-46c8-83fd-1c221996c0e4", "GG", 3, false, "georgi" });

            migrationBuilder.UpdateData(
                table: "Assemblies",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2022, 12, 6, 11, 13, 54, 218, DateTimeKind.Local).AddTicks(7839));

            migrationBuilder.UpdateData(
                table: "Assemblies",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2022, 12, 6, 11, 13, 54, 218, DateTimeKind.Local).AddTicks(7844));

            migrationBuilder.UpdateData(
                table: "Assemblies",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2022, 12, 6, 11, 13, 54, 218, DateTimeKind.Local).AddTicks(7848));

            migrationBuilder.UpdateData(
                table: "Assemblies",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2022, 12, 6, 11, 13, 54, 218, DateTimeKind.Local).AddTicks(7852));

            migrationBuilder.UpdateData(
                table: "Assemblies",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2022, 12, 6, 11, 13, 54, 218, DateTimeKind.Local).AddTicks(7855));

            migrationBuilder.UpdateData(
                table: "ProductionParts",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2022, 12, 6, 11, 13, 54, 218, DateTimeKind.Local).AddTicks(7714));

            migrationBuilder.UpdateData(
                table: "ProductionParts",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2022, 12, 6, 11, 13, 54, 218, DateTimeKind.Local).AddTicks(7722));

            migrationBuilder.UpdateData(
                table: "ProductionParts",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2022, 12, 6, 11, 13, 54, 218, DateTimeKind.Local).AddTicks(7727));

            migrationBuilder.UpdateData(
                table: "ProductionParts",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2022, 12, 6, 11, 13, 54, 218, DateTimeKind.Local).AddTicks(7731));

            migrationBuilder.UpdateData(
                table: "ProductionParts",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedOn",
                value: new DateTime(2022, 12, 6, 11, 13, 54, 218, DateTimeKind.Local).AddTicks(7736));

            migrationBuilder.UpdateData(
                table: "ProductionParts",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedOn",
                value: new DateTime(2022, 12, 6, 11, 13, 54, 218, DateTimeKind.Local).AddTicks(7741));

            migrationBuilder.UpdateData(
                table: "ProductionParts",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedOn",
                value: new DateTime(2022, 12, 6, 11, 13, 54, 218, DateTimeKind.Local).AddTicks(7746));

            migrationBuilder.UpdateData(
                table: "ProductionParts",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedOn",
                value: new DateTime(2022, 12, 6, 11, 13, 54, 218, DateTimeKind.Local).AddTicks(7751));

            migrationBuilder.UpdateData(
                table: "ProductionParts",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedOn",
                value: new DateTime(2022, 12, 6, 11, 13, 54, 218, DateTimeKind.Local).AddTicks(7755));

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "cadc8910-5d74-4791-aad9-3523e2fd2468", "a6fdd00e-8d80-4b98-894e-0fabfb3bab41" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5602dd52-6eb5-46b5-8e80-c9f88650067e");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "cadc8910-5d74-4791-aad9-3523e2fd2468", "a6fdd00e-8d80-4b98-894e-0fabfb3bab41" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a6fdd00e-8d80-4b98-894e-0fabfb3bab41");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cadc8910-5d74-4791-aad9-3523e2fd2468",
                columns: new[] { "Name", "NormalizedName" },
                values: new object[] { "IT", "IT" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a719be14-6ee5-4a10-a1b6-382fc43c4d0b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b5e95049-002e-440b-a2ac-475a6c5da28e", "AQAAAAEAACcQAAAAEP2Bes0gmrv0P/V2EeeSBhCHCkOFQn8Qxs1/rETajIi41vYHgffaMXcP0tC/t8k+/g==", "52683d01-376b-4312-9bd4-bbef08f24def" });

            migrationBuilder.UpdateData(
                table: "Assemblies",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2022, 12, 3, 17, 16, 33, 969, DateTimeKind.Local).AddTicks(980));

            migrationBuilder.UpdateData(
                table: "Assemblies",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2022, 12, 3, 17, 16, 33, 969, DateTimeKind.Local).AddTicks(984));

            migrationBuilder.UpdateData(
                table: "Assemblies",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2022, 12, 3, 17, 16, 33, 969, DateTimeKind.Local).AddTicks(988));

            migrationBuilder.UpdateData(
                table: "Assemblies",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2022, 12, 3, 17, 16, 33, 969, DateTimeKind.Local).AddTicks(991));

            migrationBuilder.UpdateData(
                table: "Assemblies",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2022, 12, 3, 17, 16, 33, 969, DateTimeKind.Local).AddTicks(995));

            migrationBuilder.UpdateData(
                table: "ProductionParts",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2022, 12, 3, 17, 16, 33, 969, DateTimeKind.Local).AddTicks(828));

            migrationBuilder.UpdateData(
                table: "ProductionParts",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2022, 12, 3, 17, 16, 33, 969, DateTimeKind.Local).AddTicks(835));

            migrationBuilder.UpdateData(
                table: "ProductionParts",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2022, 12, 3, 17, 16, 33, 969, DateTimeKind.Local).AddTicks(840));

            migrationBuilder.UpdateData(
                table: "ProductionParts",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2022, 12, 3, 17, 16, 33, 969, DateTimeKind.Local).AddTicks(844));

            migrationBuilder.UpdateData(
                table: "ProductionParts",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedOn",
                value: new DateTime(2022, 12, 3, 17, 16, 33, 969, DateTimeKind.Local).AddTicks(848));

            migrationBuilder.UpdateData(
                table: "ProductionParts",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedOn",
                value: new DateTime(2022, 12, 3, 17, 16, 33, 969, DateTimeKind.Local).AddTicks(853));

            migrationBuilder.UpdateData(
                table: "ProductionParts",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedOn",
                value: new DateTime(2022, 12, 3, 17, 16, 33, 969, DateTimeKind.Local).AddTicks(858));

            migrationBuilder.UpdateData(
                table: "ProductionParts",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedOn",
                value: new DateTime(2022, 12, 3, 17, 16, 33, 969, DateTimeKind.Local).AddTicks(862));

            migrationBuilder.UpdateData(
                table: "ProductionParts",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedOn",
                value: new DateTime(2022, 12, 3, 17, 16, 33, 969, DateTimeKind.Local).AddTicks(866));
        }
    }
}
