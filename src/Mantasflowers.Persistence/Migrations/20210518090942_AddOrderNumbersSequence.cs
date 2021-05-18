using Microsoft.EntityFrameworkCore.Migrations;

namespace Mantasflowers.Persistence.Migrations
{
    public partial class AddOrderNumbersSequence : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence(
                name: "OrderNumbers");

            migrationBuilder.AlterColumn<decimal>(
                name: "OrderNumber",
                table: "Orders",
                type: "decimal(20,0)",
                nullable: false,
                defaultValueSql: "NEXT VALUE FOR OrderNumbers",
                oldClrType: typeof(decimal),
                oldType: "decimal(20,0)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropSequence(
                name: "OrderNumbers");

            migrationBuilder.AlterColumn<decimal>(
                name: "OrderNumber",
                table: "Orders",
                type: "decimal(20,0)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(20,0)",
                oldDefaultValueSql: "NEXT VALUE FOR OrderNumbers");
        }
    }
}
