using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WuliKaWu.Migrations
{
    public partial class CreateCheckOutApiModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Picture",
                table: "WishList",
                newName: "PicturePath");

            migrationBuilder.RenameColumn(
                name: "Picture",
                table: "Products",
                newName: "PicturePath");

            migrationBuilder.RenameColumn(
                name: "Picture",
                table: "Cart",
                newName: "PicturePath");

            migrationBuilder.UpdateData(
                table: "Cart",
                keyColumn: "CartId",
                keyValue: 1,
                column: "Quantity",
                value: 2);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PicturePath",
                table: "WishList",
                newName: "Picture");

            migrationBuilder.RenameColumn(
                name: "PicturePath",
                table: "Products",
                newName: "Picture");

            migrationBuilder.RenameColumn(
                name: "PicturePath",
                table: "Cart",
                newName: "Picture");

            migrationBuilder.UpdateData(
                table: "Cart",
                keyColumn: "CartId",
                keyValue: 1,
                column: "Quantity",
                value: 1);
        }
    }
}
