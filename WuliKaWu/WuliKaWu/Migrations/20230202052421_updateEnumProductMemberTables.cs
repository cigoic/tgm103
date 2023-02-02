using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WuliKaWu.Migrations
{
    public partial class updateEnumProductMemberTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Pictures_ProductId",
                table: "Pictures");

            migrationBuilder.DropIndex(
                name: "IX_Category_ProductId",
                table: "Category");

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "ArticleId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 2, 2, 13, 24, 19, 573, DateTimeKind.Local).AddTicks(778), new DateTime(2023, 2, 2, 13, 24, 19, 573, DateTimeKind.Local).AddTicks(778) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "ArticleId",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 2, 2, 13, 24, 19, 573, DateTimeKind.Local).AddTicks(835), new DateTime(2023, 2, 2, 13, 24, 19, 573, DateTimeKind.Local).AddTicks(836) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "ArticleId",
                keyValue: 3,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 2, 2, 13, 24, 19, 573, DateTimeKind.Local).AddTicks(908), new DateTime(2023, 2, 2, 13, 24, 19, 573, DateTimeKind.Local).AddTicks(908) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "ArticleId",
                keyValue: 4,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 2, 2, 13, 24, 19, 573, DateTimeKind.Local).AddTicks(976), new DateTime(2023, 2, 2, 13, 24, 19, 573, DateTimeKind.Local).AddTicks(977) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "ArticleId",
                keyValue: 5,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 2, 2, 13, 24, 19, 573, DateTimeKind.Local).AddTicks(1011), new DateTime(2023, 2, 2, 13, 24, 19, 573, DateTimeKind.Local).AddTicks(1011) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "ArticleId",
                keyValue: 6,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 2, 2, 13, 24, 19, 573, DateTimeKind.Local).AddTicks(1049), new DateTime(2023, 2, 2, 13, 24, 19, 573, DateTimeKind.Local).AddTicks(1049) });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "MemberId",
                keyValue: 1,
                column: "Birthday",
                value: new DateTime(2023, 2, 2, 13, 24, 19, 573, DateTimeKind.Local).AddTicks(690));

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "MemberId",
                keyValue: 2,
                column: "Birthday",
                value: new DateTime(2023, 2, 2, 13, 24, 19, 573, DateTimeKind.Local).AddTicks(715));

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "MemberId",
                keyValue: 3,
                column: "Birthday",
                value: new DateTime(2023, 2, 2, 13, 24, 19, 573, DateTimeKind.Local).AddTicks(724));

            migrationBuilder.CreateIndex(
                name: "IX_Pictures_ProductId",
                table: "Pictures",
                column: "ProductId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Category_ProductId",
                table: "Category",
                column: "ProductId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Pictures_ProductId",
                table: "Pictures");

            migrationBuilder.DropIndex(
                name: "IX_Category_ProductId",
                table: "Category");

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "ArticleId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 2, 2, 0, 45, 37, 138, DateTimeKind.Local).AddTicks(6073), new DateTime(2023, 2, 2, 0, 45, 37, 138, DateTimeKind.Local).AddTicks(6074) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "ArticleId",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 2, 2, 0, 45, 37, 138, DateTimeKind.Local).AddTicks(6330), new DateTime(2023, 2, 2, 0, 45, 37, 138, DateTimeKind.Local).AddTicks(6331) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "ArticleId",
                keyValue: 3,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 2, 2, 0, 45, 37, 138, DateTimeKind.Local).AddTicks(6354), new DateTime(2023, 2, 2, 0, 45, 37, 138, DateTimeKind.Local).AddTicks(6354) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "ArticleId",
                keyValue: 4,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 2, 2, 0, 45, 37, 138, DateTimeKind.Local).AddTicks(6376), new DateTime(2023, 2, 2, 0, 45, 37, 138, DateTimeKind.Local).AddTicks(6376) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "ArticleId",
                keyValue: 5,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 2, 2, 0, 45, 37, 138, DateTimeKind.Local).AddTicks(6396), new DateTime(2023, 2, 2, 0, 45, 37, 138, DateTimeKind.Local).AddTicks(6397) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "ArticleId",
                keyValue: 6,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 2, 2, 0, 45, 37, 138, DateTimeKind.Local).AddTicks(6419), new DateTime(2023, 2, 2, 0, 45, 37, 138, DateTimeKind.Local).AddTicks(6420) });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "MemberId",
                keyValue: 1,
                column: "Birthday",
                value: new DateTime(2023, 2, 2, 0, 45, 37, 138, DateTimeKind.Local).AddTicks(6010));

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "MemberId",
                keyValue: 2,
                column: "Birthday",
                value: new DateTime(2023, 2, 2, 0, 45, 37, 138, DateTimeKind.Local).AddTicks(6027));

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "MemberId",
                keyValue: 3,
                column: "Birthday",
                value: new DateTime(2023, 2, 2, 0, 45, 37, 138, DateTimeKind.Local).AddTicks(6033));

            migrationBuilder.CreateIndex(
                name: "IX_Pictures_ProductId",
                table: "Pictures",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Category_ProductId",
                table: "Category",
                column: "ProductId");
        }
    }
}
