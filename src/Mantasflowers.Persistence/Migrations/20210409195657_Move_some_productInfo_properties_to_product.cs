using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Mantasflowers.Persistence.Migrations
{
    public partial class Move_some_productInfo_properties_to_product : Migration
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
