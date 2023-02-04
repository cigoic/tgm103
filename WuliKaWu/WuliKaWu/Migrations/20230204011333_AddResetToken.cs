using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WuliKaWu.Migrations
{
    public partial class AddResetToken : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ResetTokens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MemberId = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Token = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ValidateSatus = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResetTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResetTokens_Members_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Members",
                        principalColumn: "MemberId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "ArticleId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 2, 4, 9, 13, 32, 295, DateTimeKind.Local).AddTicks(729), new DateTime(2023, 2, 4, 9, 13, 32, 295, DateTimeKind.Local).AddTicks(730) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "ArticleId",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 2, 4, 9, 13, 32, 295, DateTimeKind.Local).AddTicks(791), new DateTime(2023, 2, 4, 9, 13, 32, 295, DateTimeKind.Local).AddTicks(792) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "ArticleId",
                keyValue: 3,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 2, 4, 9, 13, 32, 295, DateTimeKind.Local).AddTicks(830), new DateTime(2023, 2, 4, 9, 13, 32, 295, DateTimeKind.Local).AddTicks(831) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "ArticleId",
                keyValue: 4,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 2, 4, 9, 13, 32, 295, DateTimeKind.Local).AddTicks(869), new DateTime(2023, 2, 4, 9, 13, 32, 295, DateTimeKind.Local).AddTicks(870) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "ArticleId",
                keyValue: 5,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 2, 4, 9, 13, 32, 295, DateTimeKind.Local).AddTicks(973), new DateTime(2023, 2, 4, 9, 13, 32, 295, DateTimeKind.Local).AddTicks(974) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "ArticleId",
                keyValue: 6,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 2, 4, 9, 13, 32, 295, DateTimeKind.Local).AddTicks(1015), new DateTime(2023, 2, 4, 9, 13, 32, 295, DateTimeKind.Local).AddTicks(1015) });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "MemberId",
                keyValue: 1,
                column: "Birthday",
                value: new DateTime(2023, 2, 4, 9, 13, 32, 295, DateTimeKind.Local).AddTicks(590));

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "MemberId",
                keyValue: 2,
                column: "Birthday",
                value: new DateTime(2023, 2, 4, 9, 13, 32, 295, DateTimeKind.Local).AddTicks(619));

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "MemberId",
                keyValue: 3,
                column: "Birthday",
                value: new DateTime(2023, 2, 4, 9, 13, 32, 295, DateTimeKind.Local).AddTicks(629));

            migrationBuilder.CreateIndex(
                name: "IX_ResetTokens_MemberId",
                table: "ResetTokens",
                column: "MemberId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ResetTokens");

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
    }
}
