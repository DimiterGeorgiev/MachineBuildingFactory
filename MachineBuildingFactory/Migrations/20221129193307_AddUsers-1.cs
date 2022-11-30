using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MachineBuildingFactory.Migrations
{
    public partial class AddUsers1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                columns: new[] { "CreatedOn", "Name" },
                values: new object[] { new DateTime(2022, 11, 29, 20, 33, 6, 409, DateTimeKind.Local).AddTicks(4557), "Just Details" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "22505c77-35fc-436d-bc42-2c3f3b34bc2b");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2fec21bf-85f5-490a-9998-cf73c1c3c194");

            migrationBuilder.UpdateData(
                table: "Assemblies",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2022, 11, 23, 18, 22, 8, 864, DateTimeKind.Local).AddTicks(101));

            migrationBuilder.UpdateData(
                table: "Assemblies",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2022, 11, 23, 18, 22, 8, 864, DateTimeKind.Local).AddTicks(111));

            migrationBuilder.UpdateData(
                table: "Assemblies",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2022, 11, 23, 18, 22, 8, 864, DateTimeKind.Local).AddTicks(120));

            migrationBuilder.UpdateData(
                table: "Assemblies",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2022, 11, 23, 18, 22, 8, 864, DateTimeKind.Local).AddTicks(129));

            migrationBuilder.UpdateData(
                table: "Assemblies",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2022, 11, 23, 18, 22, 8, 864, DateTimeKind.Local).AddTicks(138));

            migrationBuilder.UpdateData(
                table: "ProductionParts",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2022, 11, 23, 18, 22, 8, 863, DateTimeKind.Local).AddTicks(9743));

            migrationBuilder.UpdateData(
                table: "ProductionParts",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2022, 11, 23, 18, 22, 8, 863, DateTimeKind.Local).AddTicks(9757));

            migrationBuilder.UpdateData(
                table: "ProductionParts",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2022, 11, 23, 18, 22, 8, 863, DateTimeKind.Local).AddTicks(9766));

            migrationBuilder.UpdateData(
                table: "ProductionParts",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2022, 11, 23, 18, 22, 8, 863, DateTimeKind.Local).AddTicks(9776));

            migrationBuilder.UpdateData(
                table: "ProductionParts",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedOn",
                value: new DateTime(2022, 11, 23, 18, 22, 8, 863, DateTimeKind.Local).AddTicks(9785));

            migrationBuilder.UpdateData(
                table: "ProductionParts",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedOn",
                value: new DateTime(2022, 11, 23, 18, 22, 8, 863, DateTimeKind.Local).AddTicks(9794));

            migrationBuilder.UpdateData(
                table: "ProductionParts",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedOn",
                value: new DateTime(2022, 11, 23, 18, 22, 8, 863, DateTimeKind.Local).AddTicks(9803));

            migrationBuilder.UpdateData(
                table: "ProductionParts",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedOn",
                value: new DateTime(2022, 11, 23, 18, 22, 8, 863, DateTimeKind.Local).AddTicks(9812));

            migrationBuilder.UpdateData(
                table: "ProductionParts",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedOn", "Name" },
                values: new object[] { new DateTime(2022, 11, 23, 18, 22, 8, 863, DateTimeKind.Local).AddTicks(9822), "Break Details" });
        }
    }
}
