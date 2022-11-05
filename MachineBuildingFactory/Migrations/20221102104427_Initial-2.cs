using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MachineBuildingFactory.Migrations
{
    public partial class Initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ColorOfPaint",
                table: "ProductionParts");

            migrationBuilder.RenameColumn(
                name: "Author",
                table: "ProductionParts",
                newName: "SecondTitle");

            migrationBuilder.AddColumn<int>(
                name: "MaterialId",
                table: "ProductionParts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TypeOfPaintId",
                table: "ProductionParts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Material",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeOfMaterial = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    StandardOfMaterial = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Material", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Paint",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RalColor = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TypeOfColor = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paint", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductionParts_MaterialId",
                table: "ProductionParts",
                column: "MaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductionParts_TypeOfPaintId",
                table: "ProductionParts",
                column: "TypeOfPaintId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductionParts_Material_MaterialId",
                table: "ProductionParts",
                column: "MaterialId",
                principalTable: "Material",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductionParts_Paint_TypeOfPaintId",
                table: "ProductionParts",
                column: "TypeOfPaintId",
                principalTable: "Paint",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductionParts_Material_MaterialId",
                table: "ProductionParts");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductionParts_Paint_TypeOfPaintId",
                table: "ProductionParts");

            migrationBuilder.DropTable(
                name: "Material");

            migrationBuilder.DropTable(
                name: "Paint");

            migrationBuilder.DropIndex(
                name: "IX_ProductionParts_MaterialId",
                table: "ProductionParts");

            migrationBuilder.DropIndex(
                name: "IX_ProductionParts_TypeOfPaintId",
                table: "ProductionParts");

            migrationBuilder.DropColumn(
                name: "MaterialId",
                table: "ProductionParts");

            migrationBuilder.DropColumn(
                name: "TypeOfPaintId",
                table: "ProductionParts");

            migrationBuilder.RenameColumn(
                name: "SecondTitle",
                table: "ProductionParts",
                newName: "Author");

            migrationBuilder.AddColumn<string>(
                name: "ColorOfPaint",
                table: "ProductionParts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
