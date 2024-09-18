using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace onlineEShopping.Migrations
{
    /// <inheritdoc />
    public partial class ProductMigrationModify : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProductQuantity",
                table: "Products",
                newName: "StockQuantity");

            migrationBuilder.AddColumn<string>(
                name: "ProductImage",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductImage",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "StockQuantity",
                table: "Products",
                newName: "ProductQuantity");
        }
    }
}
