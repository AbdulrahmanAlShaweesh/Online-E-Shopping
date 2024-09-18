using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace onlineEShopping.Migrations
{
    /// <inheritdoc />
    public partial class FixUserRoleRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Roles_RolesRoleId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_RolesRoleId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "RolesRoleId",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "password",
                table: "Users",
                newName: "Password");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Roles_RoleId",
                table: "Users",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "RoleId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Roles_RoleId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_RoleId",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Users",
                newName: "password");

            migrationBuilder.AddColumn<int>(
                name: "RolesRoleId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_RolesRoleId",
                table: "Users",
                column: "RolesRoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Roles_RolesRoleId",
                table: "Users",
                column: "RolesRoleId",
                principalTable: "Roles",
                principalColumn: "RoleId");
        }
    }
}
