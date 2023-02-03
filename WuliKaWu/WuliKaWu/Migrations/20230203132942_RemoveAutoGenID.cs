using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WuliKaWu.Migrations
{
    public partial class RemoveAutoGenID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "ArticleId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 2, 3, 21, 29, 42, 84, DateTimeKind.Local).AddTicks(4899), new DateTime(2023, 2, 3, 21, 29, 42, 84, DateTimeKind.Local).AddTicks(4899) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "ArticleId",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 2, 3, 21, 29, 42, 84, DateTimeKind.Local).AddTicks(4936), new DateTime(2023, 2, 3, 21, 29, 42, 84, DateTimeKind.Local).AddTicks(4936) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "ArticleId",
                keyValue: 3,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 2, 3, 21, 29, 42, 84, DateTimeKind.Local).AddTicks(4957), new DateTime(2023, 2, 3, 21, 29, 42, 84, DateTimeKind.Local).AddTicks(4958) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "ArticleId",
                keyValue: 4,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 2, 3, 21, 29, 42, 84, DateTimeKind.Local).AddTicks(4979), new DateTime(2023, 2, 3, 21, 29, 42, 84, DateTimeKind.Local).AddTicks(4980) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "ArticleId",
                keyValue: 5,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 2, 3, 21, 29, 42, 84, DateTimeKind.Local).AddTicks(4999), new DateTime(2023, 2, 3, 21, 29, 42, 84, DateTimeKind.Local).AddTicks(5000) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "ArticleId",
                keyValue: 6,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 2, 3, 21, 29, 42, 84, DateTimeKind.Local).AddTicks(5071), new DateTime(2023, 2, 3, 21, 29, 42, 84, DateTimeKind.Local).AddTicks(5072) });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "MemberId",
                keyValue: 1,
                column: "Birthday",
                value: new DateTime(2023, 2, 3, 21, 29, 42, 84, DateTimeKind.Local).AddTicks(4785));

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "MemberId",
                keyValue: 2,
                column: "Birthday",
                value: new DateTime(2023, 2, 3, 21, 29, 42, 84, DateTimeKind.Local).AddTicks(4832));

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "MemberId",
                keyValue: 3,
                column: "Birthday",
                value: new DateTime(2023, 2, 3, 21, 29, 42, 84, DateTimeKind.Local).AddTicks(4839));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
