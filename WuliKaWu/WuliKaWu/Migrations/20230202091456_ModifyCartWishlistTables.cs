using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WuliKaWu.Migrations
{
    public partial class ModifyCartWishlistTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Cart_CartId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_WishLists_WishListId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_CartId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_WishListId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CartId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "WishListId",
                table: "Products");

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "ArticleId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 2, 2, 17, 14, 56, 45, DateTimeKind.Local).AddTicks(7601), new DateTime(2023, 2, 2, 17, 14, 56, 45, DateTimeKind.Local).AddTicks(7602) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "ArticleId",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 2, 2, 17, 14, 56, 45, DateTimeKind.Local).AddTicks(7657), new DateTime(2023, 2, 2, 17, 14, 56, 45, DateTimeKind.Local).AddTicks(7657) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "ArticleId",
                keyValue: 3,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 2, 2, 17, 14, 56, 45, DateTimeKind.Local).AddTicks(7725), new DateTime(2023, 2, 2, 17, 14, 56, 45, DateTimeKind.Local).AddTicks(7726) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "ArticleId",
                keyValue: 4,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 2, 2, 17, 14, 56, 45, DateTimeKind.Local).AddTicks(7766), new DateTime(2023, 2, 2, 17, 14, 56, 45, DateTimeKind.Local).AddTicks(7767) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "ArticleId",
                keyValue: 5,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 2, 2, 17, 14, 56, 45, DateTimeKind.Local).AddTicks(7802), new DateTime(2023, 2, 2, 17, 14, 56, 45, DateTimeKind.Local).AddTicks(7802) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "ArticleId",
                keyValue: 6,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 2, 2, 17, 14, 56, 45, DateTimeKind.Local).AddTicks(7840), new DateTime(2023, 2, 2, 17, 14, 56, 45, DateTimeKind.Local).AddTicks(7841) });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "MemberId",
                keyValue: 1,
                column: "Birthday",
                value: new DateTime(2023, 2, 2, 17, 14, 56, 45, DateTimeKind.Local).AddTicks(7517));

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "MemberId",
                keyValue: 2,
                column: "Birthday",
                value: new DateTime(2023, 2, 2, 17, 14, 56, 45, DateTimeKind.Local).AddTicks(7541));

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "MemberId",
                keyValue: 3,
                column: "Birthday",
                value: new DateTime(2023, 2, 2, 17, 14, 56, 45, DateTimeKind.Local).AddTicks(7551));

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

            migrationBuilder.AddForeignKey(
                name: "FK_Cart_Products_ProductId",
                table: "Cart",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WishLists_Products_ProductId",
                table: "WishLists",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cart_Products_ProductId",
                table: "Cart");

            migrationBuilder.DropForeignKey(
                name: "FK_WishLists_Products_ProductId",
                table: "WishLists");

            migrationBuilder.DropIndex(
                name: "IX_WishLists_ProductId",
                table: "WishLists");

            migrationBuilder.DropIndex(
                name: "IX_Cart_ProductId",
                table: "Cart");

            migrationBuilder.AddColumn<int>(
                name: "CartId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WishListId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "ArticleId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 2, 2, 16, 18, 23, 712, DateTimeKind.Local).AddTicks(6330), new DateTime(2023, 2, 2, 16, 18, 23, 712, DateTimeKind.Local).AddTicks(6331) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "ArticleId",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 2, 2, 16, 18, 23, 712, DateTimeKind.Local).AddTicks(6390), new DateTime(2023, 2, 2, 16, 18, 23, 712, DateTimeKind.Local).AddTicks(6391) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "ArticleId",
                keyValue: 3,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 2, 2, 16, 18, 23, 712, DateTimeKind.Local).AddTicks(6423), new DateTime(2023, 2, 2, 16, 18, 23, 712, DateTimeKind.Local).AddTicks(6424) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "ArticleId",
                keyValue: 4,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 2, 2, 16, 18, 23, 712, DateTimeKind.Local).AddTicks(6457), new DateTime(2023, 2, 2, 16, 18, 23, 712, DateTimeKind.Local).AddTicks(6458) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "ArticleId",
                keyValue: 5,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 2, 2, 16, 18, 23, 712, DateTimeKind.Local).AddTicks(6488), new DateTime(2023, 2, 2, 16, 18, 23, 712, DateTimeKind.Local).AddTicks(6489) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "ArticleId",
                keyValue: 6,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 2, 2, 16, 18, 23, 712, DateTimeKind.Local).AddTicks(6545), new DateTime(2023, 2, 2, 16, 18, 23, 712, DateTimeKind.Local).AddTicks(6546) });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "MemberId",
                keyValue: 1,
                column: "Birthday",
                value: new DateTime(2023, 2, 2, 16, 18, 23, 712, DateTimeKind.Local).AddTicks(6251));

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "MemberId",
                keyValue: 2,
                column: "Birthday",
                value: new DateTime(2023, 2, 2, 16, 18, 23, 712, DateTimeKind.Local).AddTicks(6271));

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "MemberId",
                keyValue: 3,
                column: "Birthday",
                value: new DateTime(2023, 2, 2, 16, 18, 23, 712, DateTimeKind.Local).AddTicks(6278));

            migrationBuilder.CreateIndex(
                name: "IX_Products_CartId",
                table: "Products",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_WishListId",
                table: "Products",
                column: "WishListId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Cart_CartId",
                table: "Products",
                column: "CartId",
                principalTable: "Cart",
                principalColumn: "CartId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_WishLists_WishListId",
                table: "Products",
                column: "WishListId",
                principalTable: "WishLists",
                principalColumn: "WishListId");
        }
    }
}
