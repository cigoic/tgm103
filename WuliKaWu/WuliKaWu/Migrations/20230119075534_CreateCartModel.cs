using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WuliKaWu.Migrations
{
    public partial class CreateCartModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Cart",
                columns: new[] { "CartId", "Color", "Coupon", "Discount", "Picture", "Price", "ProductName", "Quantity", "SellingPrice", "Size", "Total" },
                values: new object[] { 1, 3, -100m, null, "pic1", 1000m, "裙子", 0, 800m, 2, 0m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cart",
                keyColumn: "CartId",
                keyValue: 1);
        }
    }
}
