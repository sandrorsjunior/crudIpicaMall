using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CrudIpcaMall.Migrations
{
    /// <inheritdoc />
    public partial class createRelationShipUserEncrypt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_encryptions_users_UsersModelId",
                table: "encryptions");

            migrationBuilder.DropIndex(
                name: "IX_encryptions_UsersModelId",
                table: "encryptions");

            migrationBuilder.DropColumn(
                name: "UsersModelId",
                table: "encryptions");

            migrationBuilder.CreateIndex(
                name: "IX_encryptions_UserId",
                table: "encryptions",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_encryptions_users_UserId",
                table: "encryptions",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_encryptions_users_UserId",
                table: "encryptions");

            migrationBuilder.DropIndex(
                name: "IX_encryptions_UserId",
                table: "encryptions");

            migrationBuilder.AddColumn<int>(
                name: "UsersModelId",
                table: "encryptions",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_encryptions_UsersModelId",
                table: "encryptions",
                column: "UsersModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_encryptions_users_UsersModelId",
                table: "encryptions",
                column: "UsersModelId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
