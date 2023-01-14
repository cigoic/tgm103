using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WuliKaWu.Migrations
{
    public partial class UpdateOrderProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Image",
                table: "Products",
                newName: "Picture");

            migrationBuilder.RenameColumn(
                name: "UnitPrice",
                table: "Orders",
                newName: "Price");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Picture",
                table: "Products",
                newName: "Image");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Orders",
                newName: "UnitPrice");
        }
    }
}
