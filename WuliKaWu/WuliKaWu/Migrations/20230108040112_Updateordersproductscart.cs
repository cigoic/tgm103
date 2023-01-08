using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WuliKaWu.Migrations
{
    public partial class Updateordersproductscart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Discount",
                table: "Orders",
                newName: "CouponDiscount");

            migrationBuilder.RenameColumn(
                name: "Amount",
                table: "Orders",
                newName: "Quantity");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "Orders",
                newName: "Amount");

            migrationBuilder.RenameColumn(
                name: "CouponDiscount",
                table: "Orders",
                newName: "Discount");
        }
    }
}
