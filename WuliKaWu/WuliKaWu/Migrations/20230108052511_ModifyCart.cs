using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WuliKaWu.Migrations
{
    public partial class ModifyCart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CalculateShipping",
                table: "Cart");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Cart",
                type: "nvarchar(32)",
                maxLength: 32,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Conutry",
                table: "Cart",
                type: "nvarchar(32)",
                maxLength: 32,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<float>(
                name: "CouponDiscount",
                table: "Cart",
                type: "real",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Picture",
                table: "Cart",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<string>(
                name: "PostalCode",
                table: "Cart",
                type: "nvarchar(32)",
                maxLength: 32,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "Cart",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ProductName",
                table: "Cart",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "Cart",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "Cart",
                type: "nvarchar(32)",
                maxLength: 32,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "Cart");

            migrationBuilder.DropColumn(
                name: "Conutry",
                table: "Cart");

            migrationBuilder.DropColumn(
                name: "CouponDiscount",
                table: "Cart");

            migrationBuilder.DropColumn(
                name: "Picture",
                table: "Cart");

            migrationBuilder.DropColumn(
                name: "PostalCode",
                table: "Cart");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Cart");

            migrationBuilder.DropColumn(
                name: "ProductName",
                table: "Cart");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Cart");

            migrationBuilder.DropColumn(
                name: "State",
                table: "Cart");

            migrationBuilder.AddColumn<string>(
                name: "CalculateShipping",
                table: "Cart",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
