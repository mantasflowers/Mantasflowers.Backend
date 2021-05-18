using Microsoft.EntityFrameworkCore.Migrations;

namespace Mantasflowers.Persistence.Migrations
{
    public partial class MakeOrderPasswordPermanent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TemporaryPasswordHash",
                table: "Orders");

            migrationBuilder.AddColumn<string>(
                name: "UniquePassword",
                table: "Orders",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UniquePassword",
                table: "Orders");

            migrationBuilder.AddColumn<string>(
                name: "TemporaryPasswordHash",
                table: "Orders",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: false,
                defaultValue: "");
        }
    }
}
