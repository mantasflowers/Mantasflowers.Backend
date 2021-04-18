using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Mantasflowers.Persistence.Migrations
{
    public partial class moving_rows_from_info_to_product : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Coupons",
                keyColumn: "Id",
                keyValue: new Guid("6354333f-456f-4c13-9bd5-5a47392fe4ff"));

            migrationBuilder.DeleteData(
                table: "Feedback",
                keyColumn: "Id",
                keyValue: new Guid("0c69fd50-446f-4639-b27f-f464229f24ed"));

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: new Guid("fc8a33fc-71d5-4787-9abb-3415b5c22ede"));

            migrationBuilder.DeleteData(
                table: "ProductReviews",
                keyColumn: "Id",
                keyValue: new Guid("b6a3b402-e5cd-4ad2-bf36-a1ca3f902000"));

            migrationBuilder.DeleteData(
                table: "UserOrders",
                keyColumn: "Id",
                keyValue: new Guid("302df6a9-4a37-44c9-ab1e-29352682cc84"));

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("8033acd8-c43d-4ce8-98ad-f0b334cb578a"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("bc254cf4-0f4a-410c-802f-7c154e7cc0e7"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("28d2711f-9f6c-4dd5-ac89-98f44535f740"));

            migrationBuilder.DeleteData(
                table: "OrderAddresses",
                keyColumn: "Id",
                keyValue: new Guid("55146906-3fb3-4f3b-b8c8-beae802a20c3"));

            migrationBuilder.DeleteData(
                table: "OrderContactInfo",
                keyColumn: "Id",
                keyValue: new Guid("a7fbcb4e-8215-4749-9f20-e5baada7592e"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("656260de-75be-49a3-94d3-0b32a86a09df"));

            migrationBuilder.DeleteData(
                table: "ProductInfo",
                keyColumn: "Id",
                keyValue: new Guid("51d3c3f7-031b-4602-8e8b-b5e5019f6f46"));

            migrationBuilder.DeleteData(
                table: "Shipments",
                keyColumn: "Id",
                keyValue: new Guid("a0f704a4-0ade-4933-862f-a926d44c995e"));

            migrationBuilder.DeleteData(
                table: "UserAddresses",
                keyColumn: "Id",
                keyValue: new Guid("927b0309-faf9-4c6d-bc83-b78a07517813"));

            migrationBuilder.DeleteData(
                table: "UserContactInfo",
                keyColumn: "Id",
                keyValue: new Guid("8f10fe1f-2f31-4ae2-a70c-3275dac45f1c"));

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Review",
                table: "ProductReviews");

            migrationBuilder.DropColumn(
                name: "DiscountPercent",
                table: "ProductInfo");

            migrationBuilder.DropColumn(
                name: "LeftInStock",
                table: "ProductInfo");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "ProductInfo");

            migrationBuilder.RenameColumn(
                name: "PictureName",
                table: "Products",
                newName: "ThumbnailPictureUrl");

            migrationBuilder.AddColumn<decimal>(
                name: "DiscountPercent",
                table: "Products",
                type: "decimal(18,4)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LeftInStock",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Products",
                type: "decimal(18,4)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "ShortDescription",
                table: "Products",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "ReviewScore",
                table: "ProductReviews",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "ProductInfo",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PictureUrl",
                table: "ProductInfo",
                type: "nvarchar(260)",
                maxLength: 260,
                nullable: true);

            migrationBuilder.InsertData(
                table: "Coupons",
                columns: new[] { "Id", "BeginDate", "CreatedOn", "DiscountPrice", "EndDate", "Name", "OrderOverPrice", "UpdatedOn" },
                values: new object[] { new Guid("2fa17dd3-c4f3-423e-abc4-b974786bd338"), new DateTime(2021, 4, 18, 14, 41, 2, 778, DateTimeKind.Utc).AddTicks(4403), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 10.0m, new DateTime(2021, 7, 17, 14, 41, 2, 778, DateTimeKind.Utc).AddTicks(4605), "PSK666", 15.0m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Feedback",
                columns: new[] { "Id", "CreatedOn", "Email", "Name", "Text", "UpdatedOn" },
                values: new object[] { new Guid("55d626e5-f6a1-4984-a320-b98e16b96685"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lambs street 13", "Hannibal Lecter", "Tasty flowers", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "OrderAddresses",
                columns: new[] { "Id", "City", "Country", "CreatedOn", "Street", "UpdatedOn", "Zipcode" },
                values: new object[] { new Guid("61d4a3e8-e751-4960-b2f7-9ded63689d61"), "Vilnius", "LT", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Autism street", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "LT-12345" });

            migrationBuilder.InsertData(
                table: "OrderContactInfo",
                columns: new[] { "Id", "CreatedOn", "Email", "Phone", "UpdatedOn" },
                values: new object[] { new Guid("a4231e59-9c36-4e42-8c10-669d58a5fce5"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "theforcebewithyou@coruscant.com", "861234567", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "Id", "CreatedOn", "UpdatedOn" },
                values: new object[] { new Guid("56d4ff4f-8aba-4656-b27b-0afb5b91b8e1"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "ProductInfo",
                columns: new[] { "Id", "CreatedOn", "Description", "PictureUrl", "UpdatedOn" },
                values: new object[,]
                {
                    { new Guid("98a482a1-fa9d-41b5-bb3a-8d1af64085ce"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "yes, a veri pritti flauever. plis buy", "https://aodaisjdoasjdioas.com", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("59fe2108-08ab-41ed-a6c3-abf5ea76087e"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "best flower in the ninja village", "https://ioashfiausfa.com", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Shipments",
                columns: new[] { "Id", "CreatedOn", "UpdatedOn" },
                values: new object[] { new Guid("00267483-f810-4edb-97c7-c81418b30a6f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "UserAddresses",
                columns: new[] { "Id", "City", "Country", "CreatedOn", "Street", "UpdatedOn", "Zipcode" },
                values: new object[] { new Guid("dc7d9907-5562-4eef-b1c3-8754db1888be"), "Vilnius", "LT", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Autism street", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "LT-12345" });

            migrationBuilder.InsertData(
                table: "UserContactInfo",
                columns: new[] { "Id", "CreatedOn", "Email", "Phone", "UpdatedOn" },
                values: new object[] { new Guid("24d962e2-4464-459c-b177-ce5acae79f14"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "theforcebewithyou@coruscant.com", "861234567", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "CreatedOn", "DiscountPrice", "Message", "OrderAddressId", "OrderContactInfoId", "OrderNumber", "PaymentId", "ShipmentId", "Status", "TemporaryPasswordHash", "UpdatedOn" },
                values: new object[] { new Guid("5df3b984-c74e-42a9-b465-be3a7f2a2766"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "i feel like a flower", new Guid("61d4a3e8-e751-4960-b2f7-9ded63689d61"), new Guid("a4231e59-9c36-4e42-8c10-669d58a5fce5"), 123m, new Guid("56d4ff4f-8aba-4656-b27b-0afb5b91b8e1"), new Guid("00267483-f810-4edb-97c7-c81418b30a6f"), "UNPAID", "eyy123", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Category", "CreatedOn", "DiscountPercent", "LeftInStock", "Name", "Price", "ProductInfoId", "ShortDescription", "ThumbnailPictureUrl", "UpdatedOn" },
                values: new object[,]
                {
                    { new Guid("b909a958-286d-4875-9dea-171e84d7d574"), "FLOWER", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1000, "my rose", 1.99m, new Guid("98a482a1-fa9d-41b5-bb3a-8d1af64085ce"), "veri priti flauver", "https://aodaisjdoasjdioas.com", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("7992e7a5-214c-4c9f-bab7-8be3b7e60784"), "FLOWER", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0.2m, 123, "konoha leaf", 2.99m, new Guid("59fe2108-08ab-41ed-a6c3-abf5ea76087e"), "its a real flower", "https://oiashdiasdias.com", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AddressId", "CreatedOn", "FirstName", "LastName", "UpdatedOn", "UserContactInfoId" },
                values: new object[] { new Guid("c5726e81-6160-4ffe-bed9-ad6c3f0f2e05"), new Guid("dc7d9907-5562-4eef-b1c3-8754db1888be"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Obi-Wan", "Kenobi", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("24d962e2-4464-459c-b177-ce5acae79f14") });

            migrationBuilder.InsertData(
                table: "OrderItems",
                columns: new[] { "Id", "CreatedOn", "OrderId", "ProductId", "Quantity", "UnitPrice", "UpdatedOn" },
                values: new object[] { new Guid("9c91d80b-5982-4f23-9d70-4544cc3438f1"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("5df3b984-c74e-42a9-b465-be3a7f2a2766"), new Guid("b909a958-286d-4875-9dea-171e84d7d574"), 666, 1.59m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "ProductReviews",
                columns: new[] { "Id", "CreatedOn", "ProductId", "ReviewScore", "UpdatedOn", "UserId" },
                values: new object[,]
                {
                    { new Guid("1d9d4b9d-b239-44d6-9655-07cab817a42e"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("b909a958-286d-4875-9dea-171e84d7d574"), 3.5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("c5726e81-6160-4ffe-bed9-ad6c3f0f2e05") },
                    { new Guid("3c97b7d7-55cb-4a6e-bc9e-815ce9d8a183"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("7992e7a5-214c-4c9f-bab7-8be3b7e60784"), 10.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("c5726e81-6160-4ffe-bed9-ad6c3f0f2e05") }
                });

            migrationBuilder.InsertData(
                table: "UserOrders",
                columns: new[] { "Id", "CreatedOn", "OrderId", "UpdatedOn", "UserId" },
                values: new object[] { new Guid("0d2e8083-5329-4979-ad2a-59e3fd111443"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("5df3b984-c74e-42a9-b465-be3a7f2a2766"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("c5726e81-6160-4ffe-bed9-ad6c3f0f2e05") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Coupons",
                keyColumn: "Id",
                keyValue: new Guid("2fa17dd3-c4f3-423e-abc4-b974786bd338"));

            migrationBuilder.DeleteData(
                table: "Feedback",
                keyColumn: "Id",
                keyValue: new Guid("55d626e5-f6a1-4984-a320-b98e16b96685"));

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: new Guid("9c91d80b-5982-4f23-9d70-4544cc3438f1"));

            migrationBuilder.DeleteData(
                table: "ProductReviews",
                keyColumn: "Id",
                keyValue: new Guid("1d9d4b9d-b239-44d6-9655-07cab817a42e"));

            migrationBuilder.DeleteData(
                table: "ProductReviews",
                keyColumn: "Id",
                keyValue: new Guid("3c97b7d7-55cb-4a6e-bc9e-815ce9d8a183"));

            migrationBuilder.DeleteData(
                table: "UserOrders",
                keyColumn: "Id",
                keyValue: new Guid("0d2e8083-5329-4979-ad2a-59e3fd111443"));

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("5df3b984-c74e-42a9-b465-be3a7f2a2766"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("7992e7a5-214c-4c9f-bab7-8be3b7e60784"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b909a958-286d-4875-9dea-171e84d7d574"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("c5726e81-6160-4ffe-bed9-ad6c3f0f2e05"));

            migrationBuilder.DeleteData(
                table: "OrderAddresses",
                keyColumn: "Id",
                keyValue: new Guid("61d4a3e8-e751-4960-b2f7-9ded63689d61"));

            migrationBuilder.DeleteData(
                table: "OrderContactInfo",
                keyColumn: "Id",
                keyValue: new Guid("a4231e59-9c36-4e42-8c10-669d58a5fce5"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("56d4ff4f-8aba-4656-b27b-0afb5b91b8e1"));

            migrationBuilder.DeleteData(
                table: "ProductInfo",
                keyColumn: "Id",
                keyValue: new Guid("59fe2108-08ab-41ed-a6c3-abf5ea76087e"));

            migrationBuilder.DeleteData(
                table: "ProductInfo",
                keyColumn: "Id",
                keyValue: new Guid("98a482a1-fa9d-41b5-bb3a-8d1af64085ce"));

            migrationBuilder.DeleteData(
                table: "Shipments",
                keyColumn: "Id",
                keyValue: new Guid("00267483-f810-4edb-97c7-c81418b30a6f"));

            migrationBuilder.DeleteData(
                table: "UserAddresses",
                keyColumn: "Id",
                keyValue: new Guid("dc7d9907-5562-4eef-b1c3-8754db1888be"));

            migrationBuilder.DeleteData(
                table: "UserContactInfo",
                keyColumn: "Id",
                keyValue: new Guid("24d962e2-4464-459c-b177-ce5acae79f14"));

            migrationBuilder.DropColumn(
                name: "DiscountPercent",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "LeftInStock",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ShortDescription",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ReviewScore",
                table: "ProductReviews");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "ProductInfo");

            migrationBuilder.DropColumn(
                name: "PictureUrl",
                table: "ProductInfo");

            migrationBuilder.RenameColumn(
                name: "ThumbnailPictureUrl",
                table: "Products",
                newName: "PictureName");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Products",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Review",
                table: "ProductReviews",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "DiscountPercent",
                table: "ProductInfo",
                type: "decimal(18,4)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LeftInStock",
                table: "ProductInfo",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "ProductInfo",
                type: "decimal(18,4)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.InsertData(
                table: "Coupons",
                columns: new[] { "Id", "BeginDate", "CreatedOn", "DiscountPrice", "EndDate", "Name", "OrderOverPrice", "UpdatedOn" },
                values: new object[] { new Guid("6354333f-456f-4c13-9bd5-5a47392fe4ff"), new DateTime(2021, 3, 31, 17, 54, 23, 251, DateTimeKind.Utc).AddTicks(3670), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 10.0m, new DateTime(2021, 6, 29, 17, 54, 23, 251, DateTimeKind.Utc).AddTicks(3895), "PSK666", 15.0m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Feedback",
                columns: new[] { "Id", "CreatedOn", "Email", "Name", "Text", "UpdatedOn" },
                values: new object[] { new Guid("0c69fd50-446f-4639-b27f-f464229f24ed"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lambs street 13", "Hannibal Lecter", "Tasty flowers", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "OrderAddresses",
                columns: new[] { "Id", "City", "Country", "CreatedOn", "Street", "UpdatedOn", "Zipcode" },
                values: new object[] { new Guid("55146906-3fb3-4f3b-b8c8-beae802a20c3"), "Vilnius", "LT", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Autism street", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "LT-12345" });

            migrationBuilder.InsertData(
                table: "OrderContactInfo",
                columns: new[] { "Id", "CreatedOn", "Email", "Phone", "UpdatedOn" },
                values: new object[] { new Guid("a7fbcb4e-8215-4749-9f20-e5baada7592e"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "theforcebewithyou@coruscant.com", "861234567", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "Id", "CreatedOn", "UpdatedOn" },
                values: new object[] { new Guid("656260de-75be-49a3-94d3-0b32a86a09df"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "ProductInfo",
                columns: new[] { "Id", "CreatedOn", "DiscountPercent", "LeftInStock", "Price", "UpdatedOn" },
                values: new object[] { new Guid("51d3c3f7-031b-4602-8e8b-b5e5019f6f46"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1000, 1.99m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Shipments",
                columns: new[] { "Id", "CreatedOn", "UpdatedOn" },
                values: new object[] { new Guid("a0f704a4-0ade-4933-862f-a926d44c995e"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "UserAddresses",
                columns: new[] { "Id", "City", "Country", "CreatedOn", "Street", "UpdatedOn", "Zipcode" },
                values: new object[] { new Guid("927b0309-faf9-4c6d-bc83-b78a07517813"), "Vilnius", "LT", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Autism street", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "LT-12345" });

            migrationBuilder.InsertData(
                table: "UserContactInfo",
                columns: new[] { "Id", "CreatedOn", "Email", "Phone", "UpdatedOn" },
                values: new object[] { new Guid("8f10fe1f-2f31-4ae2-a70c-3275dac45f1c"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "theforcebewithyou@coruscant.com", "861234567", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "CreatedOn", "DiscountPrice", "Message", "OrderAddressId", "OrderContactInfoId", "OrderNumber", "PaymentId", "ShipmentId", "Status", "TemporaryPasswordHash", "UpdatedOn" },
                values: new object[] { new Guid("8033acd8-c43d-4ce8-98ad-f0b334cb578a"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "i feel like a flower", new Guid("55146906-3fb3-4f3b-b8c8-beae802a20c3"), new Guid("a7fbcb4e-8215-4749-9f20-e5baada7592e"), 123m, new Guid("656260de-75be-49a3-94d3-0b32a86a09df"), new Guid("a0f704a4-0ade-4933-862f-a926d44c995e"), "UNPAID", "eyy123", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Category", "CreatedOn", "Description", "Name", "PictureName", "ProductInfoId", "UpdatedOn" },
                values: new object[] { new Guid("bc254cf4-0f4a-410c-802f-7c154e7cc0e7"), "FLOWER", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "veri priti flauver", "my rose", null, new Guid("51d3c3f7-031b-4602-8e8b-b5e5019f6f46"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AddressId", "CreatedOn", "FirstName", "LastName", "UpdatedOn", "UserContactInfoId" },
                values: new object[] { new Guid("28d2711f-9f6c-4dd5-ac89-98f44535f740"), new Guid("927b0309-faf9-4c6d-bc83-b78a07517813"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Obi-Wan", "Kenobi", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("8f10fe1f-2f31-4ae2-a70c-3275dac45f1c") });

            migrationBuilder.InsertData(
                table: "OrderItems",
                columns: new[] { "Id", "CreatedOn", "OrderId", "ProductId", "Quantity", "UnitPrice", "UpdatedOn" },
                values: new object[] { new Guid("fc8a33fc-71d5-4787-9abb-3415b5c22ede"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("8033acd8-c43d-4ce8-98ad-f0b334cb578a"), new Guid("bc254cf4-0f4a-410c-802f-7c154e7cc0e7"), 666, 1.59m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "ProductReviews",
                columns: new[] { "Id", "CreatedOn", "ProductId", "Review", "UpdatedOn", "UserId" },
                values: new object[] { new Guid("b6a3b402-e5cd-4ad2-bf36-a1ca3f902000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("bc254cf4-0f4a-410c-802f-7c154e7cc0e7"), "im colorblind, ordered wrong flowers", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("28d2711f-9f6c-4dd5-ac89-98f44535f740") });

            migrationBuilder.InsertData(
                table: "UserOrders",
                columns: new[] { "Id", "CreatedOn", "OrderId", "UpdatedOn", "UserId" },
                values: new object[] { new Guid("302df6a9-4a37-44c9-ab1e-29352682cc84"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("8033acd8-c43d-4ce8-98ad-f0b334cb578a"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("28d2711f-9f6c-4dd5-ac89-98f44535f740") });
        }
    }
}
