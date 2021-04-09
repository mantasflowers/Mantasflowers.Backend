using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Mantasflowers.Persistence.Migrations
{
    public partial class Added_review_score : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Coupons",
                keyColumn: "Id",
                keyValue: new Guid("f5212460-7c4d-4239-8a62-b45e0bcb70b4"));

            migrationBuilder.DeleteData(
                table: "Feedback",
                keyColumn: "Id",
                keyValue: new Guid("81405bee-49f8-482d-b149-962fff7ac4b8"));

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: new Guid("dd907008-d3ee-4d8e-bb7f-b9ba43263707"));

            migrationBuilder.DeleteData(
                table: "ProductReviews",
                keyColumn: "Id",
                keyValue: new Guid("1797c8b0-7fa3-4396-a146-f0ff87c9760d"));

            migrationBuilder.DeleteData(
                table: "UserOrders",
                keyColumn: "Id",
                keyValue: new Guid("cc8d7fb6-3aa2-472c-8e86-3bea294872d8"));

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("a7b20c25-7889-45c4-969a-aaae2e0e92b7"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("97695f46-1619-4176-95c3-2ba992f7ab44"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("2cf00ae5-7e78-4294-990f-51acd21f1d39"));

            migrationBuilder.DeleteData(
                table: "OrderAddresses",
                keyColumn: "Id",
                keyValue: new Guid("01d9e778-4ef1-41eb-be43-5322e928da12"));

            migrationBuilder.DeleteData(
                table: "OrderContactInfo",
                keyColumn: "Id",
                keyValue: new Guid("53039c14-b8eb-4abb-ac56-347e2a67b1c5"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("5d9dac82-b374-4d86-893e-f40ad7582dc1"));

            migrationBuilder.DeleteData(
                table: "ProductInfo",
                keyColumn: "Id",
                keyValue: new Guid("d560680a-8b99-4623-99c9-a0eaf53b7346"));

            migrationBuilder.DeleteData(
                table: "Shipments",
                keyColumn: "Id",
                keyValue: new Guid("5eac0c84-50d1-48c4-a527-02ff4c3104ec"));

            migrationBuilder.DeleteData(
                table: "UserAddresses",
                keyColumn: "Id",
                keyValue: new Guid("2080e136-2343-44f5-aa4d-ae8ac4e59eb7"));

            migrationBuilder.DeleteData(
                table: "UserContactInfo",
                keyColumn: "Id",
                keyValue: new Guid("c9bd4b34-9736-4f54-842e-4cb4414e9459"));

            migrationBuilder.RenameColumn(
                name: "Review",
                table: "ProductReviews",
                newName: "ReviewText");

            migrationBuilder.AddColumn<double>(
                name: "ReviewScore",
                table: "ProductReviews",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.InsertData(
                table: "Coupons",
                columns: new[] { "Id", "BeginDate", "CreatedOn", "DiscountPrice", "EndDate", "Name", "OrderOverPrice", "UpdatedOn" },
                values: new object[] { new Guid("0e445786-f5a9-47a8-8f85-090fcce1478c"), new DateTime(2021, 4, 9, 20, 45, 42, 734, DateTimeKind.Utc).AddTicks(9482), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 10.0m, new DateTime(2021, 7, 8, 20, 45, 42, 734, DateTimeKind.Utc).AddTicks(9885), "PSK666", 15.0m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Feedback",
                columns: new[] { "Id", "CreatedOn", "Email", "Name", "Text", "UpdatedOn" },
                values: new object[] { new Guid("b27498b3-8c3a-4169-bb56-cd581c0570cb"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lambs street 13", "Hannibal Lecter", "Tasty flowers", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "OrderAddresses",
                columns: new[] { "Id", "City", "Country", "CreatedOn", "Street", "UpdatedOn", "Zipcode" },
                values: new object[] { new Guid("d6885176-642f-476d-9e39-424a78f47bac"), "Vilnius", "LT", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Autism street", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "LT-12345" });

            migrationBuilder.InsertData(
                table: "OrderContactInfo",
                columns: new[] { "Id", "CreatedOn", "Email", "Phone", "UpdatedOn" },
                values: new object[] { new Guid("178beff7-7de9-4580-9868-a3d98cdad2a2"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "theforcebewithyou@coruscant.com", "861234567", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "Id", "CreatedOn", "UpdatedOn" },
                values: new object[] { new Guid("1a33844e-0bd6-4d29-9113-63d0e917b424"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "ProductInfo",
                columns: new[] { "Id", "CreatedOn", "Description", "PictureUrl", "UpdatedOn" },
                values: new object[,]
                {
                    { new Guid("5f12b5e3-36ca-4ff5-a2e0-f8382eb964e1"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "yes, a veri pritti flauever. plis buy", "https://aodaisjdoasjdioas.com", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("04807a6b-f6b2-43c3-881e-e2accd326091"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "best flower in the ninja village", "https://ioashfiausfa.com", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Shipments",
                columns: new[] { "Id", "CreatedOn", "UpdatedOn" },
                values: new object[] { new Guid("dc167821-ef16-4d1d-b0c8-159503196799"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "UserAddresses",
                columns: new[] { "Id", "City", "Country", "CreatedOn", "Street", "UpdatedOn", "Zipcode" },
                values: new object[] { new Guid("4fdabf5e-e952-43e4-83b6-4d81eac4e7a6"), "Vilnius", "LT", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Autism street", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "LT-12345" });

            migrationBuilder.InsertData(
                table: "UserContactInfo",
                columns: new[] { "Id", "CreatedOn", "Email", "Phone", "UpdatedOn" },
                values: new object[] { new Guid("94f7958c-cf03-40ed-b27d-766527fed2a9"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "theforcebewithyou@coruscant.com", "861234567", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "CreatedOn", "DiscountPrice", "Message", "OrderAddressId", "OrderContactInfoId", "OrderNumber", "PaymentId", "ShipmentId", "Status", "TemporaryPasswordHash", "UpdatedOn" },
                values: new object[] { new Guid("c8ab8521-6a1f-4f68-a3d2-ae6deec529fb"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "i feel like a flower", new Guid("d6885176-642f-476d-9e39-424a78f47bac"), new Guid("178beff7-7de9-4580-9868-a3d98cdad2a2"), 123m, new Guid("1a33844e-0bd6-4d29-9113-63d0e917b424"), new Guid("dc167821-ef16-4d1d-b0c8-159503196799"), "UNPAID", "eyy123", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Category", "CreatedOn", "DiscountPercent", "LeftInStock", "Name", "Price", "ProductInfoId", "ShortDescription", "ThumbnailPictureUrl", "UpdatedOn" },
                values: new object[,]
                {
                    { new Guid("58555e5f-079c-4f6e-a86f-dd6450e2245c"), "FLOWER", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1000, "my rose", 1.99m, new Guid("5f12b5e3-36ca-4ff5-a2e0-f8382eb964e1"), "veri priti flauver", "https://aodaisjdoasjdioas.com", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("64acfe75-d9e9-40a4-aa0f-000d786088d3"), "FLOWER", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0.2m, 123, "konoha leaf", 2.99m, new Guid("04807a6b-f6b2-43c3-881e-e2accd326091"), "its a real flower", "https://oiashdiasdias.com", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AddressId", "CreatedOn", "FirstName", "LastName", "UpdatedOn", "UserContactInfoId" },
                values: new object[] { new Guid("fe63a2e6-5244-43c9-87af-8cc5759e62fc"), new Guid("4fdabf5e-e952-43e4-83b6-4d81eac4e7a6"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Obi-Wan", "Kenobi", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("94f7958c-cf03-40ed-b27d-766527fed2a9") });

            migrationBuilder.InsertData(
                table: "OrderItems",
                columns: new[] { "Id", "CreatedOn", "OrderId", "ProductId", "Quantity", "UnitPrice", "UpdatedOn" },
                values: new object[] { new Guid("5640e66f-209a-4e04-8766-6dfdd6bdb7ba"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("c8ab8521-6a1f-4f68-a3d2-ae6deec529fb"), new Guid("58555e5f-079c-4f6e-a86f-dd6450e2245c"), 666, 1.59m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "ProductReviews",
                columns: new[] { "Id", "CreatedOn", "ProductId", "ReviewScore", "ReviewText", "UpdatedOn", "UserId" },
                values: new object[] { new Guid("37dbd85a-a9bd-484f-b1b0-fde8b7a0aefc"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("58555e5f-079c-4f6e-a86f-dd6450e2245c"), 0.0, "im colorblind, ordered wrong flowers", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("fe63a2e6-5244-43c9-87af-8cc5759e62fc") });

            migrationBuilder.InsertData(
                table: "UserOrders",
                columns: new[] { "Id", "CreatedOn", "OrderId", "UpdatedOn", "UserId" },
                values: new object[] { new Guid("0e60e36f-6bb4-4ec0-872d-527068631f3f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("c8ab8521-6a1f-4f68-a3d2-ae6deec529fb"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("fe63a2e6-5244-43c9-87af-8cc5759e62fc") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Coupons",
                keyColumn: "Id",
                keyValue: new Guid("0e445786-f5a9-47a8-8f85-090fcce1478c"));

            migrationBuilder.DeleteData(
                table: "Feedback",
                keyColumn: "Id",
                keyValue: new Guid("b27498b3-8c3a-4169-bb56-cd581c0570cb"));

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: new Guid("5640e66f-209a-4e04-8766-6dfdd6bdb7ba"));

            migrationBuilder.DeleteData(
                table: "ProductReviews",
                keyColumn: "Id",
                keyValue: new Guid("37dbd85a-a9bd-484f-b1b0-fde8b7a0aefc"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("64acfe75-d9e9-40a4-aa0f-000d786088d3"));

            migrationBuilder.DeleteData(
                table: "UserOrders",
                keyColumn: "Id",
                keyValue: new Guid("0e60e36f-6bb4-4ec0-872d-527068631f3f"));

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("c8ab8521-6a1f-4f68-a3d2-ae6deec529fb"));

            migrationBuilder.DeleteData(
                table: "ProductInfo",
                keyColumn: "Id",
                keyValue: new Guid("04807a6b-f6b2-43c3-881e-e2accd326091"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("58555e5f-079c-4f6e-a86f-dd6450e2245c"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("fe63a2e6-5244-43c9-87af-8cc5759e62fc"));

            migrationBuilder.DeleteData(
                table: "OrderAddresses",
                keyColumn: "Id",
                keyValue: new Guid("d6885176-642f-476d-9e39-424a78f47bac"));

            migrationBuilder.DeleteData(
                table: "OrderContactInfo",
                keyColumn: "Id",
                keyValue: new Guid("178beff7-7de9-4580-9868-a3d98cdad2a2"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("1a33844e-0bd6-4d29-9113-63d0e917b424"));

            migrationBuilder.DeleteData(
                table: "ProductInfo",
                keyColumn: "Id",
                keyValue: new Guid("5f12b5e3-36ca-4ff5-a2e0-f8382eb964e1"));

            migrationBuilder.DeleteData(
                table: "Shipments",
                keyColumn: "Id",
                keyValue: new Guid("dc167821-ef16-4d1d-b0c8-159503196799"));

            migrationBuilder.DeleteData(
                table: "UserAddresses",
                keyColumn: "Id",
                keyValue: new Guid("4fdabf5e-e952-43e4-83b6-4d81eac4e7a6"));

            migrationBuilder.DeleteData(
                table: "UserContactInfo",
                keyColumn: "Id",
                keyValue: new Guid("94f7958c-cf03-40ed-b27d-766527fed2a9"));

            migrationBuilder.DropColumn(
                name: "ReviewScore",
                table: "ProductReviews");

            migrationBuilder.RenameColumn(
                name: "ReviewText",
                table: "ProductReviews",
                newName: "Review");

            migrationBuilder.InsertData(
                table: "Coupons",
                columns: new[] { "Id", "BeginDate", "CreatedOn", "DiscountPrice", "EndDate", "Name", "OrderOverPrice", "UpdatedOn" },
                values: new object[] { new Guid("f5212460-7c4d-4239-8a62-b45e0bcb70b4"), new DateTime(2021, 4, 9, 19, 56, 56, 853, DateTimeKind.Utc).AddTicks(5371), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 10.0m, new DateTime(2021, 7, 8, 19, 56, 56, 853, DateTimeKind.Utc).AddTicks(5853), "PSK666", 15.0m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Feedback",
                columns: new[] { "Id", "CreatedOn", "Email", "Name", "Text", "UpdatedOn" },
                values: new object[] { new Guid("81405bee-49f8-482d-b149-962fff7ac4b8"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lambs street 13", "Hannibal Lecter", "Tasty flowers", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "OrderAddresses",
                columns: new[] { "Id", "City", "Country", "CreatedOn", "Street", "UpdatedOn", "Zipcode" },
                values: new object[] { new Guid("01d9e778-4ef1-41eb-be43-5322e928da12"), "Vilnius", "LT", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Autism street", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "LT-12345" });

            migrationBuilder.InsertData(
                table: "OrderContactInfo",
                columns: new[] { "Id", "CreatedOn", "Email", "Phone", "UpdatedOn" },
                values: new object[] { new Guid("53039c14-b8eb-4abb-ac56-347e2a67b1c5"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "theforcebewithyou@coruscant.com", "861234567", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "Id", "CreatedOn", "UpdatedOn" },
                values: new object[] { new Guid("5d9dac82-b374-4d86-893e-f40ad7582dc1"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "ProductInfo",
                columns: new[] { "Id", "CreatedOn", "Description", "PictureUrl", "UpdatedOn" },
                values: new object[] { new Guid("d560680a-8b99-4623-99c9-a0eaf53b7346"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "yes, a veri pritti flauever. plis buy", "https://aodaisjdoasjdioas.com", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Shipments",
                columns: new[] { "Id", "CreatedOn", "UpdatedOn" },
                values: new object[] { new Guid("5eac0c84-50d1-48c4-a527-02ff4c3104ec"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "UserAddresses",
                columns: new[] { "Id", "City", "Country", "CreatedOn", "Street", "UpdatedOn", "Zipcode" },
                values: new object[] { new Guid("2080e136-2343-44f5-aa4d-ae8ac4e59eb7"), "Vilnius", "LT", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Autism street", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "LT-12345" });

            migrationBuilder.InsertData(
                table: "UserContactInfo",
                columns: new[] { "Id", "CreatedOn", "Email", "Phone", "UpdatedOn" },
                values: new object[] { new Guid("c9bd4b34-9736-4f54-842e-4cb4414e9459"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "theforcebewithyou@coruscant.com", "861234567", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "CreatedOn", "DiscountPrice", "Message", "OrderAddressId", "OrderContactInfoId", "OrderNumber", "PaymentId", "ShipmentId", "Status", "TemporaryPasswordHash", "UpdatedOn" },
                values: new object[] { new Guid("a7b20c25-7889-45c4-969a-aaae2e0e92b7"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "i feel like a flower", new Guid("01d9e778-4ef1-41eb-be43-5322e928da12"), new Guid("53039c14-b8eb-4abb-ac56-347e2a67b1c5"), 123m, new Guid("5d9dac82-b374-4d86-893e-f40ad7582dc1"), new Guid("5eac0c84-50d1-48c4-a527-02ff4c3104ec"), "UNPAID", "eyy123", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Category", "CreatedOn", "DiscountPercent", "LeftInStock", "Name", "Price", "ProductInfoId", "ShortDescription", "ThumbnailPictureUrl", "UpdatedOn" },
                values: new object[] { new Guid("97695f46-1619-4176-95c3-2ba992f7ab44"), "FLOWER", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1000, "my rose", 1.99m, new Guid("d560680a-8b99-4623-99c9-a0eaf53b7346"), "veri priti flauver", "https://aodaisjdoasjdioas.com", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AddressId", "CreatedOn", "FirstName", "LastName", "UpdatedOn", "UserContactInfoId" },
                values: new object[] { new Guid("2cf00ae5-7e78-4294-990f-51acd21f1d39"), new Guid("2080e136-2343-44f5-aa4d-ae8ac4e59eb7"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Obi-Wan", "Kenobi", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("c9bd4b34-9736-4f54-842e-4cb4414e9459") });

            migrationBuilder.InsertData(
                table: "OrderItems",
                columns: new[] { "Id", "CreatedOn", "OrderId", "ProductId", "Quantity", "UnitPrice", "UpdatedOn" },
                values: new object[] { new Guid("dd907008-d3ee-4d8e-bb7f-b9ba43263707"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("a7b20c25-7889-45c4-969a-aaae2e0e92b7"), new Guid("97695f46-1619-4176-95c3-2ba992f7ab44"), 666, 1.59m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "ProductReviews",
                columns: new[] { "Id", "CreatedOn", "ProductId", "Review", "UpdatedOn", "UserId" },
                values: new object[] { new Guid("1797c8b0-7fa3-4396-a146-f0ff87c9760d"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("97695f46-1619-4176-95c3-2ba992f7ab44"), "im colorblind, ordered wrong flowers", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("2cf00ae5-7e78-4294-990f-51acd21f1d39") });

            migrationBuilder.InsertData(
                table: "UserOrders",
                columns: new[] { "Id", "CreatedOn", "OrderId", "UpdatedOn", "UserId" },
                values: new object[] { new Guid("cc8d7fb6-3aa2-472c-8e86-3bea294872d8"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("a7b20c25-7889-45c4-969a-aaae2e0e92b7"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("2cf00ae5-7e78-4294-990f-51acd21f1d39") });
        }
    }
}
