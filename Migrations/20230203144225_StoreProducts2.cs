using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductStore.Migrations
{
    /// <inheritdoc />
    public partial class StoreProducts2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductStore_Stores_StoresId",
                table: "ProductStore");

            migrationBuilder.DropForeignKey(
                name: "FK_shoppingCarts_Products_ProductId",
                table: "shoppingCarts");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Stores",
                newName: "StoreId");

            migrationBuilder.RenameColumn(
                name: "StoresId",
                table: "ProductStore",
                newName: "StoresStoreId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductStore_StoresId",
                table: "ProductStore",
                newName: "IX_ProductStore_StoresStoreId");

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "shoppingCarts",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductStore_Stores_StoresStoreId",
                table: "ProductStore",
                column: "StoresStoreId",
                principalTable: "Stores",
                principalColumn: "StoreId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_shoppingCarts_Products_ProductId",
                table: "shoppingCarts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductStore_Stores_StoresStoreId",
                table: "ProductStore");

            migrationBuilder.DropForeignKey(
                name: "FK_shoppingCarts_Products_ProductId",
                table: "shoppingCarts");

            migrationBuilder.RenameColumn(
                name: "StoreId",
                table: "Stores",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "StoresStoreId",
                table: "ProductStore",
                newName: "StoresId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductStore_StoresStoreId",
                table: "ProductStore",
                newName: "IX_ProductStore_StoresId");

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "shoppingCarts",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductStore_Stores_StoresId",
                table: "ProductStore",
                column: "StoresId",
                principalTable: "Stores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_shoppingCarts_Products_ProductId",
                table: "shoppingCarts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
