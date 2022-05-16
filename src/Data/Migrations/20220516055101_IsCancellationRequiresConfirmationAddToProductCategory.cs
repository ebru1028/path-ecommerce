using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class IsCancellationRequiresConfirmationAddToProductCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsCancellationRequiresConfirmation",
                table: "ProductCategories",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsCancellationRequiresConfirmation",
                table: "ProductCategories");
        }
    }
}
