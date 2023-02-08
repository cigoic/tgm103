using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WuliKaWu.Migrations
{
    public partial class ModifyArticleImagesTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ArticleTitleImages_ArticleId",
                table: "ArticleTitleImages");

            migrationBuilder.CreateIndex(
                name: "IX_ArticleTitleImages_ArticleId",
                table: "ArticleTitleImages",
                column: "ArticleId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ArticleTitleImages_ArticleId",
                table: "ArticleTitleImages");

            migrationBuilder.CreateIndex(
                name: "IX_ArticleTitleImages_ArticleId",
                table: "ArticleTitleImages",
                column: "ArticleId");
        }
    }
}
