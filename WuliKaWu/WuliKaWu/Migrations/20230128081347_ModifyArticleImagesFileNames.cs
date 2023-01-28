using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WuliKaWu.Migrations
{
    public partial class ModifyArticleImagesFileNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ArticleContentImages",
                keyColumn: "Id",
                keyValue: 1,
                column: "FileName",
                value: "assets/images/blog/blog-details-2.png");

            migrationBuilder.UpdateData(
                table: "ArticleContentImages",
                keyColumn: "Id",
                keyValue: 2,
                column: "FileName",
                value: "assets/images/blog/blog-details-3.png");

            migrationBuilder.UpdateData(
                table: "ArticleContentImages",
                keyColumn: "Id",
                keyValue: 3,
                column: "FileName",
                value: "assets/images/blog/blog-details-2.png");

            migrationBuilder.UpdateData(
                table: "ArticleContentImages",
                keyColumn: "Id",
                keyValue: 4,
                column: "FileName",
                value: "assets/images/blog/blog-details-3.png");

            migrationBuilder.UpdateData(
                table: "ArticleContentImages",
                keyColumn: "Id",
                keyValue: 5,
                column: "FileName",
                value: "assets/images/blog/blog-details-2.png");

            migrationBuilder.UpdateData(
                table: "ArticleContentImages",
                keyColumn: "Id",
                keyValue: 6,
                column: "FileName",
                value: "assets/images/blog/blog-details-3.png");

            migrationBuilder.UpdateData(
                table: "ArticleContentImages",
                keyColumn: "Id",
                keyValue: 7,
                column: "FileName",
                value: "assets/images/blog/blog-details-2.png");

            migrationBuilder.UpdateData(
                table: "ArticleContentImages",
                keyColumn: "Id",
                keyValue: 8,
                column: "FileName",
                value: "assets/images/blog/blog-details-3.png");

            migrationBuilder.UpdateData(
                table: "ArticleContentImages",
                keyColumn: "Id",
                keyValue: 9,
                column: "FileName",
                value: "assets/images/blog/blog-details-2.png");

            migrationBuilder.UpdateData(
                table: "ArticleContentImages",
                keyColumn: "Id",
                keyValue: 10,
                column: "FileName",
                value: "assets/images/blog/blog-details-3.png");

            migrationBuilder.UpdateData(
                table: "ArticleContentImages",
                keyColumn: "Id",
                keyValue: 11,
                column: "FileName",
                value: "assets/images/blog/blog-details-2.png");

            migrationBuilder.UpdateData(
                table: "ArticleContentImages",
                keyColumn: "Id",
                keyValue: 12,
                column: "FileName",
                value: "assets/images/blog/blog-details-3.png");

            migrationBuilder.UpdateData(
                table: "ArticleTitleImages",
                keyColumn: "Id",
                keyValue: 1,
                column: "FileName",
                value: "assets/images/blog/blog-details.png");

            migrationBuilder.UpdateData(
                table: "ArticleTitleImages",
                keyColumn: "Id",
                keyValue: 2,
                column: "FileName",
                value: "assets/images/blog/blog-details.png");

            migrationBuilder.UpdateData(
                table: "ArticleTitleImages",
                keyColumn: "Id",
                keyValue: 3,
                column: "FileName",
                value: "assets/images/blog/blog-details.png");

            migrationBuilder.UpdateData(
                table: "ArticleTitleImages",
                keyColumn: "Id",
                keyValue: 4,
                column: "FileName",
                value: "assets/images/blog/blog-details.png");

            migrationBuilder.UpdateData(
                table: "ArticleTitleImages",
                keyColumn: "Id",
                keyValue: 5,
                column: "FileName",
                value: "assets/images/blog/blog-details.png");

            migrationBuilder.UpdateData(
                table: "ArticleTitleImages",
                keyColumn: "Id",
                keyValue: 6,
                column: "FileName",
                value: "assets/images/blog/blog-details.png");

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
                table: "AuthorImages",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FirstImageFileName", "SecondImageFileName" },
                values: new object[] { "assets/images/blog/blog-author.png", "assets/images/blog/blog-author-2.png" });

            migrationBuilder.UpdateData(
                table: "AuthorImages",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FirstImageFileName", "SecondImageFileName" },
                values: new object[] { "assets/images/blog/blog-author.png", "assets/images/blog/blog-author-2.png" });

            migrationBuilder.UpdateData(
                table: "AuthorImages",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "FirstImageFileName", "SecondImageFileName" },
                values: new object[] { "assets/images/blog/blog-author.png", "assets/images/blog/blog-author-2.png" });

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ArticleContentImages",
                keyColumn: "Id",
                keyValue: 1,
                column: "FileName",
                value: "~/assets/images/blog/blog-details-2.png");

            migrationBuilder.UpdateData(
                table: "ArticleContentImages",
                keyColumn: "Id",
                keyValue: 2,
                column: "FileName",
                value: "~/assets/images/blog/blog-details-3.png");

            migrationBuilder.UpdateData(
                table: "ArticleContentImages",
                keyColumn: "Id",
                keyValue: 3,
                column: "FileName",
                value: "~/assets/images/blog/blog-details-2.png");

            migrationBuilder.UpdateData(
                table: "ArticleContentImages",
                keyColumn: "Id",
                keyValue: 4,
                column: "FileName",
                value: "~/assets/images/blog/blog-details-3.png");

            migrationBuilder.UpdateData(
                table: "ArticleContentImages",
                keyColumn: "Id",
                keyValue: 5,
                column: "FileName",
                value: "~/assets/images/blog/blog-details-2.png");

            migrationBuilder.UpdateData(
                table: "ArticleContentImages",
                keyColumn: "Id",
                keyValue: 6,
                column: "FileName",
                value: "~/assets/images/blog/blog-details-3.png");

            migrationBuilder.UpdateData(
                table: "ArticleContentImages",
                keyColumn: "Id",
                keyValue: 7,
                column: "FileName",
                value: "~/assets/images/blog/blog-details-2.png");

            migrationBuilder.UpdateData(
                table: "ArticleContentImages",
                keyColumn: "Id",
                keyValue: 8,
                column: "FileName",
                value: "~/assets/images/blog/blog-details-3.png");

            migrationBuilder.UpdateData(
                table: "ArticleContentImages",
                keyColumn: "Id",
                keyValue: 9,
                column: "FileName",
                value: "~/assets/images/blog/blog-details-2.png");

            migrationBuilder.UpdateData(
                table: "ArticleContentImages",
                keyColumn: "Id",
                keyValue: 10,
                column: "FileName",
                value: "~/assets/images/blog/blog-details-3.png");

            migrationBuilder.UpdateData(
                table: "ArticleContentImages",
                keyColumn: "Id",
                keyValue: 11,
                column: "FileName",
                value: "~/assets/images/blog/blog-details-2.png");

            migrationBuilder.UpdateData(
                table: "ArticleContentImages",
                keyColumn: "Id",
                keyValue: 12,
                column: "FileName",
                value: "~/assets/images/blog/blog-details-3.png");

            migrationBuilder.UpdateData(
                table: "ArticleTitleImages",
                keyColumn: "Id",
                keyValue: 1,
                column: "FileName",
                value: "~/assets/images/blog/blog-details.png");

            migrationBuilder.UpdateData(
                table: "ArticleTitleImages",
                keyColumn: "Id",
                keyValue: 2,
                column: "FileName",
                value: "~/assets/images/blog/blog-details.png");

            migrationBuilder.UpdateData(
                table: "ArticleTitleImages",
                keyColumn: "Id",
                keyValue: 3,
                column: "FileName",
                value: "~/assets/images/blog/blog-details.png");

            migrationBuilder.UpdateData(
                table: "ArticleTitleImages",
                keyColumn: "Id",
                keyValue: 4,
                column: "FileName",
                value: "~/assets/images/blog/blog-details.png");

            migrationBuilder.UpdateData(
                table: "ArticleTitleImages",
                keyColumn: "Id",
                keyValue: 5,
                column: "FileName",
                value: "~/assets/images/blog/blog-details.png");

            migrationBuilder.UpdateData(
                table: "ArticleTitleImages",
                keyColumn: "Id",
                keyValue: 6,
                column: "FileName",
                value: "~/assets/images/blog/blog-details.png");

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "ArticleId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 1, 28, 14, 3, 2, 663, DateTimeKind.Local).AddTicks(6270), new DateTime(2023, 1, 28, 14, 3, 2, 663, DateTimeKind.Local).AddTicks(6271) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "ArticleId",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 1, 28, 14, 3, 2, 663, DateTimeKind.Local).AddTicks(6324), new DateTime(2023, 1, 28, 14, 3, 2, 663, DateTimeKind.Local).AddTicks(6325) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "ArticleId",
                keyValue: 3,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 1, 28, 14, 3, 2, 663, DateTimeKind.Local).AddTicks(6367), new DateTime(2023, 1, 28, 14, 3, 2, 663, DateTimeKind.Local).AddTicks(6368) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "ArticleId",
                keyValue: 4,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 1, 28, 14, 3, 2, 663, DateTimeKind.Local).AddTicks(6413), new DateTime(2023, 1, 28, 14, 3, 2, 663, DateTimeKind.Local).AddTicks(6414) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "ArticleId",
                keyValue: 5,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 1, 28, 14, 3, 2, 663, DateTimeKind.Local).AddTicks(6538), new DateTime(2023, 1, 28, 14, 3, 2, 663, DateTimeKind.Local).AddTicks(6541) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "ArticleId",
                keyValue: 6,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 1, 28, 14, 3, 2, 663, DateTimeKind.Local).AddTicks(6623), new DateTime(2023, 1, 28, 14, 3, 2, 663, DateTimeKind.Local).AddTicks(6624) });

            migrationBuilder.UpdateData(
                table: "AuthorImages",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FirstImageFileName", "SecondImageFileName" },
                values: new object[] { "~/assets/images/blog/blog-author.png", "~/assets/images/blog/blog-author-2.png" });

            migrationBuilder.UpdateData(
                table: "AuthorImages",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FirstImageFileName", "SecondImageFileName" },
                values: new object[] { "~/assets/images/blog/blog-author.png", "~/assets/images/blog/blog-author-2.png" });

            migrationBuilder.UpdateData(
                table: "AuthorImages",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "FirstImageFileName", "SecondImageFileName" },
                values: new object[] { "~/assets/images/blog/blog-author.png", "~/assets/images/blog/blog-author-2.png" });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "MemberId",
                keyValue: 1,
                column: "Birthday",
                value: new DateTime(2023, 1, 28, 14, 3, 2, 663, DateTimeKind.Local).AddTicks(6173));

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "MemberId",
                keyValue: 2,
                column: "Birthday",
                value: new DateTime(2023, 1, 28, 14, 3, 2, 663, DateTimeKind.Local).AddTicks(6208));

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "MemberId",
                keyValue: 3,
                column: "Birthday",
                value: new DateTime(2023, 1, 28, 14, 3, 2, 663, DateTimeKind.Local).AddTicks(6219));
        }
    }
}
