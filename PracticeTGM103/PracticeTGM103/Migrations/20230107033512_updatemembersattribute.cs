using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PracticeTGM103.Migrations.Demo
{
    public partial class updatemembersattribute : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MemberPhone",
                table: "MembersDemo",
                newName: "Phone");

            migrationBuilder.RenameColumn(
                name: "MemberPassword",
                table: "MembersDemo",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "MemberName",
                table: "MembersDemo",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "MemberEmail",
                table: "MembersDemo",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "MemberBirth",
                table: "MembersDemo",
                newName: "Birth");

            migrationBuilder.RenameColumn(
                name: "MemberAdress",
                table: "MembersDemo",
                newName: "Adress");

            migrationBuilder.RenameColumn(
                name: "MemberAccount",
                table: "MembersDemo",
                newName: "Account");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "MembersDemo",
                newName: "MemberPhone");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "MembersDemo",
                newName: "MemberPassword");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "MembersDemo",
                newName: "MemberName");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "MembersDemo",
                newName: "MemberEmail");

            migrationBuilder.RenameColumn(
                name: "Birth",
                table: "MembersDemo",
                newName: "MemberBirth");

            migrationBuilder.RenameColumn(
                name: "Adress",
                table: "MembersDemo",
                newName: "MemberAdress");

            migrationBuilder.RenameColumn(
                name: "Account",
                table: "MembersDemo",
                newName: "MemberAccount");
        }
    }
}
