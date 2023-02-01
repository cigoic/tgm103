using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WuliKaWu.Migrations
{
    public partial class ModifyMemberPhoneLength : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Members",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "MobilePhone",
                table: "Members",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Members",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "MobilePhone",
                table: "Members",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "ArticleId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 1, 30, 17, 35, 16, 222, DateTimeKind.Local).AddTicks(1893), new DateTime(2023, 1, 30, 17, 35, 16, 222, DateTimeKind.Local).AddTicks(1893) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "ArticleId",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 1, 30, 17, 35, 16, 222, DateTimeKind.Local).AddTicks(1989), new DateTime(2023, 1, 30, 17, 35, 16, 222, DateTimeKind.Local).AddTicks(1990) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "ArticleId",
                keyValue: 3,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 1, 30, 17, 35, 16, 222, DateTimeKind.Local).AddTicks(2028), new DateTime(2023, 1, 30, 17, 35, 16, 222, DateTimeKind.Local).AddTicks(2028) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "ArticleId",
                keyValue: 4,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 1, 30, 17, 35, 16, 222, DateTimeKind.Local).AddTicks(2068), new DateTime(2023, 1, 30, 17, 35, 16, 222, DateTimeKind.Local).AddTicks(2068) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "ArticleId",
                keyValue: 5,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 1, 30, 17, 35, 16, 222, DateTimeKind.Local).AddTicks(2103), new DateTime(2023, 1, 30, 17, 35, 16, 222, DateTimeKind.Local).AddTicks(2104) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "ArticleId",
                keyValue: 6,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 1, 30, 17, 35, 16, 222, DateTimeKind.Local).AddTicks(2143), new DateTime(2023, 1, 30, 17, 35, 16, 222, DateTimeKind.Local).AddTicks(2144) });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "MemberId",
                keyValue: 1,
                column: "Birthday",
                value: new DateTime(2023, 1, 30, 17, 35, 16, 222, DateTimeKind.Local).AddTicks(1809));

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "MemberId",
                keyValue: 2,
                column: "Birthday",
                value: new DateTime(2023, 1, 30, 17, 35, 16, 222, DateTimeKind.Local).AddTicks(1833));

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "MemberId",
                keyValue: 3,
                column: "Birthday",
                value: new DateTime(2023, 1, 30, 17, 35, 16, 222, DateTimeKind.Local).AddTicks(1843));
        }
    }
}
