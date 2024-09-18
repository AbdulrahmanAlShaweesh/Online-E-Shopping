using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace onlineEShopping.Migrations
{
    /// <inheritdoc />
    public partial class SubCateoryMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubCategoryModel_Categories_CategoryId",
                table: "SubCategoryModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SubCategoryModel",
                table: "SubCategoryModel");

            migrationBuilder.RenameTable(
                name: "SubCategoryModel",
                newName: "SubCategories");

            migrationBuilder.RenameIndex(
                name: "IX_SubCategoryModel_CategoryId",
                table: "SubCategories",
                newName: "IX_SubCategories_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubCategories",
                table: "SubCategories",
                column: "SubCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_SubCategories_Categories_CategoryId",
                table: "SubCategories",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubCategories_Categories_CategoryId",
                table: "SubCategories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SubCategories",
                table: "SubCategories");

            migrationBuilder.RenameTable(
                name: "SubCategories",
                newName: "SubCategoryModel");

            migrationBuilder.RenameIndex(
                name: "IX_SubCategories_CategoryId",
                table: "SubCategoryModel",
                newName: "IX_SubCategoryModel_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubCategoryModel",
                table: "SubCategoryModel",
                column: "SubCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_SubCategoryModel_Categories_CategoryId",
                table: "SubCategoryModel",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
