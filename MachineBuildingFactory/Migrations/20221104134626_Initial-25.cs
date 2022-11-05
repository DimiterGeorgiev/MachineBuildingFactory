using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MachineBuildingFactory.Migrations
{
    public partial class Initial25 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OwnerId",
                table: "ProductionParts",
                newName: "AuthorSignature");

            migrationBuilder.RenameColumn(
                name: "Title2",
                table: "Assemblies",
                newName: "SecondTitle");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AuthorSignature",
                table: "ProductionParts",
                newName: "OwnerId");

            migrationBuilder.RenameColumn(
                name: "SecondTitle",
                table: "Assemblies",
                newName: "Title2");
        }
    }
}
