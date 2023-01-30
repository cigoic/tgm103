using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WuliKaWu.Migrations
{
    public partial class updatewishlistmodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "OrderDetails",
                keyColumn: "OrderDetailsId",
                keyValue: 1);

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "ArticleId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 1, 30, 13, 54, 51, 913, DateTimeKind.Local).AddTicks(7755), new DateTime(2023, 1, 30, 13, 54, 51, 913, DateTimeKind.Local).AddTicks(7755) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "ArticleId",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 1, 30, 13, 54, 51, 913, DateTimeKind.Local).AddTicks(7809), new DateTime(2023, 1, 30, 13, 54, 51, 913, DateTimeKind.Local).AddTicks(7809) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "ArticleId",
                keyValue: 3,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 1, 30, 13, 54, 51, 913, DateTimeKind.Local).AddTicks(7846), new DateTime(2023, 1, 30, 13, 54, 51, 913, DateTimeKind.Local).AddTicks(7846) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "ArticleId",
                keyValue: 4,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 1, 30, 13, 54, 51, 913, DateTimeKind.Local).AddTicks(7882), new DateTime(2023, 1, 30, 13, 54, 51, 913, DateTimeKind.Local).AddTicks(7882) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "ArticleId",
                keyValue: 5,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 1, 30, 13, 54, 51, 913, DateTimeKind.Local).AddTicks(7948), new DateTime(2023, 1, 30, 13, 54, 51, 913, DateTimeKind.Local).AddTicks(7948) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "ArticleId",
                keyValue: 6,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 1, 30, 13, 54, 51, 913, DateTimeKind.Local).AddTicks(7988), new DateTime(2023, 1, 30, 13, 54, 51, 913, DateTimeKind.Local).AddTicks(7988) });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "MemberId",
                keyValue: 1,
                column: "Birthday",
                value: new DateTime(2023, 1, 30, 13, 54, 51, 913, DateTimeKind.Local).AddTicks(7682));

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "MemberId",
                keyValue: 2,
                column: "Birthday",
                value: new DateTime(2023, 1, 30, 13, 54, 51, 913, DateTimeKind.Local).AddTicks(7702));

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "MemberId",
                keyValue: 3,
                column: "Birthday",
                value: new DateTime(2023, 1, 30, 13, 54, 51, 913, DateTimeKind.Local).AddTicks(7710));

            migrationBuilder.UpdateData(
                table: "WishList",
                keyColumn: "WishListId",
                keyValue: 1,
                columns: new[] { "MemberId", "ProductId" },
                values: new object[] { 1, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "ArticleId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 1, 28, 16, 13, 46, 79, DateTimeKind.Local).AddTicks(8073), new DateTime(2023, 1, 28, 16, 13, 46, 79, DateTimeKind.Local).AddTicks(8074) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "ArticleId",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 1, 28, 16, 13, 46, 79, DateTimeKind.Local).AddTicks(8169), new DateTime(2023, 1, 28, 16, 13, 46, 79, DateTimeKind.Local).AddTicks(8171) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "ArticleId",
                keyValue: 3,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 1, 28, 16, 13, 46, 79, DateTimeKind.Local).AddTicks(8305), new DateTime(2023, 1, 28, 16, 13, 46, 79, DateTimeKind.Local).AddTicks(8306) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "ArticleId",
                keyValue: 4,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 1, 28, 16, 13, 46, 79, DateTimeKind.Local).AddTicks(8363), new DateTime(2023, 1, 28, 16, 13, 46, 79, DateTimeKind.Local).AddTicks(8364) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "ArticleId",
                keyValue: 5,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 1, 28, 16, 13, 46, 79, DateTimeKind.Local).AddTicks(8412), new DateTime(2023, 1, 28, 16, 13, 46, 79, DateTimeKind.Local).AddTicks(8413) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "ArticleId",
                keyValue: 6,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 1, 28, 16, 13, 46, 79, DateTimeKind.Local).AddTicks(8462), new DateTime(2023, 1, 28, 16, 13, 46, 79, DateTimeKind.Local).AddTicks(8463) });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "MemberId",
                keyValue: 1,
                column: "Birthday",
                value: new DateTime(2023, 1, 28, 16, 13, 46, 79, DateTimeKind.Local).AddTicks(7919));

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "MemberId",
                keyValue: 2,
                column: "Birthday",
                value: new DateTime(2023, 1, 28, 16, 13, 46, 79, DateTimeKind.Local).AddTicks(7982));

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "MemberId",
                keyValue: 3,
                column: "Birthday",
                value: new DateTime(2023, 1, 28, 16, 13, 46, 79, DateTimeKind.Local).AddTicks(7995));

            migrationBuilder.InsertData(
                table: "OrderDetails",
                columns: new[] { "OrderDetailsId", "Color", "ContactPhone", "Coupon", "Discount", "OrderId", "PicturePath", "Price", "ProductId", "ProductName", "Quantity", "Recipient", "SellingPrice", "ShippingAddress", "Size", "Type" },
                values: new object[] { 1, 2, "0900123456", -100m, null, 0, "pic1", 3600m, 0, "外套", 2, "王大明", 2000m, "台北市中山區南京西路1號", 4, 1 });

            migrationBuilder.UpdateData(
                table: "WishList",
                keyColumn: "WishListId",
                keyValue: 1,
                columns: new[] { "MemberId", "ProductId" },
                values: new object[] { 0, 0 });
        }
    }
}
