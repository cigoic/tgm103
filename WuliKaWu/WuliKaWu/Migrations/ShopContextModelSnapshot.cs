﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WuliKaWu.Data;

#nullable disable

namespace WuliKaWu.Migrations
{
    [DbContext(typeof(ShopContext))]
    partial class ShopContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CartMember", b =>
                {
                    b.Property<int>("CartId")
                        .HasColumnType("int");

                    b.Property<int>("MemberId")
                        .HasColumnType("int");

                    b.HasKey("CartId", "MemberId");

                    b.HasIndex("MemberId");

                    b.ToTable("CartMember");
                });

            modelBuilder.Entity("CartProduct", b =>
                {
                    b.Property<int>("CartId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("CartId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("CartProduct");
                });

            modelBuilder.Entity("ColorProduct", b =>
                {
                    b.Property<int>("ColorsId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("ColorsId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("ColorProduct");
                });

            modelBuilder.Entity("ProductTag", b =>
                {
                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("TagsId")
                        .HasColumnType("int");

                    b.HasKey("ProductId", "TagsId");

                    b.HasIndex("TagsId");

                    b.ToTable("ProductTag");
                });

            modelBuilder.Entity("WuliKaWu.Data.Article", b =>
                {
                    b.Property<int>("ArticleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ArticleId"), 1L, 1);

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("MemberId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ArticleId");

                    b.HasIndex("MemberId");

                    b.ToTable("Articles");
                });

            modelBuilder.Entity("WuliKaWu.Data.ArticleCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ArticleId")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ArticleId");

                    b.ToTable("ArticleCategories");
                });

            modelBuilder.Entity("WuliKaWu.Data.ArticleContentImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ArticleId")
                        .HasColumnType("int");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("ArticleId");

                    b.ToTable("ArticleContentImages");
                });

            modelBuilder.Entity("WuliKaWu.Data.ArticleTitleImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ArticleId")
                        .HasColumnType("int");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("ArticleId");

                    b.ToTable("ArticleTitleImages");
                });

            modelBuilder.Entity("WuliKaWu.Data.AuthorImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("FirstImageFileName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<int>("MemberId")
                        .HasColumnType("int");

                    b.Property<string>("SecondImageFileName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.ToTable("AuthorImages");
                });

            modelBuilder.Entity("WuliKaWu.Data.Cart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("MemberId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Cart");
                });

            modelBuilder.Entity("WuliKaWu.Data.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"), 1L, 1);

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryId");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("WuliKaWu.Data.Color", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Color");
                });

            modelBuilder.Entity("WuliKaWu.Data.ContactMessage", b =>
                {
                    b.Property<int>("MessageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MessageId"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<int>("MemberId")
                        .HasColumnType("int");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(24)
                        .HasColumnType("nvarchar(24)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("nvarchar(16)");

                    b.Property<string>("Subject")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.HasKey("MessageId");

                    b.HasIndex("MemberId");

                    b.ToTable("ContactMessages");
                });

            modelBuilder.Entity("WuliKaWu.Data.Member", b =>
                {
                    b.Property<int>("MemberId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MemberId"), 1L, 1);

                    b.Property<string>("Account")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("nvarchar(16)");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailComfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("Gender")
                        .HasColumnType("bit");

                    b.Property<int>("MemberShip")
                        .HasColumnType("int");

                    b.Property<string>("MobilePhone")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(24)
                        .HasColumnType("nvarchar(24)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("VerificationToken")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MemberId");

                    b.ToTable("Members");
                });

            modelBuilder.Entity("WuliKaWu.Data.MemberRole", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoleId"), 1L, 1);

                    b.Property<int>("MemberId")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("RoleId");

<<<<<<< HEAD
                    b.HasIndex("MemberId");

                    b.ToTable("MemberRoles");
=======
                    b.ToTable("Cart");
                });

            modelBuilder.Entity("WuliKaWu.Models.ContactMessage", b =>
                {
                    b.Property<int>("MessageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MessageId"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("nchar(16)");

                    b.Property<string>("Subject")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MessageId");

                    b.ToTable("Contact Messages");
>>>>>>> 刪除migration (#2)
                });

            modelBuilder.Entity("WuliKaWu.Data.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderId"), 1L, 1);

                    b.Property<string>("ContactPhone")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<decimal?>("Coupon")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("MemberId")
                        .HasColumnType("int");

                    b.Property<string>("Memo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Recipient")
                        .IsRequired()
                        .HasMaxLength(24)
                        .HasColumnType("nvarchar(24)");

                    b.Property<string>("ShippingAddress")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("ShippingDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("OrderId");

                    b.HasIndex("MemberId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("WuliKaWu.Data.OrderDetails", b =>
                {
                    b.Property<int>("OrderDetailsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderDetailsId"), 1L, 1);

                    b.Property<int>("ColorId")
                        .HasColumnType("int");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<string>("PicturePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("Size")
                        .HasColumnType("int");

                    b.HasKey("OrderDetailsId");

                    b.HasIndex("ColorId");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("WuliKaWu.Data.Picture", b =>
                {
                    b.Property<int>("PictureId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PictureId"), 1L, 1);

                    b.Property<string>("PicturePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

<<<<<<< HEAD
                    b.HasKey("PictureId");

                    b.HasIndex("ProductId");

                    b.ToTable("Pictures");
=======
                    b.ToTable("Orders");
>>>>>>> 刪除migration (#2)
                });

            modelBuilder.Entity("WuliKaWu.Data.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"), 1L, 1);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

<<<<<<< HEAD
                    b.Property<decimal?>("SellingPrice")
                        .HasColumnType("decimal(18,2)");
=======
                    b.Property<int?>("SellingPrice")
                        .HasColumnType("int");
>>>>>>> 刪除migration (#2)

                    b.Property<int>("Size")
                        .HasColumnType("int");

<<<<<<< HEAD
                    b.HasKey("ProductId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("WuliKaWu.Data.ResetToken", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
=======
                    b.Property<int?>("StarRate")
>>>>>>> 刪除migration (#2)
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MemberId")
                        .HasColumnType("int");

                    b.Property<Guid>("Token")
                        .HasColumnType("uniqueidentifier");

<<<<<<< HEAD
                    b.Property<bool>("ValidateSatus")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("MemberId");

                    b.ToTable("ResetTokens");
=======
                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            Category = 3,
                            Color = 0,
                            Picture = new byte[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                            Price = 100,
                            ProductName = "大衣",
                            SellingPrice = 100,
                            Size = 1,
                            StarRate = 0
                        });
>>>>>>> 刪除migration (#2)
                });

            modelBuilder.Entity("WuliKaWu.Data.StarRate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("MemberId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MemberId");

                    b.HasIndex("ProductId");

                    b.ToTable("StarRate");
                });

            modelBuilder.Entity("WuliKaWu.Data.Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Tag");
                });

            modelBuilder.Entity("WuliKaWu.Data.WishList", b =>
                {
                    b.Property<int>("WishListId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("WishListId"), 1L, 1);

                    b.Property<int>("MemberId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("WishListId");

                    b.HasIndex("MemberId");

                    b.HasIndex("ProductId");

                    b.ToTable("WishLists");
                });

            modelBuilder.Entity("CartMember", b =>
                {
                    b.HasOne("WuliKaWu.Data.Cart", null)
                        .WithMany()
                        .HasForeignKey("CartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WuliKaWu.Data.Member", null)
                        .WithMany()
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CartProduct", b =>
                {
                    b.HasOne("WuliKaWu.Data.Cart", null)
                        .WithMany()
                        .HasForeignKey("CartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WuliKaWu.Data.Product", null)
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ColorProduct", b =>
                {
                    b.HasOne("WuliKaWu.Data.Color", null)
                        .WithMany()
                        .HasForeignKey("ColorsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WuliKaWu.Data.Product", null)
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProductTag", b =>
                {
                    b.HasOne("WuliKaWu.Data.Product", null)
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WuliKaWu.Data.Tag", null)
                        .WithMany()
                        .HasForeignKey("TagsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WuliKaWu.Data.Article", b =>
                {
                    b.HasOne("WuliKaWu.Data.Member", null)
                        .WithMany("Articles")
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WuliKaWu.Data.ArticleCategory", b =>
                {
                    b.HasOne("WuliKaWu.Data.Article", "Article")
                        .WithMany("ArticleCategories")
                        .HasForeignKey("ArticleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Article");
                });

            modelBuilder.Entity("WuliKaWu.Data.ArticleContentImage", b =>
                {
                    b.HasOne("WuliKaWu.Data.Article", null)
                        .WithMany("ArticleContentImages")
                        .HasForeignKey("ArticleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WuliKaWu.Data.ArticleTitleImage", b =>
                {
                    b.HasOne("WuliKaWu.Data.Article", null)
                        .WithMany("ArticleTitleImages")
                        .HasForeignKey("ArticleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WuliKaWu.Data.ContactMessage", b =>
                {
                    b.HasOne("WuliKaWu.Data.Member", "Member")
                        .WithMany("ContactMessages")
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Member");
                });

            modelBuilder.Entity("WuliKaWu.Data.MemberRole", b =>
                {
                    b.HasOne("WuliKaWu.Data.Member", "Member")
                        .WithMany("Roles")
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Member");
                });

            modelBuilder.Entity("WuliKaWu.Data.Order", b =>
                {
                    b.HasOne("WuliKaWu.Data.Member", "Member")
                        .WithMany("Orders")
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Member");
                });

            modelBuilder.Entity("WuliKaWu.Data.OrderDetails", b =>
                {
                    b.HasOne("WuliKaWu.Data.Color", "Color")
                        .WithMany()
                        .HasForeignKey("ColorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WuliKaWu.Data.Order", "Orders")
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Color");

                    b.Navigation("Orders");
                });

            modelBuilder.Entity("WuliKaWu.Data.Picture", b =>
                {
                    b.HasOne("WuliKaWu.Data.Product", "Product")
                        .WithMany("Pictures")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("WuliKaWu.Data.Product", b =>
                {
                    b.HasOne("WuliKaWu.Data.Category", "Category")
                        .WithMany("Product")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("WuliKaWu.Data.ResetToken", b =>
                {
                    b.HasOne("WuliKaWu.Data.Member", "Member")
                        .WithMany("ResetTokens")
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Member");
                });

            modelBuilder.Entity("WuliKaWu.Data.StarRate", b =>
                {
                    b.HasOne("WuliKaWu.Data.Member", "Member")
                        .WithMany()
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WuliKaWu.Data.Product", "Product")
                        .WithMany("StarRates")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Member");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("WuliKaWu.Data.WishList", b =>
                {
                    b.HasOne("WuliKaWu.Data.Member", "Member")
                        .WithMany("WishList")
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WuliKaWu.Data.Product", "Product")
                        .WithMany("WishList")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Member");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("WuliKaWu.Data.Article", b =>
                {
                    b.Navigation("ArticleCategories");

                    b.Navigation("ArticleContentImages");

                    b.Navigation("ArticleTitleImages");
                });

            modelBuilder.Entity("WuliKaWu.Data.Category", b =>
                {
                    b.Navigation("Product");
                });

            modelBuilder.Entity("WuliKaWu.Data.Member", b =>
                {
                    b.Navigation("Articles");

                    b.Navigation("ContactMessages");

                    b.Navigation("Orders");

                    b.Navigation("ResetTokens");

                    b.Navigation("Roles");

                    b.Navigation("WishList");
                });

            modelBuilder.Entity("WuliKaWu.Data.Order", b =>
                {
                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("WuliKaWu.Data.Product", b =>
                {
                    b.Navigation("Pictures");

                    b.Navigation("StarRates");

                    b.Navigation("WishList");
                });
#pragma warning restore 612, 618
        }
    }
}
