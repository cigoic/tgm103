using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WuliKaWu.Migrations
{
    public partial class change_wishlist_and_cart_one_to_many : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_WishLists_MemberId",
                table: "WishLists");

            migrationBuilder.DropIndex(
                name: "IX_Cart_MemberId",
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
                name: "IX_WishLists_MemberId",
                table: "WishLists",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Cart_MemberId",
                table: "Cart",
                column: "MemberId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_WishLists_MemberId",
                table: "WishLists");

            migrationBuilder.DropIndex(
                name: "IX_Cart_MemberId",
                table: "Cart");

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "ArticleId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 2, 4, 9, 13, 32, 295, DateTimeKind.Local).AddTicks(729), new DateTime(2023, 2, 4, 9, 13, 32, 295, DateTimeKind.Local).AddTicks(730) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "ArticleId",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 2, 4, 9, 13, 32, 295, DateTimeKind.Local).AddTicks(791), new DateTime(2023, 2, 4, 9, 13, 32, 295, DateTimeKind.Local).AddTicks(792) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "ArticleId",
                keyValue: 3,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 2, 4, 9, 13, 32, 295, DateTimeKind.Local).AddTicks(830), new DateTime(2023, 2, 4, 9, 13, 32, 295, DateTimeKind.Local).AddTicks(831) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "ArticleId",
                keyValue: 4,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 2, 4, 9, 13, 32, 295, DateTimeKind.Local).AddTicks(869), new DateTime(2023, 2, 4, 9, 13, 32, 295, DateTimeKind.Local).AddTicks(870) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "ArticleId",
                keyValue: 5,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 2, 4, 9, 13, 32, 295, DateTimeKind.Local).AddTicks(973), new DateTime(2023, 2, 4, 9, 13, 32, 295, DateTimeKind.Local).AddTicks(974) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "ArticleId",
                keyValue: 6,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 2, 4, 9, 13, 32, 295, DateTimeKind.Local).AddTicks(1015), new DateTime(2023, 2, 4, 9, 13, 32, 295, DateTimeKind.Local).AddTicks(1015) });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "MemberId",
                keyValue: 1,
                column: "Birthday",
                value: new DateTime(2023, 2, 4, 9, 13, 32, 295, DateTimeKind.Local).AddTicks(590));

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "MemberId",
                keyValue: 2,
                column: "Birthday",
                value: new DateTime(2023, 2, 4, 9, 13, 32, 295, DateTimeKind.Local).AddTicks(619));

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "MemberId",
                keyValue: 3,
                column: "Birthday",
                value: new DateTime(2023, 2, 4, 9, 13, 32, 295, DateTimeKind.Local).AddTicks(629));

            migrationBuilder.CreateIndex(
                name: "IX_WishLists_MemberId",
                table: "WishLists",
                column: "MemberId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cart_MemberId",
                table: "Cart",
                column: "MemberId",
                unique: true);
        }
    }
}
