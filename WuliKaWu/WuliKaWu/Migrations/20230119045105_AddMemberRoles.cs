using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WuliKaWu.Migrations
{
    public partial class AddMemberRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MemberRole_Members_MemberID",
                table: "MemberRole");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MemberRole",
                table: "MemberRole");

            migrationBuilder.RenameTable(
                name: "MemberRole",
                newName: "MemberRoles");

            migrationBuilder.RenameIndex(
                name: "IX_MemberRole_MemberID",
                table: "MemberRoles",
                newName: "IX_MemberRoles_MemberID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MemberRoles",
                table: "MemberRoles",
                column: "RoleID");

            migrationBuilder.AddForeignKey(
                name: "FK_MemberRoles_Members_MemberID",
                table: "MemberRoles",
                column: "MemberID",
                principalTable: "Members",
                principalColumn: "MemberID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MemberRoles_Members_MemberID",
                table: "MemberRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MemberRoles",
                table: "MemberRoles");

            migrationBuilder.RenameTable(
                name: "MemberRoles",
                newName: "MemberRole");

            migrationBuilder.RenameIndex(
                name: "IX_MemberRoles_MemberID",
                table: "MemberRole",
                newName: "IX_MemberRole_MemberID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MemberRole",
                table: "MemberRole",
                column: "RoleID");

            migrationBuilder.AddForeignKey(
                name: "FK_MemberRole_Members_MemberID",
                table: "MemberRole",
                column: "MemberID",
                principalTable: "Members",
                principalColumn: "MemberID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
