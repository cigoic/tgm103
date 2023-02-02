using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WuliKaWu.Migrations
{
    public partial class InitTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AuthorImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MemberId = table.Column<int>(type: "int", nullable: false),
                    FirstImageFileName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    SecondImageFileName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorImages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Members",
                columns: table => new
                {
                    MemberId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Account = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(24)", maxLength: 24, nullable: false),
                    Gender = table.Column<bool>(type: "bit", nullable: false),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    EmailComfirmed = table.Column<bool>(type: "bit", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    MobilePhone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    MemberShip = table.Column<int>(type: "int", nullable: false),
                    LockOutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.MemberId);
                });

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
                name: "Cart",
                columns: table => new
                {
                    CartId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MemberId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cart", x => x.CartId);
                    table.ForeignKey(
                        name: "FK_Cart_Members_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Members",
                        principalColumn: "MemberId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Contact Messages",
                columns: table => new
                {
                    MessageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MemberId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(24)", maxLength: 24, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    Message = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contact Messages", x => x.MessageId);
                    table.ForeignKey(
                        name: "FK_Contact Messages_Members_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Members",
                        principalColumn: "MemberId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MemberRoles",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<int>(type: "int", nullable: false),
                    MemberId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberRoles", x => x.RoleId);
                    table.ForeignKey(
                        name: "FK_MemberRoles_Members_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Members",
                        principalColumn: "MemberId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Coupon = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Recipient = table.Column<string>(type: "nvarchar(24)", maxLength: 24, nullable: false),
                    ShippingAddress = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ContactPhone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ShippingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Memo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MemberId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Orders_Members_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Members",
                        principalColumn: "MemberId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WishLists",
                columns: table => new
                {
                    WishListId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MemberId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WishLists", x => x.WishListId);
                    table.ForeignKey(
                        name: "FK_WishLists_Members_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Members",
                        principalColumn: "MemberId",
                        onDelete: ReferentialAction.Cascade);
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
                    FileName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false)
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
                    FileName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false)
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

            migrationBuilder.CreateTable(
                name: "GetPayType",
                columns: table => new
                {
                    GetPayTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GetPayType", x => x.GetPayTypeId);
                    table.ForeignKey(
                        name: "FK_GetPayType_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    OrderDetailsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Color = table.Column<int>(type: "int", nullable: false),
                    Size = table.Column<int>(type: "int", nullable: false),
                    PicturePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.OrderDetailsId);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Color = table.Column<int>(type: "int", nullable: false),
                    Size = table.Column<int>(type: "int", nullable: false),
                    PicturePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SellingPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Discount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StarRate = table.Column<int>(type: "int", nullable: true),
                    Category = table.Column<int>(type: "int", nullable: false),
                    Tag = table.Column<int>(type: "int", nullable: true),
                    CartId = table.Column<int>(type: "int", nullable: true),
                    WishListId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Products_Cart_CartId",
                        column: x => x.CartId,
                        principalTable: "Cart",
                        principalColumn: "CartId");
                    table.ForeignKey(
                        name: "FK_Products_WishLists_WishListId",
                        column: x => x.WishListId,
                        principalTable: "WishLists",
                        principalColumn: "WishListId");
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.CategoryId);
                    table.ForeignKey(
                        name: "FK_Category_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Color",
                columns: table => new
                {
                    ColorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Color", x => x.ColorId);
                    table.ForeignKey(
                        name: "FK_Color_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pictures",
                columns: table => new
                {
                    PictureId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    PicturePath = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pictures", x => x.PictureId);
                    table.ForeignKey(
                        name: "FK_Pictures_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Size",
                columns: table => new
                {
                    SizeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Size", x => x.SizeId);
                    table.ForeignKey(
                        name: "FK_Size_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StarRate",
                columns: table => new
                {
                    StarRateId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StarRate", x => x.StarRateId);
                    table.ForeignKey(
                        name: "FK_StarRate_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tag",
                columns: table => new
                {
                    TagId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tag", x => x.TagId);
                    table.ForeignKey(
                        name: "FK_Tag_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AuthorImages",
                columns: new[] { "Id", "FirstImageFileName", "MemberId", "SecondImageFileName" },
                values: new object[,]
                {
                    { 1, "assets/images/blog/blog-author.png", 1, "assets/images/blog/blog-author-2.png" },
                    { 2, "assets/images/blog/blog-author.png", 2, "assets/images/blog/blog-author-2.png" },
                    { 3, "assets/images/blog/blog-author.png", 3, "assets/images/blog/blog-author-2.png" }
                });

            migrationBuilder.InsertData(
                table: "Members",
                columns: new[] { "MemberId", "AccessFailedCount", "Account", "Address", "Birthday", "Email", "EmailComfirmed", "Gender", "LockOutEnabled", "MemberShip", "MobilePhone", "Name", "Password", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, 0, "userOne", "台北市中山區", new DateTime(2023, 2, 2, 16, 18, 23, 712, DateTimeKind.Local).AddTicks(6251), "123@123.com", true, false, false, 1, "0987654321", "NameOfUserOne", "1314520", "1234567890" },
                    { 2, 0, "userTwo", "台中市中正區", new DateTime(2023, 2, 2, 16, 18, 23, 712, DateTimeKind.Local).AddTicks(6271), "456@456.com", true, false, false, 2, "0912345678", "NameOfVIP", "tgm10322", "0448938627" },
                    { 3, 0, "userThree", "屏東市仁愛路5號", new DateTime(2023, 2, 2, 16, 18, 23, 712, DateTimeKind.Local).AddTicks(6278), "123@123.com", true, false, false, 3, "0913579246", "NameOfAdmin", "tgm10333", "0876543210" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CartId", "Category", "Color", "Comment", "Discount", "PicturePath", "Price", "ProductName", "SellingPrice", "Size", "StarRate", "Tag", "WishListId" },
                values: new object[] { 1, null, 3, 0, null, null, "pic1", 100m, "大衣", 100m, 1, 0, null, null });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "ArticleId", "Content", "CreatedDate", "MemberId", "ModifiedDate", "Title" },
                values: new object[,]
                {
                    { 1, "Lorem ipsum dolor sit amet, consectetur adipi elit, sed do eiusmod tempor incididunt ut labo et dolore magna aliqua.", new DateTime(2023, 2, 2, 16, 18, 23, 712, DateTimeKind.Local).AddTicks(6330), 1, new DateTime(2023, 2, 2, 16, 18, 23, 712, DateTimeKind.Local).AddTicks(6331), "Lorem ipsum dolor consectet." },
                    { 2, "Lorem ipsum dolor sit amet, consectetur adipi elit, sed do eiusmod tempor incididunt ut labo et dolore magna aliqua.", new DateTime(2023, 2, 2, 16, 18, 23, 712, DateTimeKind.Local).AddTicks(6390), 2, new DateTime(2023, 2, 2, 16, 18, 23, 712, DateTimeKind.Local).AddTicks(6391), "Duis et volutpat pellentesque." },
                    { 3, "Lorem ipsum dolor sit amet, consectetur adipi elit, sed do eiusmod tempor incididunt ut labo et dolore magna aliqua.", new DateTime(2023, 2, 2, 16, 18, 23, 712, DateTimeKind.Local).AddTicks(6423), 3, new DateTime(2023, 2, 2, 16, 18, 23, 712, DateTimeKind.Local).AddTicks(6424), "Vivamus vitae dolor convallis." },
                    { 4, "Lorem ipsum dolor sit amet, consectetur adipi elit, sed do eiusmod tempor incididunt ut labo et dolore magna aliqua.", new DateTime(2023, 2, 2, 16, 18, 23, 712, DateTimeKind.Local).AddTicks(6457), 3, new DateTime(2023, 2, 2, 16, 18, 23, 712, DateTimeKind.Local).AddTicks(6458), "Vivamus amet tristique orci." },
                    { 5, "Lorem ipsum dolor sit amet, consectetur adipi elit, sed do eiusmod tempor incididunt ut labo et dolore magna aliqua.", new DateTime(2023, 2, 2, 16, 18, 23, 712, DateTimeKind.Local).AddTicks(6488), 2, new DateTime(2023, 2, 2, 16, 18, 23, 712, DateTimeKind.Local).AddTicks(6489), "Pellentesque pretium place." },
                    { 6, "Lorem ipsum dolor sit amet, consectetur adipi elit, sed do eiusmod tempor incididunt ut labo et dolore magna aliqua.", new DateTime(2023, 2, 2, 16, 18, 23, 712, DateTimeKind.Local).AddTicks(6545), 1, new DateTime(2023, 2, 2, 16, 18, 23, 712, DateTimeKind.Local).AddTicks(6546), "Sed euismod tristique dolor." }
                });

            migrationBuilder.InsertData(
                table: "ArticleCategories",
                columns: new[] { "Id", "ArticleId", "Type" },
                values: new object[,]
                {
                    { 1, 1, 2 },
                    { 2, 2, 2 },
                    { 3, 3, 2 },
                    { 4, 4, 2 },
                    { 5, 5, 2 },
                    { 6, 6, 2 }
                });

            migrationBuilder.InsertData(
                table: "ArticleContentImages",
                columns: new[] { "Id", "ArticleId", "FileName" },
                values: new object[,]
                {
                    { 1, 1, "assets/images/blog/blog-details-2.png" },
                    { 2, 1, "assets/images/blog/blog-details-3.png" },
                    { 3, 2, "assets/images/blog/blog-details-2.png" },
                    { 4, 2, "assets/images/blog/blog-details-3.png" },
                    { 5, 3, "assets/images/blog/blog-details-2.png" },
                    { 6, 3, "assets/images/blog/blog-details-3.png" },
                    { 7, 4, "assets/images/blog/blog-details-2.png" },
                    { 8, 4, "assets/images/blog/blog-details-3.png" },
                    { 9, 5, "assets/images/blog/blog-details-2.png" },
                    { 10, 5, "assets/images/blog/blog-details-3.png" },
                    { 11, 6, "assets/images/blog/blog-details-2.png" },
                    { 12, 6, "assets/images/blog/blog-details-3.png" }
                });

            migrationBuilder.InsertData(
                table: "ArticleTitleImages",
                columns: new[] { "Id", "ArticleId", "FileName" },
                values: new object[,]
                {
                    { 1, 1, "assets/images/blog/blog-details.png" },
                    { 2, 2, "assets/images/blog/blog-details.png" },
                    { 3, 3, "assets/images/blog/blog-details.png" },
                    { 4, 4, "assets/images/blog/blog-details.png" },
                    { 5, 5, "assets/images/blog/blog-details.png" },
                    { 6, 6, "assets/images/blog/blog-details.png" }
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Cart_MemberId",
                table: "Cart",
                column: "MemberId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Category_ProductId",
                table: "Category",
                column: "ProductId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Color_ProductId",
                table: "Color",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Contact Messages_MemberId",
                table: "Contact Messages",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_GetPayType_OrderId",
                table: "GetPayType",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_MemberRoles_MemberId",
                table: "MemberRoles",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderId",
                table: "OrderDetails",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_MemberId",
                table: "Orders",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Pictures_ProductId",
                table: "Pictures",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CartId",
                table: "Products",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_WishListId",
                table: "Products",
                column: "WishListId");

            migrationBuilder.CreateIndex(
                name: "IX_Size_ProductId",
                table: "Size",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_StarRate_ProductId",
                table: "StarRate",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Tag_ProductId",
                table: "Tag",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_WishLists_MemberId",
                table: "WishLists",
                column: "MemberId",
                unique: true);
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
                name: "Category");

            migrationBuilder.DropTable(
                name: "Color");

            migrationBuilder.DropTable(
                name: "Contact Messages");

            migrationBuilder.DropTable(
                name: "GetPayType");

            migrationBuilder.DropTable(
                name: "MemberRoles");

            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "Pictures");

            migrationBuilder.DropTable(
                name: "Size");

            migrationBuilder.DropTable(
                name: "StarRate");

            migrationBuilder.DropTable(
                name: "Tag");

            migrationBuilder.DropTable(
                name: "Articles");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Cart");

            migrationBuilder.DropTable(
                name: "WishLists");

            migrationBuilder.DropTable(
                name: "Members");
        }
    }
}
