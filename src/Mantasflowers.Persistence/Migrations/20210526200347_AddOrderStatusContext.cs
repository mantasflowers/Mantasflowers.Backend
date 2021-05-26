using Microsoft.EntityFrameworkCore.Migrations;

namespace Mantasflowers.Persistence.Migrations
{
    public partial class AddOrderStatusContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OrderStatusContext",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderStatusContext",
                table: "Orders");
        }
    }
}
