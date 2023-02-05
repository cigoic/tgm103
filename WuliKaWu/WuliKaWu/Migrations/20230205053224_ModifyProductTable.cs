using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WuliKaWu.Migrations
{
    public partial class ModifyProductTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_WishLists_ProductId",
                table: "WishLists");

            migrationBuilder.DropIndex(
                name: "IX_Cart_ProductId",
                table: "Cart");

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "ArticleId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 2, 5, 13, 32, 23, 37, DateTimeKind.Local).AddTicks(8157), new DateTime(2023, 2, 5, 13, 32, 23, 37, DateTimeKind.Local).AddTicks(8157) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "ArticleId",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 2, 5, 13, 32, 23, 37, DateTimeKind.Local).AddTicks(8235), new DateTime(2023, 2, 5, 13, 32, 23, 37, DateTimeKind.Local).AddTicks(8236) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "ArticleId",
                keyValue: 3,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 2, 5, 13, 32, 23, 37, DateTimeKind.Local).AddTicks(8286), new DateTime(2023, 2, 5, 13, 32, 23, 37, DateTimeKind.Local).AddTicks(8287) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "ArticleId",
                keyValue: 4,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 2, 5, 13, 32, 23, 37, DateTimeKind.Local).AddTicks(8338), new DateTime(2023, 2, 5, 13, 32, 23, 37, DateTimeKind.Local).AddTicks(8338) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "ArticleId",
                keyValue: 5,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 2, 5, 13, 32, 23, 37, DateTimeKind.Local).AddTicks(8385), new DateTime(2023, 2, 5, 13, 32, 23, 37, DateTimeKind.Local).AddTicks(8386) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "ArticleId",
                keyValue: 6,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 2, 5, 13, 32, 23, 37, DateTimeKind.Local).AddTicks(8505), new DateTime(2023, 2, 5, 13, 32, 23, 37, DateTimeKind.Local).AddTicks(8507) });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "MemberId",
                keyValue: 1,
                column: "Birthday",
                value: new DateTime(2023, 2, 5, 13, 32, 23, 37, DateTimeKind.Local).AddTicks(7948));

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "MemberId",
                keyValue: 2,
                column: "Birthday",
                value: new DateTime(2023, 2, 5, 13, 32, 23, 37, DateTimeKind.Local).AddTicks(8025));

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "MemberId",
                keyValue: 3,
                column: "Birthday",
                value: new DateTime(2023, 2, 5, 13, 32, 23, 37, DateTimeKind.Local).AddTicks(8041));

            migrationBuilder.CreateIndex(
                name: "IX_WishLists_ProductId",
                table: "WishLists",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Cart_ProductId",
                table: "Cart",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_WishLists_ProductId",
                table: "WishLists");

            migrationBuilder.DropIndex(
                name: "IX_Cart_ProductId",
                table: "Cart");

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "ArticleId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 2, 5, 10, 45, 40, 205, DateTimeKind.Local).AddTicks(5462), new DateTime(2023, 2, 5, 10, 45, 40, 205, DateTimeKind.Local).AddTicks(5463) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "ArticleId",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 2, 5, 10, 45, 40, 205, DateTimeKind.Local).AddTicks(5611), new DateTime(2023, 2, 5, 10, 45, 40, 205, DateTimeKind.Local).AddTicks(5613) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "ArticleId",
                keyValue: 3,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 2, 5, 10, 45, 40, 205, DateTimeKind.Local).AddTicks(5666), new DateTime(2023, 2, 5, 10, 45, 40, 205, DateTimeKind.Local).AddTicks(5667) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "ArticleId",
                keyValue: 4,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 2, 5, 10, 45, 40, 205, DateTimeKind.Local).AddTicks(5730), new DateTime(2023, 2, 5, 10, 45, 40, 205, DateTimeKind.Local).AddTicks(5731) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "ArticleId",
                keyValue: 5,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 2, 5, 10, 45, 40, 205, DateTimeKind.Local).AddTicks(5792), new DateTime(2023, 2, 5, 10, 45, 40, 205, DateTimeKind.Local).AddTicks(5793) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "ArticleId",
                keyValue: 6,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 2, 5, 10, 45, 40, 205, DateTimeKind.Local).AddTicks(5849), new DateTime(2023, 2, 5, 10, 45, 40, 205, DateTimeKind.Local).AddTicks(5850) });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "MemberId",
                keyValue: 1,
                column: "Birthday",
                value: new DateTime(2023, 2, 5, 10, 45, 40, 205, DateTimeKind.Local).AddTicks(5317));

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "MemberId",
                keyValue: 2,
                column: "Birthday",
                value: new DateTime(2023, 2, 5, 10, 45, 40, 205, DateTimeKind.Local).AddTicks(5340));

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "MemberId",
                keyValue: 3,
                column: "Birthday",
                value: new DateTime(2023, 2, 5, 10, 45, 40, 205, DateTimeKind.Local).AddTicks(5352));

            migrationBuilder.CreateIndex(
                name: "IX_WishLists_ProductId",
                table: "WishLists",
                column: "ProductId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cart_ProductId",
                table: "Cart",
                column: "ProductId",
                unique: true);
        }
    }
}
