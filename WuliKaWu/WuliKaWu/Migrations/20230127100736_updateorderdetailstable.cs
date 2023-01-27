using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WuliKaWu.Migrations
{
    public partial class updateorderdetailstable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OderDetails_GetPayType_TableOfGetPayTypesGetPayTypeId",
                table: "OderDetails");

            migrationBuilder.DropIndex(
                name: "IX_OderDetails_TableOfGetPayTypesGetPayTypeId",
                table: "OderDetails");

            migrationBuilder.RenameColumn(
                name: "TableOfGetPayTypesGetPayTypeId",
                table: "OderDetails",
                newName: "Type");

            migrationBuilder.InsertData(
                table: "OderDetails",
                columns: new[] { "OrderDetailsId", "Color", "ContactPhone", "Coupon", "Discount", "OrderId", "PicturePath", "Price", "ProductId", "ProductName", "Quantity", "Recipient", "SellingPrice", "ShippingAddress", "Size", "Type" },
                values: new object[] { 1, 2, "0900123456", null, null, 0, "pic1", 3600m, 0, "外套", 2, "王大明", 2000m, "台北市中山區南京西路1號", 4, 0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "OderDetails",
                keyColumn: "OrderDetailsId",
                keyValue: 1);

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "OderDetails",
                newName: "TableOfGetPayTypesGetPayTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_OderDetails_TableOfGetPayTypesGetPayTypeId",
                table: "OderDetails",
                column: "TableOfGetPayTypesGetPayTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_OderDetails_GetPayType_TableOfGetPayTypesGetPayTypeId",
                table: "OderDetails",
                column: "TableOfGetPayTypesGetPayTypeId",
                principalTable: "GetPayType",
                principalColumn: "GetPayTypeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
