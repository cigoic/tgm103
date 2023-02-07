using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WuliKaWu.Migrations
{
    public partial class ModifyArticleRelatedTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArticleCategories_Articles_ArticleId",
                table: "ArticleCategories");

            migrationBuilder.DropIndex(
                name: "IX_ArticleCategories_ArticleId",
                table: "ArticleCategories");

            migrationBuilder.DropColumn(
                name: "FirstImageFileName",
                table: "AuthorImages");

            migrationBuilder.DropColumn(
                name: "SecondImageFileName",
                table: "AuthorImages");

            migrationBuilder.DropColumn(
                name: "FileName",
                table: "ArticleTitleImages");

            migrationBuilder.DropColumn(
                name: "FileName",
                table: "ArticleContentImages");

            migrationBuilder.DropColumn(
                name: "ArticleId",
                table: "ArticleCategories");

            migrationBuilder.RenameColumn(
                name: "ArticleId",
                table: "Articles",
                newName: "Id");

            migrationBuilder.AddColumn<int>(
                name: "ArticleId",
                table: "Tag",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PicturePatch",
                table: "AuthorImages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PicturePath",
                table: "ArticleTitleImages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Articles",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<string>(
                name: "PicturePath",
                table: "ArticleContentImages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "ArticleCategories",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "ArticleArticleCategory",
                columns: table => new
                {
                    ArticleCategoriesId = table.Column<int>(type: "int", nullable: false),
                    ArticlesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleArticleCategory", x => new { x.ArticleCategoriesId, x.ArticlesId });
                    table.ForeignKey(
                        name: "FK_ArticleArticleCategory_ArticleCategories_ArticleCategoriesId",
                        column: x => x.ArticleCategoriesId,
                        principalTable: "ArticleCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArticleArticleCategory_Articles_ArticlesId",
                        column: x => x.ArticlesId,
                        principalTable: "Articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tag_ArticleId",
                table: "Tag",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_AuthorImages_MemberId",
                table: "AuthorImages",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_ArticleArticleCategory_ArticlesId",
                table: "ArticleArticleCategory",
                column: "ArticlesId");

            migrationBuilder.AddForeignKey(
                name: "FK_AuthorImages_Members_MemberId",
                table: "AuthorImages",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "MemberId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tag_Articles_ArticleId",
                table: "Tag",
                column: "ArticleId",
                principalTable: "Articles",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuthorImages_Members_MemberId",
                table: "AuthorImages");

            migrationBuilder.DropForeignKey(
                name: "FK_Tag_Articles_ArticleId",
                table: "Tag");

            migrationBuilder.DropTable(
                name: "ArticleArticleCategory");

            migrationBuilder.DropIndex(
                name: "IX_Tag_ArticleId",
                table: "Tag");

            migrationBuilder.DropIndex(
                name: "IX_AuthorImages_MemberId",
                table: "AuthorImages");

            migrationBuilder.DropColumn(
                name: "ArticleId",
                table: "Tag");

            migrationBuilder.DropColumn(
                name: "PicturePatch",
                table: "AuthorImages");

            migrationBuilder.DropColumn(
                name: "PicturePath",
                table: "ArticleTitleImages");

            migrationBuilder.DropColumn(
                name: "PicturePath",
                table: "ArticleContentImages");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Articles",
                newName: "ArticleId");

            migrationBuilder.AddColumn<string>(
                name: "FirstImageFileName",
                table: "AuthorImages",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SecondImageFileName",
                table: "AuthorImages",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FileName",
                table: "ArticleTitleImages",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Articles",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AddColumn<string>(
                name: "FileName",
                table: "ArticleContentImages",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "Type",
                table: "ArticleCategories",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "ArticleId",
                table: "ArticleCategories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ArticleCategories_ArticleId",
                table: "ArticleCategories",
                column: "ArticleId");

            migrationBuilder.AddForeignKey(
                name: "FK_ArticleCategories_Articles_ArticleId",
                table: "ArticleCategories",
                column: "ArticleId",
                principalTable: "Articles",
                principalColumn: "ArticleId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
