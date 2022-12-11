using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MachineBuildingFactory.Migrations
{
    public partial class RoleUserAdminManagement : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a6fdd00e-8d80-4b98-894e-0fabfb3bab41",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c70113d1-9d44-4e3a-b5a9-0abfd9ed1e62", "AQAAAAEAACcQAAAAEE3XMxW/2goicCSFcUZpKR+asqTRVFnEKL91LcKP0FQqGJUHNzmaEfFaPAoLJ/nAJA==", "97e3d486-6f05-4c68-9f39-a2bf9a871b4b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a719be14-6ee5-4a10-a1b6-382fc43c4d0b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "979b3458-70c1-44bc-a4da-0da23e72c052", "AQAAAAEAACcQAAAAEGd9Gm7qdn/MM8bnfeS9sudejYleVMQuqfFCu/D6RP6qXJNM02JuabwhF44YFXUd2A==", "fba8f29a-4b87-4314-8aec-8f99012a6fb6" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Department", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "Phone", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Signature", "Title", "TwoFactorEnabled", "UserName" },
                values: new object[] { "3a36e169-5bc9-43c4-a3d1-72ed8aa46bc6", 0, "4a4a0ead-4e48-4885-b904-8c114afa0785", 1, "todor@abv.bg", false, "Todor", "Todorov", true, null, "TODOR@ABV.BG", "TODOR", "AQAAAAEAACcQAAAAEKVpID4qZLxV/2/ECwdCGFDLz067oRczafmeKO4tQMzCRrOaicAZblZsllEFcEvb0A==", "+3596573322", null, false, "06968b9c-2214-4641-9203-28d71cf54519", "TT", 2, false, "todor" });

            migrationBuilder.UpdateData(
                table: "Assemblies",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2022, 12, 10, 23, 18, 6, 130, DateTimeKind.Local).AddTicks(3066));

            migrationBuilder.UpdateData(
                table: "Assemblies",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2022, 12, 10, 23, 18, 6, 130, DateTimeKind.Local).AddTicks(3070));

            migrationBuilder.UpdateData(
                table: "Assemblies",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2022, 12, 10, 23, 18, 6, 130, DateTimeKind.Local).AddTicks(3073));

            migrationBuilder.UpdateData(
                table: "Assemblies",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2022, 12, 10, 23, 18, 6, 130, DateTimeKind.Local).AddTicks(3077));

            migrationBuilder.UpdateData(
                table: "Assemblies",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2022, 12, 10, 23, 18, 6, 130, DateTimeKind.Local).AddTicks(3111));

            migrationBuilder.UpdateData(
                table: "ProductionParts",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2022, 12, 10, 23, 18, 6, 130, DateTimeKind.Local).AddTicks(2957));

            migrationBuilder.UpdateData(
                table: "ProductionParts",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2022, 12, 10, 23, 18, 6, 130, DateTimeKind.Local).AddTicks(2964));

            migrationBuilder.UpdateData(
                table: "ProductionParts",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2022, 12, 10, 23, 18, 6, 130, DateTimeKind.Local).AddTicks(2969));

            migrationBuilder.UpdateData(
                table: "ProductionParts",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2022, 12, 10, 23, 18, 6, 130, DateTimeKind.Local).AddTicks(2973));

            migrationBuilder.UpdateData(
                table: "ProductionParts",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedOn",
                value: new DateTime(2022, 12, 10, 23, 18, 6, 130, DateTimeKind.Local).AddTicks(2978));

            migrationBuilder.UpdateData(
                table: "ProductionParts",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedOn",
                value: new DateTime(2022, 12, 10, 23, 18, 6, 130, DateTimeKind.Local).AddTicks(2982));

            migrationBuilder.UpdateData(
                table: "ProductionParts",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedOn",
                value: new DateTime(2022, 12, 10, 23, 18, 6, 130, DateTimeKind.Local).AddTicks(2986));

            migrationBuilder.UpdateData(
                table: "ProductionParts",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedOn",
                value: new DateTime(2022, 12, 10, 23, 18, 6, 130, DateTimeKind.Local).AddTicks(2991));

            migrationBuilder.UpdateData(
                table: "ProductionParts",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedOn",
                value: new DateTime(2022, 12, 10, 23, 18, 6, 130, DateTimeKind.Local).AddTicks(2995));

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "5602dd52-6eb5-46b5-8e80-c9f88650067e", "3a36e169-5bc9-43c4-a3d1-72ed8aa46bc6" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "5602dd52-6eb5-46b5-8e80-c9f88650067e", "3a36e169-5bc9-43c4-a3d1-72ed8aa46bc6" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3a36e169-5bc9-43c4-a3d1-72ed8aa46bc6");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a6fdd00e-8d80-4b98-894e-0fabfb3bab41",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b57cd04f-3082-4280-8b66-2e2d195914a9", "AQAAAAEAACcQAAAAEKkzMs2OSQqyjMEOCbEofkSqRO+FKYa464fA9h5ZqsLA9L30wOceEX85WsoPGei/8w==", "aa4a6a72-dbad-46c8-83fd-1c221996c0e4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a719be14-6ee5-4a10-a1b6-382fc43c4d0b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "294ccad8-d876-4381-b093-ba6ce72fc8ef", "AQAAAAEAACcQAAAAENx/AZWkoCTnI91S5V2eHY/kZuFcmSzp0B6uZsfNIAZEOhHLmivLinqTNfA/F/nSAw==", "d0945652-3f9c-49ee-883e-dc962fc794d3" });

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
        }
    }
}
