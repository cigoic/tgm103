using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WuliKaWu.Migrations
{
    public partial class modifyWishlist_memmber : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WishLists_Members_MemberId",
                table: "WishLists");

            migrationBuilder.DropIndex(
                name: "IX_WishLists_MemberId",
                table: "WishLists");

            migrationBuilder.CreateTable(
                name: "MemberWishList",
                columns: table => new
                {
                    MemberId = table.Column<int>(type: "int", nullable: false),
                    WishListId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberWishList", x => new { x.MemberId, x.WishListId });
                    table.ForeignKey(
                        name: "FK_MemberWishList_Members_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Members",
                        principalColumn: "MemberId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MemberWishList_WishLists_WishListId",
                        column: x => x.WishListId,
                        principalTable: "WishLists",
                        principalColumn: "WishListId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MemberWishList_WishListId",
                table: "MemberWishList",
                column: "WishListId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MemberWishList");

            migrationBuilder.CreateIndex(
                name: "IX_WishLists_MemberId",
                table: "WishLists",
                column: "MemberId");

            migrationBuilder.AddForeignKey(
                name: "FK_WishLists_Members_MemberId",
                table: "WishLists",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "MemberId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
