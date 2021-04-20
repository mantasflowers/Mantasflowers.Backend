using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Mantasflowers.Persistence.Migrations
{
    public partial class initial_migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Coupons",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    BeginDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DiscountPrice = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    OrderOverPrice = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coupons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Feedback",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(320)", maxLength: 320, nullable: false),
                    Text = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedback", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductInfo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    PictureUrl = table.Column<string>(type: "nvarchar(260)", maxLength: 260, nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Shipments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shipments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Uid = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Category = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ShortDescription = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    LeftInStock = table.Column<int>(type: "int", nullable: false),
                    DiscountPercent = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    ThumbnailPictureUrl = table.Column<string>(type: "nvarchar(260)", maxLength: 260, nullable: true),
                    ProductInfoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_ProductInfo_ProductInfoId",
                        column: x => x.ProductInfoId,
                        principalTable: "ProductInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ShipmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PaymentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TemporaryPasswordHash = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    OrderNumber = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    DiscountPrice = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    Message = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Payments_PaymentId",
                        column: x => x.PaymentId,
                        principalTable: "Payments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_Shipments_ShipmentId",
                        column: x => x.ShipmentId,
                        principalTable: "Shipments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserAddresses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    City = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Street = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Zipcode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAddresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserAddresses_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserContactInfo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(320)", maxLength: 320, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserContactInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserContactInfo_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductReviews",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReviewScore = table.Column<double>(type: "float", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductReviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductReviews_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductReviews_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderAddresses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    City = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Street = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Zipcode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderAddresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderAddresses_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderContactInfo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(320)", maxLength: 320, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderContactInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderContactInfo_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserOrders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserOrders_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserOrders_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Coupons",
                columns: new[] { "Id", "BeginDate", "CreatedOn", "DiscountPrice", "EndDate", "Name", "OrderOverPrice", "UpdatedOn" },
                values: new object[] { new Guid("2020634e-0566-4c9f-92a8-a064bbd3cb36"), new DateTime(2021, 4, 20, 12, 3, 44, 316, DateTimeKind.Utc).AddTicks(7007), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 10.0m, new DateTime(2021, 7, 19, 12, 3, 44, 316, DateTimeKind.Utc).AddTicks(7444), "PSK666", 15.0m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Feedback",
                columns: new[] { "Id", "CreatedOn", "Email", "Name", "Text", "UpdatedOn" },
                values: new object[] { new Guid("74b5728b-bd02-4dce-b5e7-43709fed134f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lambs street 13", "Hannibal Lecter", "Tasty flowers", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "Id", "CreatedOn", "UpdatedOn" },
                values: new object[] { new Guid("6453cd65-c3d6-4212-a900-d3a0b57d9daf"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "ProductInfo",
                columns: new[] { "Id", "CreatedOn", "Description", "PictureUrl", "UpdatedOn" },
                values: new object[,]
                {
                    { new Guid("46491fe1-7568-4a5b-864b-7212c554eba6"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "yes, a veri pritti flauever. plis buy", "https://res.cloudinary.com/mantasflowers/image/upload/w_1000,ar_1:1,c_fill,g_auto,e_art:hokusai/v1618667917/Flowers/flower6-pink-rose_pajjsc.jpg", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("5040173e-4bff-440d-a289-4d463d7950b9"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "best flower in the ninja village", "https://res.cloudinary.com/mantasflowers/image/upload/w_1000,ar_1:1,c_fill,g_auto,e_art:hokusai/v1618667917/Flowers/flower6-pink-rose_pajjsc.jpg", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("7127c401-8832-4487-8c95-dafa790f4507"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "description 3", "https://res.cloudinary.com/mantasflowers/image/upload/w_1000,ar_1:1,c_fill,g_auto,e_art:hokusai/v1618667917/Flowers/flower6-pink-rose_pajjsc.jpg", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("fd81e311-d46d-432b-a5b7-5cafaaf5ea2c"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "description 4", "https://res.cloudinary.com/mantasflowers/image/upload/w_1000,ar_1:1,c_fill,g_auto,e_art:hokusai/v1618667917/Flowers/flower6-pink-rose_pajjsc.jpg", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("8becb5f2-208b-49ee-ab11-0a9cc3a1d9b2"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "description 5", "https://res.cloudinary.com/mantasflowers/image/upload/w_1000,ar_1:1,c_fill,g_auto,e_art:hokusai/v1618667917/Flowers/flower6-pink-rose_pajjsc.jpg", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("77507466-6e64-463f-94a9-01c4f35db4ee"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "description 6", "https://res.cloudinary.com/mantasflowers/image/upload/w_1000,ar_1:1,c_fill,g_auto,e_art:hokusai/v1618667917/Flowers/flower6-pink-rose_pajjsc.jpg", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("ffd760d6-65f4-4b12-b625-b082ff9cb9df"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "description 7", "https://res.cloudinary.com/mantasflowers/image/upload/w_1000,ar_1:1,c_fill,g_auto,e_art:hokusai/v1618667917/Flowers/flower6-pink-rose_pajjsc.jpg", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("23e99280-7a54-4b6e-85d4-bc2016f009b5"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "description 8", "https://res.cloudinary.com/mantasflowers/image/upload/w_1000,ar_1:1,c_fill,g_auto,e_art:hokusai/v1618667917/Flowers/flower6-pink-rose_pajjsc.jpg", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("ad5ed53a-c727-45ec-b639-1307951a2ba0"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "description 9", "https://res.cloudinary.com/mantasflowers/image/upload/w_1000,ar_1:1,c_fill,g_auto,e_art:hokusai/v1618667917/Flowers/flower6-pink-rose_pajjsc.jpg", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f8289853-5cee-4827-92ca-1639250bb442"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "description 10", "https://res.cloudinary.com/mantasflowers/image/upload/w_1000,ar_1:1,c_fill,g_auto,e_art:hokusai/v1618667917/Flowers/flower6-pink-rose_pajjsc.jpg", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Shipments",
                columns: new[] { "Id", "CreatedOn", "UpdatedOn" },
                values: new object[] { new Guid("fb48fb7b-f7f0-4e3a-93d2-9cad436e5f9a"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedOn", "FirstName", "LastName", "Uid", "UpdatedOn" },
                values: new object[,]
                {
                    { new Guid("81936dbc-7aaa-4e17-9f50-8eaf48bb5184"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Obi-Wan", "Kenobi", "o2DfmuP9NRcw19bDbvSrg6lpavF2", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("40874d07-9f29-43c5-9b9f-7d6a64151923"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Luke", "Skywalker", "ikpWhF3UzsXFAue98r9pBA7RwGs1", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "CreatedOn", "DiscountPrice", "Message", "OrderNumber", "PaymentId", "ShipmentId", "Status", "TemporaryPasswordHash", "UpdatedOn" },
                values: new object[] { new Guid("a0432edd-536a-4e0d-9754-bae37f0c177c"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "i feel like a flower", 123m, new Guid("6453cd65-c3d6-4212-a900-d3a0b57d9daf"), new Guid("fb48fb7b-f7f0-4e3a-93d2-9cad436e5f9a"), "UNPAID", "eyy123", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Category", "CreatedOn", "DiscountPercent", "LeftInStock", "Name", "Price", "ProductInfoId", "ShortDescription", "ThumbnailPictureUrl", "UpdatedOn" },
                values: new object[,]
                {
                    { new Guid("71a4e7f6-333b-4dd1-997f-ce38efa3aee4"), "FLOWER", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1000, "my rose", 1.99m, new Guid("46491fe1-7568-4a5b-864b-7212c554eba6"), "veri priti flauver", "https://res.cloudinary.com/mantasflowers/image/upload/w_1000,ar_1:1,c_fill,g_auto,e_art:hokusai/v1618667917/Flowers/flower6-pink-rose_pajjsc.jpg", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("97c63343-f8d2-40bb-98b9-422c12fd2775"), "FLOWER", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0.2m, 123, "konoha leaf", 2.99m, new Guid("5040173e-4bff-440d-a289-4d463d7950b9"), "its a real flower", "https://res.cloudinary.com/mantasflowers/image/upload/w_1000,ar_1:1,c_fill,g_auto,e_art:hokusai/v1618667917/Flowers/flower6-pink-rose_pajjsc.jpg", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3e2b157f-8a5a-4540-b316-c5688cfeac25"), "BOUQUET", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0.0m, 4, "name 3", 5.99m, new Guid("7127c401-8832-4487-8c95-dafa790f4507"), "short description 3", "https://res.cloudinary.com/mantasflowers/image/upload/w_1000,ar_1:1,c_fill,g_auto,e_art:hokusai/v1618667917/Flowers/flower6-pink-rose_pajjsc.jpg", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("8acf97e4-6459-4960-a895-7b4f36fb0761"), "FLOWER", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0.15m, 400, "name 4", 2.49m, new Guid("fd81e311-d46d-432b-a5b7-5cafaaf5ea2c"), "short description 4", "https://res.cloudinary.com/mantasflowers/image/upload/w_1000,ar_1:1,c_fill,g_auto,e_art:hokusai/v1618667917/Flowers/flower6-pink-rose_pajjsc.jpg", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d28b9d32-f6a7-4389-83a9-b6fb531c0dee"), "BOUQUET", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0.0m, 15, "name 5", 11.29m, new Guid("8becb5f2-208b-49ee-ab11-0a9cc3a1d9b2"), "short description 5", "https://res.cloudinary.com/mantasflowers/image/upload/w_1000,ar_1:1,c_fill,g_auto,e_art:hokusai/v1618667917/Flowers/flower6-pink-rose_pajjsc.jpg", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("c20ddae5-64e2-45e8-8d77-e1dce5b6d106"), "BOUQUET", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0.40m, 153, "name 6", 1.29m, new Guid("77507466-6e64-463f-94a9-01c4f35db4ee"), "short description 6", "https://res.cloudinary.com/mantasflowers/image/upload/w_1000,ar_1:1,c_fill,g_auto,e_art:hokusai/v1618667917/Flowers/flower6-pink-rose_pajjsc.jpg", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("4c5d09e2-c971-4560-90b6-3f92ca12c901"), "FLOWER", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0.10m, 4321, "name 7", 0.59m, new Guid("ffd760d6-65f4-4b12-b625-b082ff9cb9df"), "short description 7", "https://res.cloudinary.com/mantasflowers/image/upload/w_1000,ar_1:1,c_fill,g_auto,e_art:hokusai/v1618667917/Flowers/flower6-pink-rose_pajjsc.jpg", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("51f784fc-1efd-4dfd-a616-0e10e737104c"), "BOUQUET", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0.3m, 125, "name 8", 7.19m, new Guid("23e99280-7a54-4b6e-85d4-bc2016f009b5"), "short description 8", "https://res.cloudinary.com/mantasflowers/image/upload/w_1000,ar_1:1,c_fill,g_auto,e_art:hokusai/v1618667917/Flowers/flower6-pink-rose_pajjsc.jpg", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("c60edbc8-09e4-4af4-90de-b0d720f2604a"), "FLOWER", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0.0m, 1233, "name 9", 2.49m, new Guid("ad5ed53a-c727-45ec-b639-1307951a2ba0"), "short description 9", "https://res.cloudinary.com/mantasflowers/image/upload/w_1000,ar_1:1,c_fill,g_auto,e_art:hokusai/v1618667917/Flowers/flower6-pink-rose_pajjsc.jpg", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("049ca675-987f-40ff-ab69-35a0bc1d5512"), "BOUQUET", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0.0m, 34, "name 10", 7.99m, new Guid("f8289853-5cee-4827-92ca-1639250bb442"), "short description 10", "https://res.cloudinary.com/mantasflowers/image/upload/w_1000,ar_1:1,c_fill,g_auto,e_art:hokusai/v1618667917/Flowers/flower6-pink-rose_pajjsc.jpg", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "UserAddresses",
                columns: new[] { "Id", "City", "Country", "CreatedOn", "Street", "UpdatedOn", "UserId", "Zipcode" },
                values: new object[,]
                {
                    { new Guid("148b8273-8948-46ef-ae8c-5a6b0f997d5c"), "Vilnius", "LT", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Autism street", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("81936dbc-7aaa-4e17-9f50-8eaf48bb5184"), "LT-12345" },
                    { new Guid("fa0ae34f-fee3-4793-bf27-8caa69c1a96d"), "Kaunas", "LT", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kaimas street", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("40874d07-9f29-43c5-9b9f-7d6a64151923"), "LT-54321" }
                });

            migrationBuilder.InsertData(
                table: "UserContactInfo",
                columns: new[] { "Id", "CreatedOn", "Email", "Phone", "UpdatedOn", "UserId" },
                values: new object[,]
                {
                    { new Guid("8c5e161f-3363-4d10-8ec7-1bd432549601"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "theforcebewithyou@coruscant.com", "+37061234567", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("81936dbc-7aaa-4e17-9f50-8eaf48bb5184") },
                    { new Guid("04e9c438-4ab2-477d-b7e6-88150018e8e2"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "asdiasdioas@asfiasifa.com", "+37069263957", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("40874d07-9f29-43c5-9b9f-7d6a64151923") }
                });

            migrationBuilder.InsertData(
                table: "OrderAddresses",
                columns: new[] { "Id", "City", "Country", "CreatedOn", "OrderId", "Street", "UpdatedOn", "Zipcode" },
                values: new object[] { new Guid("8154b14b-205b-4aa8-9b71-56e6173bf9d7"), "Vilnius", "LT", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("a0432edd-536a-4e0d-9754-bae37f0c177c"), "Autism street", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "LT-12345" });

            migrationBuilder.InsertData(
                table: "OrderContactInfo",
                columns: new[] { "Id", "CreatedOn", "Email", "OrderId", "Phone", "UpdatedOn" },
                values: new object[] { new Guid("2321f86f-af60-4a30-97f4-83fd0de197e1"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "theforcebewithyou@coruscant.com", new Guid("a0432edd-536a-4e0d-9754-bae37f0c177c"), "861234567", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "OrderItems",
                columns: new[] { "Id", "CreatedOn", "OrderId", "ProductId", "Quantity", "UnitPrice", "UpdatedOn" },
                values: new object[] { new Guid("82ca2a36-d2f9-4fbe-89e6-945eb1b5bdf6"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("a0432edd-536a-4e0d-9754-bae37f0c177c"), new Guid("71a4e7f6-333b-4dd1-997f-ce38efa3aee4"), 666, 1.59m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "ProductReviews",
                columns: new[] { "Id", "CreatedOn", "ProductId", "ReviewScore", "UpdatedOn", "UserId" },
                values: new object[,]
                {
                    { new Guid("e1b429c5-ba7b-4a76-aace-1811ed289fc7"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("71a4e7f6-333b-4dd1-997f-ce38efa3aee4"), 3.5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("81936dbc-7aaa-4e17-9f50-8eaf48bb5184") },
                    { new Guid("ed4f41d0-6c61-44f0-a8de-d88f0344f745"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("97c63343-f8d2-40bb-98b9-422c12fd2775"), 10.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("81936dbc-7aaa-4e17-9f50-8eaf48bb5184") }
                });

            migrationBuilder.InsertData(
                table: "UserOrders",
                columns: new[] { "Id", "CreatedOn", "OrderId", "UpdatedOn", "UserId" },
                values: new object[] { new Guid("59bd1350-9ebc-4a13-8090-8190945eee55"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("a0432edd-536a-4e0d-9754-bae37f0c177c"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("81936dbc-7aaa-4e17-9f50-8eaf48bb5184") });

            migrationBuilder.CreateIndex(
                name: "IX_OrderAddresses_OrderId",
                table: "OrderAddresses",
                column: "OrderId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderContactInfo_OrderId",
                table: "OrderContactInfo",
                column: "OrderId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId_ProductId",
                table: "OrderItems",
                columns: new[] { "OrderId", "ProductId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_ProductId",
                table: "OrderItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_PaymentId",
                table: "Orders",
                column: "PaymentId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ShipmentId",
                table: "Orders",
                column: "ShipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductReviews_ProductId_UserId",
                table: "ProductReviews",
                columns: new[] { "ProductId", "UserId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductReviews_UserId",
                table: "ProductReviews",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductInfoId",
                table: "Products",
                column: "ProductInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAddresses_UserId",
                table: "UserAddresses",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserContactInfo_UserId",
                table: "UserContactInfo",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserOrders_OrderId_UserId",
                table: "UserOrders",
                columns: new[] { "OrderId", "UserId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserOrders_UserId",
                table: "UserOrders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Uid",
                table: "Users",
                column: "Uid",
                unique: true,
                filter: "[Uid] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Coupons");

            migrationBuilder.DropTable(
                name: "Feedback");

            migrationBuilder.DropTable(
                name: "OrderAddresses");

            migrationBuilder.DropTable(
                name: "OrderContactInfo");

            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "ProductReviews");

            migrationBuilder.DropTable(
                name: "UserAddresses");

            migrationBuilder.DropTable(
                name: "UserContactInfo");

            migrationBuilder.DropTable(
                name: "UserOrders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "ProductInfo");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "Shipments");
        }
    }
}
