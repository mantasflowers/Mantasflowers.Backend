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
                name: "OrderAddresses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                });

            migrationBuilder.CreateTable(
                name: "OrderContactInfo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(320)", maxLength: 320, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderContactInfo", x => x.Id);
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
                    OrderAddressId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderContactInfoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                        name: "FK_Orders_OrderAddresses_OrderAddressId",
                        column: x => x.OrderAddressId,
                        principalTable: "OrderAddresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_OrderContactInfo_OrderContactInfoId",
                        column: x => x.OrderContactInfoId,
                        principalTable: "OrderContactInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                values: new object[] { new Guid("b14b8f48-c45e-4a93-874e-dd33166ffec5"), new DateTime(2021, 4, 19, 23, 16, 0, 279, DateTimeKind.Utc).AddTicks(3303), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 10.0m, new DateTime(2021, 7, 18, 23, 16, 0, 279, DateTimeKind.Utc).AddTicks(3698), "PSK666", 15.0m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Feedback",
                columns: new[] { "Id", "CreatedOn", "Email", "Name", "Text", "UpdatedOn" },
                values: new object[] { new Guid("6035a8f0-8b2f-44b9-bb1f-228842cc555f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lambs street 13", "Hannibal Lecter", "Tasty flowers", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "OrderAddresses",
                columns: new[] { "Id", "City", "Country", "CreatedOn", "Street", "UpdatedOn", "Zipcode" },
                values: new object[] { new Guid("1daeb234-2080-4d67-a4c0-72c294498fa1"), "Vilnius", "LT", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Autism street", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "LT-12345" });

            migrationBuilder.InsertData(
                table: "OrderContactInfo",
                columns: new[] { "Id", "CreatedOn", "Email", "Phone", "UpdatedOn" },
                values: new object[] { new Guid("6c7b122f-d6af-4e21-a559-15b32738b95b"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "theforcebewithyou@coruscant.com", "861234567", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "Id", "CreatedOn", "UpdatedOn" },
                values: new object[] { new Guid("84a93913-d097-49c8-8d15-c1a04172aec8"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "ProductInfo",
                columns: new[] { "Id", "CreatedOn", "Description", "PictureUrl", "UpdatedOn" },
                values: new object[,]
                {
                    { new Guid("08cb2f7d-e5fe-4615-a3e5-8576af69ac83"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "description 10", "https://res.cloudinary.com/mantasflowers/image/upload/w_1000,ar_1:1,c_fill,g_auto,e_art:hokusai/v1618667917/Flowers/flower6-pink-rose_pajjsc.jpg", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("908bc516-4fe5-45b6-8688-364ea39b4d46"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "description 9", "https://res.cloudinary.com/mantasflowers/image/upload/w_1000,ar_1:1,c_fill,g_auto,e_art:hokusai/v1618667917/Flowers/flower6-pink-rose_pajjsc.jpg", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("5edf7b60-20e1-4ba2-9a56-56754ffc9dbd"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "description 8", "https://res.cloudinary.com/mantasflowers/image/upload/w_1000,ar_1:1,c_fill,g_auto,e_art:hokusai/v1618667917/Flowers/flower6-pink-rose_pajjsc.jpg", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b57795b1-4521-4aa6-817c-22c9e82b3ea7"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "description 7", "https://res.cloudinary.com/mantasflowers/image/upload/w_1000,ar_1:1,c_fill,g_auto,e_art:hokusai/v1618667917/Flowers/flower6-pink-rose_pajjsc.jpg", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("80d2511b-77c5-47b9-a055-ace42ff14079"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "description 6", "https://res.cloudinary.com/mantasflowers/image/upload/w_1000,ar_1:1,c_fill,g_auto,e_art:hokusai/v1618667917/Flowers/flower6-pink-rose_pajjsc.jpg", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("6e723707-a565-436b-b24e-d38314f31a1f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "description 4", "https://res.cloudinary.com/mantasflowers/image/upload/w_1000,ar_1:1,c_fill,g_auto,e_art:hokusai/v1618667917/Flowers/flower6-pink-rose_pajjsc.jpg", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e0f900b3-bf36-4380-9e1b-fbbd534fc915"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "description 3", "https://res.cloudinary.com/mantasflowers/image/upload/w_1000,ar_1:1,c_fill,g_auto,e_art:hokusai/v1618667917/Flowers/flower6-pink-rose_pajjsc.jpg", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("6735991b-f060-4ba8-94f2-b2ac3e935e39"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "best flower in the ninja village", "https://res.cloudinary.com/mantasflowers/image/upload/w_1000,ar_1:1,c_fill,g_auto,e_art:hokusai/v1618667917/Flowers/flower6-pink-rose_pajjsc.jpg", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("40c38637-8f95-4141-85b8-b54a14a3c7d4"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "yes, a veri pritti flauever. plis buy", "https://res.cloudinary.com/mantasflowers/image/upload/w_1000,ar_1:1,c_fill,g_auto,e_art:hokusai/v1618667917/Flowers/flower6-pink-rose_pajjsc.jpg", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("9f5ee6bc-89f3-48a5-9407-628d91208077"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "description 5", "https://res.cloudinary.com/mantasflowers/image/upload/w_1000,ar_1:1,c_fill,g_auto,e_art:hokusai/v1618667917/Flowers/flower6-pink-rose_pajjsc.jpg", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Shipments",
                columns: new[] { "Id", "CreatedOn", "UpdatedOn" },
                values: new object[] { new Guid("ae1ecd2d-3c8d-4980-a997-505a256386df"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedOn", "FirstName", "LastName", "Uid", "UpdatedOn" },
                values: new object[,]
                {
                    { new Guid("9638ae69-7629-4403-90a6-d3ddce6be39c"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Obi-Wan", "Kenobi", "o2DfmuP9NRcw19bDbvSrg6lpavF2", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("468a2813-85d9-4388-95ee-839047a70af0"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Luke", "Skywalker", "ikpWhF3UzsXFAue98r9pBA7RwGs1", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "CreatedOn", "DiscountPrice", "Message", "OrderAddressId", "OrderContactInfoId", "OrderNumber", "PaymentId", "ShipmentId", "Status", "TemporaryPasswordHash", "UpdatedOn" },
                values: new object[] { new Guid("3a6e0c39-2bf3-4c13-9f12-81ac015385d3"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "i feel like a flower", new Guid("1daeb234-2080-4d67-a4c0-72c294498fa1"), new Guid("6c7b122f-d6af-4e21-a559-15b32738b95b"), 123m, new Guid("84a93913-d097-49c8-8d15-c1a04172aec8"), new Guid("ae1ecd2d-3c8d-4980-a997-505a256386df"), "UNPAID", "eyy123", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Category", "CreatedOn", "DiscountPercent", "LeftInStock", "Name", "Price", "ProductInfoId", "ShortDescription", "ThumbnailPictureUrl", "UpdatedOn" },
                values: new object[,]
                {
                    { new Guid("13e57632-dd98-4ad2-8b90-97393432a46a"), "FLOWER", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1000, "my rose", 1.99m, new Guid("40c38637-8f95-4141-85b8-b54a14a3c7d4"), "veri priti flauver", "https://res.cloudinary.com/mantasflowers/image/upload/w_1000,ar_1:1,c_fill,g_auto,e_art:hokusai/v1618667917/Flowers/flower6-pink-rose_pajjsc.jpg", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("8bb8653d-01aa-45b2-a505-94b1f16c6376"), "FLOWER", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0.2m, 123, "konoha leaf", 2.99m, new Guid("6735991b-f060-4ba8-94f2-b2ac3e935e39"), "its a real flower", "https://res.cloudinary.com/mantasflowers/image/upload/w_1000,ar_1:1,c_fill,g_auto,e_art:hokusai/v1618667917/Flowers/flower6-pink-rose_pajjsc.jpg", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("25eeb65d-5d6e-48bc-bb88-b960dc6f0d94"), "BOUQUET", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0.0m, 4, "name 3", 5.99m, new Guid("e0f900b3-bf36-4380-9e1b-fbbd534fc915"), "short description 3", "https://res.cloudinary.com/mantasflowers/image/upload/w_1000,ar_1:1,c_fill,g_auto,e_art:hokusai/v1618667917/Flowers/flower6-pink-rose_pajjsc.jpg", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("9f9b61a8-41ba-445a-8e49-dd76d1918699"), "FLOWER", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0.15m, 400, "name 4", 2.49m, new Guid("6e723707-a565-436b-b24e-d38314f31a1f"), "short description 4", "https://res.cloudinary.com/mantasflowers/image/upload/w_1000,ar_1:1,c_fill,g_auto,e_art:hokusai/v1618667917/Flowers/flower6-pink-rose_pajjsc.jpg", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("6843b919-710d-4044-8b67-0755d994e798"), "BOUQUET", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0.0m, 15, "name 5", 11.29m, new Guid("9f5ee6bc-89f3-48a5-9407-628d91208077"), "short description 5", "https://res.cloudinary.com/mantasflowers/image/upload/w_1000,ar_1:1,c_fill,g_auto,e_art:hokusai/v1618667917/Flowers/flower6-pink-rose_pajjsc.jpg", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("6944022d-e222-40e8-8cc9-f6856b35354d"), "BOUQUET", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0.40m, 153, "name 6", 1.29m, new Guid("80d2511b-77c5-47b9-a055-ace42ff14079"), "short description 6", "https://res.cloudinary.com/mantasflowers/image/upload/w_1000,ar_1:1,c_fill,g_auto,e_art:hokusai/v1618667917/Flowers/flower6-pink-rose_pajjsc.jpg", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e220d349-8a41-4af1-bb4b-83f5784eb47a"), "FLOWER", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0.10m, 4321, "name 7", 0.59m, new Guid("b57795b1-4521-4aa6-817c-22c9e82b3ea7"), "short description 7", "https://res.cloudinary.com/mantasflowers/image/upload/w_1000,ar_1:1,c_fill,g_auto,e_art:hokusai/v1618667917/Flowers/flower6-pink-rose_pajjsc.jpg", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("31f6bccd-6aa5-49bf-a1e3-0c88ae80553a"), "BOUQUET", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0.3m, 125, "name 8", 7.19m, new Guid("5edf7b60-20e1-4ba2-9a56-56754ffc9dbd"), "short description 8", "https://res.cloudinary.com/mantasflowers/image/upload/w_1000,ar_1:1,c_fill,g_auto,e_art:hokusai/v1618667917/Flowers/flower6-pink-rose_pajjsc.jpg", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("21b2e6c8-fdf2-4efb-9e3a-3994add128b2"), "FLOWER", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0.0m, 1233, "name 9", 2.49m, new Guid("908bc516-4fe5-45b6-8688-364ea39b4d46"), "short description 9", "https://res.cloudinary.com/mantasflowers/image/upload/w_1000,ar_1:1,c_fill,g_auto,e_art:hokusai/v1618667917/Flowers/flower6-pink-rose_pajjsc.jpg", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("0e9b9624-43cb-4c6b-b326-d5e8d2a8523f"), "BOUQUET", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0.0m, 34, "name 10", 7.99m, new Guid("08cb2f7d-e5fe-4615-a3e5-8576af69ac83"), "short description 10", "https://res.cloudinary.com/mantasflowers/image/upload/w_1000,ar_1:1,c_fill,g_auto,e_art:hokusai/v1618667917/Flowers/flower6-pink-rose_pajjsc.jpg", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "UserAddresses",
                columns: new[] { "Id", "City", "Country", "CreatedOn", "Street", "UpdatedOn", "UserId", "Zipcode" },
                values: new object[,]
                {
                    { new Guid("866fefce-a223-4f8e-aab2-e7a504337174"), "Vilnius", "LT", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Autism street", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("9638ae69-7629-4403-90a6-d3ddce6be39c"), "LT-12345" },
                    { new Guid("bb87575b-7d3a-4dc8-969f-55c8f224ea5c"), "Kaunas", "LT", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kaimas street", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("468a2813-85d9-4388-95ee-839047a70af0"), "LT-54321" }
                });

            migrationBuilder.InsertData(
                table: "UserContactInfo",
                columns: new[] { "Id", "CreatedOn", "Email", "Phone", "UpdatedOn", "UserId" },
                values: new object[,]
                {
                    { new Guid("1b8ff0af-628c-403a-877a-080077eb1ce5"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "theforcebewithyou@coruscant.com", "+37061234567", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("9638ae69-7629-4403-90a6-d3ddce6be39c") },
                    { new Guid("1f409675-69f1-417f-a4d1-39713333635a"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "asdiasdioas@asfiasifa.com", "+37069263957", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("468a2813-85d9-4388-95ee-839047a70af0") }
                });

            migrationBuilder.InsertData(
                table: "OrderItems",
                columns: new[] { "Id", "CreatedOn", "OrderId", "ProductId", "Quantity", "UnitPrice", "UpdatedOn" },
                values: new object[] { new Guid("3c922b5f-e1cb-4473-ae03-5c0c15fbc5cf"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3a6e0c39-2bf3-4c13-9f12-81ac015385d3"), new Guid("13e57632-dd98-4ad2-8b90-97393432a46a"), 666, 1.59m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "ProductReviews",
                columns: new[] { "Id", "CreatedOn", "ProductId", "ReviewScore", "UpdatedOn", "UserId" },
                values: new object[,]
                {
                    { new Guid("da8eab62-8547-4b35-b630-63b555a17242"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("13e57632-dd98-4ad2-8b90-97393432a46a"), 3.5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("9638ae69-7629-4403-90a6-d3ddce6be39c") },
                    { new Guid("f0b4865b-00fa-4e6f-bf44-0772ba5f174e"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("8bb8653d-01aa-45b2-a505-94b1f16c6376"), 10.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("9638ae69-7629-4403-90a6-d3ddce6be39c") }
                });

            migrationBuilder.InsertData(
                table: "UserOrders",
                columns: new[] { "Id", "CreatedOn", "OrderId", "UpdatedOn", "UserId" },
                values: new object[] { new Guid("09608341-3cba-4d64-a96f-ede9065cdf97"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3a6e0c39-2bf3-4c13-9f12-81ac015385d3"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("9638ae69-7629-4403-90a6-d3ddce6be39c") });

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
                name: "IX_Orders_OrderAddressId",
                table: "Orders",
                column: "OrderAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OrderContactInfoId",
                table: "Orders",
                column: "OrderContactInfoId");

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
                name: "OrderAddresses");

            migrationBuilder.DropTable(
                name: "OrderContactInfo");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "Shipments");
        }
    }
}
