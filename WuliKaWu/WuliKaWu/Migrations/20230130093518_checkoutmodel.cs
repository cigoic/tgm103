using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WuliKaWu.Migrations
{
    public partial class checkoutmodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "ArticleId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 1, 30, 17, 35, 16, 222, DateTimeKind.Local).AddTicks(1893), new DateTime(2023, 1, 30, 17, 35, 16, 222, DateTimeKind.Local).AddTicks(1893) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "ArticleId",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 1, 30, 17, 35, 16, 222, DateTimeKind.Local).AddTicks(1989), new DateTime(2023, 1, 30, 17, 35, 16, 222, DateTimeKind.Local).AddTicks(1990) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "ArticleId",
                keyValue: 3,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 1, 30, 17, 35, 16, 222, DateTimeKind.Local).AddTicks(2028), new DateTime(2023, 1, 30, 17, 35, 16, 222, DateTimeKind.Local).AddTicks(2028) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "ArticleId",
                keyValue: 4,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 1, 30, 17, 35, 16, 222, DateTimeKind.Local).AddTicks(2068), new DateTime(2023, 1, 30, 17, 35, 16, 222, DateTimeKind.Local).AddTicks(2068) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "ArticleId",
                keyValue: 5,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 1, 30, 17, 35, 16, 222, DateTimeKind.Local).AddTicks(2103), new DateTime(2023, 1, 30, 17, 35, 16, 222, DateTimeKind.Local).AddTicks(2104) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "ArticleId",
                keyValue: 6,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 1, 30, 17, 35, 16, 222, DateTimeKind.Local).AddTicks(2143), new DateTime(2023, 1, 30, 17, 35, 16, 222, DateTimeKind.Local).AddTicks(2144) });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "MemberId",
                keyValue: 1,
                column: "Birthday",
                value: new DateTime(2023, 1, 30, 17, 35, 16, 222, DateTimeKind.Local).AddTicks(1809));

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "MemberId",
                keyValue: 2,
                column: "Birthday",
                value: new DateTime(2023, 1, 30, 17, 35, 16, 222, DateTimeKind.Local).AddTicks(1833));

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "MemberId",
                keyValue: 3,
                column: "Birthday",
                value: new DateTime(2023, 1, 30, 17, 35, 16, 222, DateTimeKind.Local).AddTicks(1843));

            migrationBuilder.UpdateData(
                table: "WishList",
                keyColumn: "WishListId",
                keyValue: 1,
                columns: new[] { "MemberId", "ProductId" },
                values: new object[] { 2, 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
