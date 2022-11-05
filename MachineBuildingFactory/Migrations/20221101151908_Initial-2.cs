using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MachineBuildingFactory.Migrations
{
    public partial class Initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssemblyProductionPart_Assembly_AssemblyId",
                table: "AssemblyProductionPart");

            migrationBuilder.DropForeignKey(
                name: "FK_AssemblyProductionPart_ProductionParts_ProductionPartId",
                table: "AssemblyProductionPart");

            migrationBuilder.DropForeignKey(
                name: "FK_AssemblyPurchasedPart_Assembly_AssemblyId",
                table: "AssemblyPurchasedPart");

            migrationBuilder.DropForeignKey(
                name: "FK_AssemblyPurchasedPart_PurchasedParts_PurchasedPartId",
                table: "AssemblyPurchasedPart");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchasedParts_Manufacturer_ManufacturerId",
                table: "PurchasedParts");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchasedParts_Supplier_SupplierId",
                table: "PurchasedParts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Supplier",
                table: "Supplier");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Manufacturer",
                table: "Manufacturer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AssemblyPurchasedPart",
                table: "AssemblyPurchasedPart");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AssemblyProductionPart",
                table: "AssemblyProductionPart");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Assembly",
                table: "Assembly");

            migrationBuilder.RenameTable(
                name: "Supplier",
                newName: "Suppliers");

            migrationBuilder.RenameTable(
                name: "Manufacturer",
                newName: "Manufacturers");

            migrationBuilder.RenameTable(
                name: "AssemblyPurchasedPart",
                newName: "AssemblyPurchasedParts");

            migrationBuilder.RenameTable(
                name: "AssemblyProductionPart",
                newName: "AssemblyProductionParts");

            migrationBuilder.RenameTable(
                name: "Assembly",
                newName: "Assemblies");

            migrationBuilder.RenameIndex(
                name: "IX_AssemblyPurchasedPart_PurchasedPartId",
                table: "AssemblyPurchasedParts",
                newName: "IX_AssemblyPurchasedParts_PurchasedPartId");

            migrationBuilder.RenameIndex(
                name: "IX_AssemblyProductionPart_ProductionPartId",
                table: "AssemblyProductionParts",
                newName: "IX_AssemblyProductionParts_ProductionPartId");

            migrationBuilder.AddColumn<double>(
                name: "LaserCutLength",
                table: "ProductionParts",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Suppliers",
                table: "Suppliers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Manufacturers",
                table: "Manufacturers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AssemblyPurchasedParts",
                table: "AssemblyPurchasedParts",
                columns: new[] { "AssemblyId", "PurchasedPartId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AssemblyProductionParts",
                table: "AssemblyProductionParts",
                columns: new[] { "AssemblyId", "ProductionPartId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Assemblies",
                table: "Assemblies",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AssemblyProductionParts_Assemblies_AssemblyId",
                table: "AssemblyProductionParts",
                column: "AssemblyId",
                principalTable: "Assemblies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AssemblyProductionParts_ProductionParts_ProductionPartId",
                table: "AssemblyProductionParts",
                column: "ProductionPartId",
                principalTable: "ProductionParts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AssemblyPurchasedParts_Assemblies_AssemblyId",
                table: "AssemblyPurchasedParts",
                column: "AssemblyId",
                principalTable: "Assemblies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AssemblyPurchasedParts_PurchasedParts_PurchasedPartId",
                table: "AssemblyPurchasedParts",
                column: "PurchasedPartId",
                principalTable: "PurchasedParts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchasedParts_Manufacturers_ManufacturerId",
                table: "PurchasedParts",
                column: "ManufacturerId",
                principalTable: "Manufacturers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchasedParts_Suppliers_SupplierId",
                table: "PurchasedParts",
                column: "SupplierId",
                principalTable: "Suppliers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssemblyProductionParts_Assemblies_AssemblyId",
                table: "AssemblyProductionParts");

            migrationBuilder.DropForeignKey(
                name: "FK_AssemblyProductionParts_ProductionParts_ProductionPartId",
                table: "AssemblyProductionParts");

            migrationBuilder.DropForeignKey(
                name: "FK_AssemblyPurchasedParts_Assemblies_AssemblyId",
                table: "AssemblyPurchasedParts");

            migrationBuilder.DropForeignKey(
                name: "FK_AssemblyPurchasedParts_PurchasedParts_PurchasedPartId",
                table: "AssemblyPurchasedParts");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchasedParts_Manufacturers_ManufacturerId",
                table: "PurchasedParts");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchasedParts_Suppliers_SupplierId",
                table: "PurchasedParts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Suppliers",
                table: "Suppliers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Manufacturers",
                table: "Manufacturers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AssemblyPurchasedParts",
                table: "AssemblyPurchasedParts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AssemblyProductionParts",
                table: "AssemblyProductionParts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Assemblies",
                table: "Assemblies");

            migrationBuilder.DropColumn(
                name: "LaserCutLength",
                table: "ProductionParts");

            migrationBuilder.RenameTable(
                name: "Suppliers",
                newName: "Supplier");

            migrationBuilder.RenameTable(
                name: "Manufacturers",
                newName: "Manufacturer");

            migrationBuilder.RenameTable(
                name: "AssemblyPurchasedParts",
                newName: "AssemblyPurchasedPart");

            migrationBuilder.RenameTable(
                name: "AssemblyProductionParts",
                newName: "AssemblyProductionPart");

            migrationBuilder.RenameTable(
                name: "Assemblies",
                newName: "Assembly");

            migrationBuilder.RenameIndex(
                name: "IX_AssemblyPurchasedParts_PurchasedPartId",
                table: "AssemblyPurchasedPart",
                newName: "IX_AssemblyPurchasedPart_PurchasedPartId");

            migrationBuilder.RenameIndex(
                name: "IX_AssemblyProductionParts_ProductionPartId",
                table: "AssemblyProductionPart",
                newName: "IX_AssemblyProductionPart_ProductionPartId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Supplier",
                table: "Supplier",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Manufacturer",
                table: "Manufacturer",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AssemblyPurchasedPart",
                table: "AssemblyPurchasedPart",
                columns: new[] { "AssemblyId", "PurchasedPartId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AssemblyProductionPart",
                table: "AssemblyProductionPart",
                columns: new[] { "AssemblyId", "ProductionPartId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Assembly",
                table: "Assembly",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AssemblyProductionPart_Assembly_AssemblyId",
                table: "AssemblyProductionPart",
                column: "AssemblyId",
                principalTable: "Assembly",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AssemblyProductionPart_ProductionParts_ProductionPartId",
                table: "AssemblyProductionPart",
                column: "ProductionPartId",
                principalTable: "ProductionParts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AssemblyPurchasedPart_Assembly_AssemblyId",
                table: "AssemblyPurchasedPart",
                column: "AssemblyId",
                principalTable: "Assembly",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AssemblyPurchasedPart_PurchasedParts_PurchasedPartId",
                table: "AssemblyPurchasedPart",
                column: "PurchasedPartId",
                principalTable: "PurchasedParts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchasedParts_Manufacturer_ManufacturerId",
                table: "PurchasedParts",
                column: "ManufacturerId",
                principalTable: "Manufacturer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchasedParts_Supplier_SupplierId",
                table: "PurchasedParts",
                column: "SupplierId",
                principalTable: "Supplier",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
