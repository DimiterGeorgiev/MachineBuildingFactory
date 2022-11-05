using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MachineBuildingFactory.Migrations
{
    public partial class Initial3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductionParts_Material_MaterialId",
                table: "ProductionParts");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductionParts_Paint_TypeOfPaintId",
                table: "ProductionParts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Paint",
                table: "Paint");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Material",
                table: "Material");

            migrationBuilder.RenameTable(
                name: "Paint",
                newName: "Paints");

            migrationBuilder.RenameTable(
                name: "Material",
                newName: "Materials");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Paints",
                table: "Paints",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Materials",
                table: "Materials",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductionParts_Materials_MaterialId",
                table: "ProductionParts",
                column: "MaterialId",
                principalTable: "Materials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductionParts_Paints_TypeOfPaintId",
                table: "ProductionParts",
                column: "TypeOfPaintId",
                principalTable: "Paints",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductionParts_Materials_MaterialId",
                table: "ProductionParts");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductionParts_Paints_TypeOfPaintId",
                table: "ProductionParts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Paints",
                table: "Paints");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Materials",
                table: "Materials");

            migrationBuilder.RenameTable(
                name: "Paints",
                newName: "Paint");

            migrationBuilder.RenameTable(
                name: "Materials",
                newName: "Material");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Paint",
                table: "Paint",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Material",
                table: "Material",
                column: "Id");

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
    }
}
