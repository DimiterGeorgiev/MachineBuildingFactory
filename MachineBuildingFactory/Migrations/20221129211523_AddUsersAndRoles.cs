using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MachineBuildingFactory.Migrations
{
    public partial class AddUsersAndRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "22505c77-35fc-436d-bc42-2c3f3b34bc2b");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2fec21bf-85f5-490a-9998-cf73c1c3c194");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "236787a2-4edc-492e-acb2-5f4a00ade9e3", "1", "Management", "Management" },
                    { "cadc8910-5d74-4791-aad9-3523e2fd2468", "2", "IT", "IT" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Department", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "Phone", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Signature", "Title", "TwoFactorEnabled", "UserName" },
                values: new object[] { "a719be14-6ee5-4a10-a1b6-382fc43c4d0b", 0, "16c29914-0184-4f92-bd8e-af843d24aa97", 0, "peter@abv.bg", false, "Peter", "Petrov", false, null, null, null, null, "+3596598665", null, false, "d15b392a-35ac-4af2-bb7c-d85aab153a03", "PP", 2, false, "peter" });

            migrationBuilder.UpdateData(
                table: "Assemblies",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2022, 11, 29, 22, 15, 21, 845, DateTimeKind.Local).AddTicks(7728));

            migrationBuilder.UpdateData(
                table: "Assemblies",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2022, 11, 29, 22, 15, 21, 845, DateTimeKind.Local).AddTicks(7741));

            migrationBuilder.UpdateData(
                table: "Assemblies",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2022, 11, 29, 22, 15, 21, 845, DateTimeKind.Local).AddTicks(7754));

            migrationBuilder.UpdateData(
                table: "Assemblies",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2022, 11, 29, 22, 15, 21, 845, DateTimeKind.Local).AddTicks(7766));

            migrationBuilder.UpdateData(
                table: "Assemblies",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2022, 11, 29, 22, 15, 21, 845, DateTimeKind.Local).AddTicks(7774));

            migrationBuilder.UpdateData(
                table: "ProductionParts",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2022, 11, 29, 22, 15, 21, 845, DateTimeKind.Local).AddTicks(7321));

            migrationBuilder.UpdateData(
                table: "ProductionParts",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2022, 11, 29, 22, 15, 21, 845, DateTimeKind.Local).AddTicks(7336));

            migrationBuilder.UpdateData(
                table: "ProductionParts",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2022, 11, 29, 22, 15, 21, 845, DateTimeKind.Local).AddTicks(7346));

            migrationBuilder.UpdateData(
                table: "ProductionParts",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2022, 11, 29, 22, 15, 21, 845, DateTimeKind.Local).AddTicks(7356));

            migrationBuilder.UpdateData(
                table: "ProductionParts",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedOn",
                value: new DateTime(2022, 11, 29, 22, 15, 21, 845, DateTimeKind.Local).AddTicks(7366));

            migrationBuilder.UpdateData(
                table: "ProductionParts",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedOn",
                value: new DateTime(2022, 11, 29, 22, 15, 21, 845, DateTimeKind.Local).AddTicks(7376));

            migrationBuilder.UpdateData(
                table: "ProductionParts",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedOn",
                value: new DateTime(2022, 11, 29, 22, 15, 21, 845, DateTimeKind.Local).AddTicks(7386));

            migrationBuilder.UpdateData(
                table: "ProductionParts",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedOn",
                value: new DateTime(2022, 11, 29, 22, 15, 21, 845, DateTimeKind.Local).AddTicks(7395));

            migrationBuilder.UpdateData(
                table: "ProductionParts",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedOn",
                value: new DateTime(2022, 11, 29, 22, 15, 21, 845, DateTimeKind.Local).AddTicks(7405));

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "236787a2-4edc-492e-acb2-5f4a00ade9e3", "a719be14-6ee5-4a10-a1b6-382fc43c4d0b" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cadc8910-5d74-4791-aad9-3523e2fd2468");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "236787a2-4edc-492e-acb2-5f4a00ade9e3", "a719be14-6ee5-4a10-a1b6-382fc43c4d0b" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "236787a2-4edc-492e-acb2-5f4a00ade9e3");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a719be14-6ee5-4a10-a1b6-382fc43c4d0b");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Department", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "Phone", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Signature", "Title", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "22505c77-35fc-436d-bc42-2c3f3b34bc2b", 0, "dd7350d7-0598-4c65-af2a-26ed29eb1120", 2, "todor@abv.bg", false, "Todor", "Todorv", false, null, null, null, "123aA!", "+35963256584", null, false, "1a033000-30f1-41ff-a857-906d1d33dc45", "TT", 3, false, "todor" },
                    { "2fec21bf-85f5-490a-9998-cf73c1c3c194", 0, "a9a6eb3a-d902-4625-8d28-6b337f93828b", 1, "peter@abv.bg", false, "Peter", "Petrov", false, null, null, null, "123aA!", "+3596598665", null, false, "60b6c123-1e63-4909-9a03-58077a175711", "PP", 2, false, "peter" }
                });

            migrationBuilder.UpdateData(
                table: "Assemblies",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2022, 11, 29, 20, 33, 6, 409, DateTimeKind.Local).AddTicks(4898));

            migrationBuilder.UpdateData(
                table: "Assemblies",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2022, 11, 29, 20, 33, 6, 409, DateTimeKind.Local).AddTicks(4909));

            migrationBuilder.UpdateData(
                table: "Assemblies",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2022, 11, 29, 20, 33, 6, 409, DateTimeKind.Local).AddTicks(4917));

            migrationBuilder.UpdateData(
                table: "Assemblies",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2022, 11, 29, 20, 33, 6, 409, DateTimeKind.Local).AddTicks(4928));

            migrationBuilder.UpdateData(
                table: "Assemblies",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2022, 11, 29, 20, 33, 6, 409, DateTimeKind.Local).AddTicks(4937));

            migrationBuilder.UpdateData(
                table: "ProductionParts",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2022, 11, 29, 20, 33, 6, 409, DateTimeKind.Local).AddTicks(4469));

            migrationBuilder.UpdateData(
                table: "ProductionParts",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2022, 11, 29, 20, 33, 6, 409, DateTimeKind.Local).AddTicks(4485));

            migrationBuilder.UpdateData(
                table: "ProductionParts",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2022, 11, 29, 20, 33, 6, 409, DateTimeKind.Local).AddTicks(4495));

            migrationBuilder.UpdateData(
                table: "ProductionParts",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2022, 11, 29, 20, 33, 6, 409, DateTimeKind.Local).AddTicks(4505));

            migrationBuilder.UpdateData(
                table: "ProductionParts",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedOn",
                value: new DateTime(2022, 11, 29, 20, 33, 6, 409, DateTimeKind.Local).AddTicks(4516));

            migrationBuilder.UpdateData(
                table: "ProductionParts",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedOn",
                value: new DateTime(2022, 11, 29, 20, 33, 6, 409, DateTimeKind.Local).AddTicks(4526));

            migrationBuilder.UpdateData(
                table: "ProductionParts",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedOn",
                value: new DateTime(2022, 11, 29, 20, 33, 6, 409, DateTimeKind.Local).AddTicks(4537));

            migrationBuilder.UpdateData(
                table: "ProductionParts",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedOn",
                value: new DateTime(2022, 11, 29, 20, 33, 6, 409, DateTimeKind.Local).AddTicks(4547));

            migrationBuilder.UpdateData(
                table: "ProductionParts",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedOn",
                value: new DateTime(2022, 11, 29, 20, 33, 6, 409, DateTimeKind.Local).AddTicks(4557));
        }
    }
}
