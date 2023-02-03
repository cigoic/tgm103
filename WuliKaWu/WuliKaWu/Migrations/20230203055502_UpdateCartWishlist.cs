using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WuliKaWu.Migrations
{
    public partial class UpdateCartWishlist : Migration
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
                values: new object[] { new DateTime(2023, 2, 3, 13, 55, 1, 644, DateTimeKind.Local).AddTicks(5412), new DateTime(2023, 2, 3, 13, 55, 1, 644, DateTimeKind.Local).AddTicks(5413) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "ArticleId",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 2, 3, 13, 55, 1, 644, DateTimeKind.Local).AddTicks(5486), new DateTime(2023, 2, 3, 13, 55, 1, 644, DateTimeKind.Local).AddTicks(5487) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "ArticleId",
                keyValue: 3,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 2, 3, 13, 55, 1, 644, DateTimeKind.Local).AddTicks(5515), new DateTime(2023, 2, 3, 13, 55, 1, 644, DateTimeKind.Local).AddTicks(5516) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "ArticleId",
                keyValue: 4,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 2, 3, 13, 55, 1, 644, DateTimeKind.Local).AddTicks(5609), new DateTime(2023, 2, 3, 13, 55, 1, 644, DateTimeKind.Local).AddTicks(5610) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "ArticleId",
                keyValue: 5,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 2, 3, 13, 55, 1, 644, DateTimeKind.Local).AddTicks(5639), new DateTime(2023, 2, 3, 13, 55, 1, 644, DateTimeKind.Local).AddTicks(5640) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "ArticleId",
                keyValue: 6,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 2, 3, 13, 55, 1, 644, DateTimeKind.Local).AddTicks(5671), new DateTime(2023, 2, 3, 13, 55, 1, 644, DateTimeKind.Local).AddTicks(5672) });

            migrationBuilder.InsertData(
                table: "Cart",
                columns: new[] { "CartId", "MemberId", "ProductId", "Quantity" },
                values: new object[] { 3, 2, 6, 2 });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "MemberId",
                keyValue: 1,
                column: "Birthday",
                value: new DateTime(2023, 2, 3, 13, 55, 1, 644, DateTimeKind.Local).AddTicks(5284));

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "MemberId",
                keyValue: 2,
                column: "Birthday",
                value: new DateTime(2023, 2, 3, 13, 55, 1, 644, DateTimeKind.Local).AddTicks(5306));

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "MemberId",
                keyValue: 3,
                column: "Birthday",
                value: new DateTime(2023, 2, 3, 13, 55, 1, 644, DateTimeKind.Local).AddTicks(5313));

            migrationBuilder.InsertData(
                table: "WishLists",
                columns: new[] { "WishListId", "MemberId", "ProductId" },
                values: new object[] { 1, 2, 1 });

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

            migrationBuilder.DeleteData(
                table: "Cart",
                keyColumn: "CartId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "WishLists",
                keyColumn: "WishListId",
                keyValue: 1);

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
