using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WuliKaWu.Migrations
{
    public partial class InitArticleTablesModifyOrderDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_OderDetails",
                table: "OderDetails");

            migrationBuilder.RenameTable(
                name: "OderDetails",
                newName: "OrderDetails");

            migrationBuilder.AlterColumn<int>(
                name: "MemberShip",
                table: "Members",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderDetails",
                table: "OrderDetails",
                column: "OrderDetailsId");

            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    ArticleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MemberId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.ArticleId);
                    table.ForeignKey(
                        name: "FK_Articles_Members_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Members",
                        principalColumn: "MemberId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AuthorImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MemberId = table.Column<int>(type: "int", nullable: false),
                    FirstImageFileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecondImageFileName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorImages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ArticleCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArticleId = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArticleCategories_Articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Articles",
                        principalColumn: "ArticleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ArticleContentImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArticleId = table.Column<int>(type: "int", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleContentImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArticleContentImages_Articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Articles",
                        principalColumn: "ArticleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ArticleTitleImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArticleId = table.Column<int>(type: "int", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleTitleImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArticleTitleImages_Articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Articles",
                        principalColumn: "ArticleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AuthorImages",
                columns: new[] { "Id", "FirstImageFileName", "MemberId", "SecondImageFileName" },
                values: new object[] { 1, "~/assets/images/blog/blog-author.png", 1, "~/assets/images/blog/blog-author-2.png" });

            migrationBuilder.InsertData(
                table: "Members",
                columns: new[] { "MemberId", "AccessFailedCount", "Account", "Address", "Birthday", "Email", "EmailComfirmed", "Gender", "LockOutEnabled", "MemberShip", "MobilePhone", "Name", "Password", "PhoneNumber" },
                values: new object[] { 1, 0, "userOne", "台北市中山區", new DateTime(2023, 1, 27, 22, 48, 14, 884, DateTimeKind.Local).AddTicks(791), "123@123.com", true, false, false, 1, "0987654321", "NameOfUserOne", "1314520", "1234567890" });

            migrationBuilder.UpdateData(
                table: "OrderDetails",
                keyColumn: "OrderDetailsId",
                keyValue: 1,
                columns: new[] { "Coupon", "Type" },
                values: new object[] { -100m, 1 });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "ArticleId", "Content", "CreatedDate", "MemberId", "ModifiedDate", "Title" },
                values: new object[] { 1, "Lorem ipsum dolor sit amet, consectetur adipi elit, sed do eiusmod tempor incididunt ut labo et dolore magna aliqua.", new DateTime(2023, 1, 27, 22, 48, 14, 884, DateTimeKind.Local).AddTicks(840), 1, new DateTime(2023, 1, 27, 22, 48, 14, 884, DateTimeKind.Local).AddTicks(841), "Lorem ipsum dolor consectet." });

            migrationBuilder.InsertData(
                table: "ArticleCategories",
                columns: new[] { "Id", "ArticleId", "Type" },
                values: new object[] { 1, 1, 2 });

            migrationBuilder.InsertData(
                table: "ArticleContentImages",
                columns: new[] { "Id", "ArticleId", "FileName" },
                values: new object[,]
                {
                    { 1, 1, "~/assets/images/blog/blog-details-2.png" },
                    { 2, 1, "~/assets/images/blog/blog-details-3.png" }
                });

            migrationBuilder.InsertData(
                table: "ArticleTitleImages",
                columns: new[] { "Id", "ArticleId", "FileName" },
                values: new object[] { 1, 1, "~/assets/images/blog/blog-details.png" });

            migrationBuilder.CreateIndex(
                name: "IX_ArticleCategories_ArticleId",
                table: "ArticleCategories",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_ArticleContentImages_ArticleId",
                table: "ArticleContentImages",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_MemberId",
                table: "Articles",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_ArticleTitleImages_ArticleId",
                table: "ArticleTitleImages",
                column: "ArticleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArticleCategories");

            migrationBuilder.DropTable(
                name: "ArticleContentImages");

            migrationBuilder.DropTable(
                name: "ArticleTitleImages");

            migrationBuilder.DropTable(
                name: "AuthorImages");

            migrationBuilder.DropTable(
                name: "Articles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderDetails",
                table: "OrderDetails");

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "MemberId",
                keyValue: 1);

            migrationBuilder.RenameTable(
                name: "OrderDetails",
                newName: "OderDetails");

            migrationBuilder.AlterColumn<string>(
                name: "MemberShip",
                table: "Members",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OderDetails",
                table: "OderDetails",
                column: "OrderDetailsId");

            migrationBuilder.UpdateData(
                table: "OderDetails",
                keyColumn: "OrderDetailsId",
                keyValue: 1,
                columns: new[] { "Coupon", "Type" },
                values: new object[] { null, 0 });
        }
    }
}
