using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WuliKaWu.Migrations
{
    public partial class UpdateCartFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Cart",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cart_Price",
                table: "Cart",
                column: "Price");

            migrationBuilder.CreateIndex(
                name: "IX_Cart_ProductId",
                table: "Cart",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cart_Orders_Price",
                table: "Cart",
                column: "Price",
                principalTable: "Orders",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cart_Products_ProductId",
                table: "Cart",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cart_Orders_Price",
                table: "Cart");

            migrationBuilder.DropForeignKey(
                name: "FK_Cart_Products_ProductId",
                table: "Cart");

            migrationBuilder.DropIndex(
                name: "IX_Cart_Price",
                table: "Cart");

            migrationBuilder.DropIndex(
                name: "IX_Cart_ProductId",
                table: "Cart");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Cart");
        }
    }
}
