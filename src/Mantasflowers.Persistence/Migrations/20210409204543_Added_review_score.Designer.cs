﻿// <auto-generated />
using System;
using Mantasflowers.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Mantasflowers.Persistence.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20210409204543_Added_review_score")]
    partial class Added_review_score
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Mantasflowers.Domain.Entities.Coupon", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("BeginDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("DiscountPrice")
                        .HasColumnType("decimal(18,4)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<decimal>("OrderOverPrice")
                        .HasColumnType("decimal(18,4)");

                    b.Property<DateTime>("UpdatedOn")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Coupons");

                    b.HasData(
                        new
                        {
                            Id = new Guid("0e445786-f5a9-47a8-8f85-090fcce1478c"),
                            BeginDate = new DateTime(2021, 4, 9, 20, 45, 42, 734, DateTimeKind.Utc).AddTicks(9482),
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DiscountPrice = 10.0m,
                            EndDate = new DateTime(2021, 7, 8, 20, 45, 42, 734, DateTimeKind.Utc).AddTicks(9885),
                            Name = "PSK666",
                            OrderOverPrice = 15.0m,
                            UpdatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("Mantasflowers.Domain.Entities.Feedback", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(320)
                        .HasColumnType("nvarchar(320)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<DateTime>("UpdatedOn")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Feedback");

                    b.HasData(
                        new
                        {
                            Id = new Guid("b27498b3-8c3a-4169-bb56-cd581c0570cb"),
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "Lambs street 13",
                            Name = "Hannibal Lecter",
                            Text = "Tasty flowers",
                            UpdatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("Mantasflowers.Domain.Entities.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<decimal?>("DiscountPrice")
                        .HasColumnType("decimal(18,4)");

                    b.Property<string>("Message")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<Guid>("OrderAddressId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("OrderContactInfoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("OrderNumber")
                        .HasColumnType("decimal(20,0)");

                    b.Property<Guid?>("PaymentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ShipmentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("TemporaryPasswordHash")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<DateTime>("UpdatedOn")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("OrderAddressId");

                    b.HasIndex("OrderContactInfoId");

                    b.HasIndex("PaymentId");

                    b.HasIndex("ShipmentId");

                    b.ToTable("Orders");

                    b.HasData(
                        new
                        {
                            Id = new Guid("c8ab8521-6a1f-4f68-a3d2-ae6deec529fb"),
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Message = "i feel like a flower",
                            OrderAddressId = new Guid("d6885176-642f-476d-9e39-424a78f47bac"),
                            OrderContactInfoId = new Guid("178beff7-7de9-4580-9868-a3d98cdad2a2"),
                            OrderNumber = 123m,
                            PaymentId = new Guid("1a33844e-0bd6-4d29-9113-63d0e917b424"),
                            ShipmentId = new Guid("dc167821-ef16-4d1d-b0c8-159503196799"),
                            Status = "UNPAID",
                            TemporaryPasswordHash = "eyy123",
                            UpdatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("Mantasflowers.Domain.Entities.OrderAddress", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("UpdatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Zipcode")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("OrderAddresses");

                    b.HasData(
                        new
                        {
                            Id = new Guid("d6885176-642f-476d-9e39-424a78f47bac"),
                            City = "Vilnius",
                            Country = "LT",
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Street = "Autism street",
                            UpdatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Zipcode = "LT-12345"
                        });
                });

            modelBuilder.Entity("Mantasflowers.Domain.Entities.OrderContactInfo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasMaxLength(320)
                        .HasColumnType("nvarchar(320)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<DateTime>("UpdatedOn")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("OrderContactInfo");

                    b.HasData(
                        new
                        {
                            Id = new Guid("178beff7-7de9-4580-9868-a3d98cdad2a2"),
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "theforcebewithyou@coruscant.com",
                            Phone = "861234567",
                            UpdatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("Mantasflowers.Domain.Entities.OrderItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("OrderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("decimal(18,4)");

                    b.Property<DateTime>("UpdatedOn")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("OrderId", "ProductId")
                        .IsUnique();

                    b.ToTable("OrderItems");

                    b.HasData(
                        new
                        {
                            Id = new Guid("5640e66f-209a-4e04-8766-6dfdd6bdb7ba"),
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            OrderId = new Guid("c8ab8521-6a1f-4f68-a3d2-ae6deec529fb"),
                            ProductId = new Guid("58555e5f-079c-4f6e-a86f-dd6450e2245c"),
                            Quantity = 666,
                            UnitPrice = 1.59m,
                            UpdatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("Mantasflowers.Domain.Entities.Payment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("UpdatedOn")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Payments");

                    b.HasData(
                        new
                        {
                            Id = new Guid("1a33844e-0bd6-4d29-9113-63d0e917b424"),
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UpdatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("Mantasflowers.Domain.Entities.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<decimal?>("DiscountPercent")
                        .HasColumnType("decimal(18,4)");

                    b.Property<int>("LeftInStock")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,4)");

                    b.Property<Guid>("ProductInfoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ShortDescription")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ThumbnailPictureUrl")
                        .HasMaxLength(260)
                        .HasColumnType("nvarchar(260)");

                    b.Property<DateTime>("UpdatedOn")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ProductInfoId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = new Guid("58555e5f-079c-4f6e-a86f-dd6450e2245c"),
                            Category = "FLOWER",
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LeftInStock = 1000,
                            Name = "my rose",
                            Price = 1.99m,
                            ProductInfoId = new Guid("5f12b5e3-36ca-4ff5-a2e0-f8382eb964e1"),
                            ShortDescription = "veri priti flauver",
                            ThumbnailPictureUrl = "https://aodaisjdoasjdioas.com",
                            UpdatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("64acfe75-d9e9-40a4-aa0f-000d786088d3"),
                            Category = "FLOWER",
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DiscountPercent = 0.2m,
                            LeftInStock = 123,
                            Name = "konoha leaf",
                            Price = 2.99m,
                            ProductInfoId = new Guid("04807a6b-f6b2-43c3-881e-e2accd326091"),
                            ShortDescription = "its a real flower",
                            ThumbnailPictureUrl = "https://oiashdiasdias.com",
                            UpdatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("Mantasflowers.Domain.Entities.ProductInfo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("PictureUrl")
                        .HasMaxLength(260)
                        .HasColumnType("nvarchar(260)");

                    b.Property<DateTime>("UpdatedOn")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("ProductInfo");

                    b.HasData(
                        new
                        {
                            Id = new Guid("5f12b5e3-36ca-4ff5-a2e0-f8382eb964e1"),
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "yes, a veri pritti flauever. plis buy",
                            PictureUrl = "https://aodaisjdoasjdioas.com",
                            UpdatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("04807a6b-f6b2-43c3-881e-e2accd326091"),
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "best flower in the ninja village",
                            PictureUrl = "https://ioashfiausfa.com",
                            UpdatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("Mantasflowers.Domain.Entities.ProductReview", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("ReviewScore")
                        .HasColumnType("float");

                    b.Property<string>("ReviewText")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<DateTime>("UpdatedOn")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.HasIndex("ProductId", "UserId")
                        .IsUnique();

                    b.ToTable("ProductReviews");

                    b.HasData(
                        new
                        {
                            Id = new Guid("37dbd85a-a9bd-484f-b1b0-fde8b7a0aefc"),
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ProductId = new Guid("58555e5f-079c-4f6e-a86f-dd6450e2245c"),
                            ReviewScore = 0.0,
                            ReviewText = "im colorblind, ordered wrong flowers",
                            UpdatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserId = new Guid("fe63a2e6-5244-43c9-87af-8cc5759e62fc")
                        });
                });

            modelBuilder.Entity("Mantasflowers.Domain.Entities.Shipment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("UpdatedOn")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Shipments");

                    b.HasData(
                        new
                        {
                            Id = new Guid("dc167821-ef16-4d1d-b0c8-159503196799"),
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UpdatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("Mantasflowers.Domain.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AddressId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime>("UpdatedOn")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("UserContactInfoId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("UserContactInfoId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("fe63a2e6-5244-43c9-87af-8cc5759e62fc"),
                            AddressId = new Guid("4fdabf5e-e952-43e4-83b6-4d81eac4e7a6"),
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Obi-Wan",
                            LastName = "Kenobi",
                            UpdatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserContactInfoId = new Guid("94f7958c-cf03-40ed-b27d-766527fed2a9")
                        });
                });

            modelBuilder.Entity("Mantasflowers.Domain.Entities.UserAddress", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("UpdatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Zipcode")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("UserAddresses");

                    b.HasData(
                        new
                        {
                            Id = new Guid("4fdabf5e-e952-43e4-83b6-4d81eac4e7a6"),
                            City = "Vilnius",
                            Country = "LT",
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Street = "Autism street",
                            UpdatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Zipcode = "LT-12345"
                        });
                });

            modelBuilder.Entity("Mantasflowers.Domain.Entities.UserContactInfo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(320)
                        .HasColumnType("nvarchar(320)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<DateTime>("UpdatedOn")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("UserContactInfo");

                    b.HasData(
                        new
                        {
                            Id = new Guid("94f7958c-cf03-40ed-b27d-766527fed2a9"),
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "theforcebewithyou@coruscant.com",
                            Phone = "861234567",
                            UpdatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("Mantasflowers.Domain.Entities.UserOrder", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("OrderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("UpdatedOn")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.HasIndex("OrderId", "UserId")
                        .IsUnique();

                    b.ToTable("UserOrders");

                    b.HasData(
                        new
                        {
                            Id = new Guid("0e60e36f-6bb4-4ec0-872d-527068631f3f"),
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            OrderId = new Guid("c8ab8521-6a1f-4f68-a3d2-ae6deec529fb"),
                            UpdatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserId = new Guid("fe63a2e6-5244-43c9-87af-8cc5759e62fc")
                        });
                });

            modelBuilder.Entity("Mantasflowers.Domain.Entities.Order", b =>
                {
                    b.HasOne("Mantasflowers.Domain.Entities.OrderAddress", "OrderAddress")
                        .WithMany()
                        .HasForeignKey("OrderAddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Mantasflowers.Domain.Entities.OrderContactInfo", "OrderContactInfo")
                        .WithMany()
                        .HasForeignKey("OrderContactInfoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Mantasflowers.Domain.Entities.Payment", "Payment")
                        .WithMany()
                        .HasForeignKey("PaymentId");

                    b.HasOne("Mantasflowers.Domain.Entities.Shipment", "Shipment")
                        .WithMany()
                        .HasForeignKey("ShipmentId");

                    b.Navigation("OrderAddress");

                    b.Navigation("OrderContactInfo");

                    b.Navigation("Payment");

                    b.Navigation("Shipment");
                });

            modelBuilder.Entity("Mantasflowers.Domain.Entities.OrderItem", b =>
                {
                    b.HasOne("Mantasflowers.Domain.Entities.Order", "Order")
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Mantasflowers.Domain.Entities.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Mantasflowers.Domain.Entities.Product", b =>
                {
                    b.HasOne("Mantasflowers.Domain.Entities.ProductInfo", "ProductInfo")
                        .WithMany()
                        .HasForeignKey("ProductInfoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProductInfo");
                });

            modelBuilder.Entity("Mantasflowers.Domain.Entities.ProductReview", b =>
                {
                    b.HasOne("Mantasflowers.Domain.Entities.Product", "Product")
                        .WithMany("Reviews")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Mantasflowers.Domain.Entities.User", "User")
                        .WithMany("ProductReviews")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Mantasflowers.Domain.Entities.User", b =>
                {
                    b.HasOne("Mantasflowers.Domain.Entities.UserAddress", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId");

                    b.HasOne("Mantasflowers.Domain.Entities.UserContactInfo", "UserContactInfo")
                        .WithMany()
                        .HasForeignKey("UserContactInfoId");

                    b.Navigation("Address");

                    b.Navigation("UserContactInfo");
                });

            modelBuilder.Entity("Mantasflowers.Domain.Entities.UserOrder", b =>
                {
                    b.HasOne("Mantasflowers.Domain.Entities.Order", "Order")
                        .WithMany()
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Mantasflowers.Domain.Entities.User", "User")
                        .WithMany("UserOrders")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Mantasflowers.Domain.Entities.Order", b =>
                {
                    b.Navigation("OrderItems");
                });

            modelBuilder.Entity("Mantasflowers.Domain.Entities.Product", b =>
                {
                    b.Navigation("Reviews");
                });

            modelBuilder.Entity("Mantasflowers.Domain.Entities.User", b =>
                {
                    b.Navigation("ProductReviews");

                    b.Navigation("UserOrders");
                });
#pragma warning restore 612, 618
        }
    }
}