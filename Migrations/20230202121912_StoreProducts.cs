using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductStore.Migrations
{
    /// <inheritdoc />
    public partial class StoreProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_products_stores_storeId",
                table: "products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_stores",
                table: "stores");

            migrationBuilder.DropPrimaryKey(
                name: "PK_products",
                table: "products");

            migrationBuilder.DropIndex(
                name: "IX_products_storeId",
                table: "products");

            migrationBuilder.DropColumn(
                name: "storeId",
                table: "products");

            migrationBuilder.RenameTable(
                name: "stores",
                newName: "Stores");

            migrationBuilder.RenameTable(
                name: "products",
                newName: "Products");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Stores",
                table: "Stores",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "ProductStore",
                columns: table => new
                {
                    ProductsId = table.Column<int>(type: "int", nullable: false),
                    StoresId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductStore", x => new { x.ProductsId, x.StoresId });
                    table.ForeignKey(
                        name: "FK_ProductStore_Products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductStore_Stores_StoresId",
                        column: x => x.StoresId,
                        principalTable: "Stores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductStore_StoresId",
                table: "ProductStore",
                column: "StoresId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductStore");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Stores",
                table: "Stores");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.RenameTable(
                name: "Stores",
                newName: "stores");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "products");

            migrationBuilder.AddColumn<int>(
                name: "storeId",
                table: "products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_stores",
                table: "stores",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_products",
                table: "products",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_products_storeId",
                table: "products",
                column: "storeId");

            migrationBuilder.AddForeignKey(
                name: "FK_products_stores_storeId",
                table: "products",
                column: "storeId",
                principalTable: "stores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
