using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Heroes.Migrations
{
    /// <inheritdoc />
    public partial class updatedb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Heroes_AspNetUsers_GuideId",
                table: "Heroes");

            migrationBuilder.RenameColumn(
                name: "GuideId",
                table: "Heroes",
                newName: "guideId");

            migrationBuilder.RenameIndex(
                name: "IX_Heroes_GuideId",
                table: "Heroes",
                newName: "IX_Heroes_guideId");

            migrationBuilder.AddForeignKey(
                name: "FK_Heroes_AspNetUsers_guideId",
                table: "Heroes",
                column: "guideId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Heroes_AspNetUsers_guideId",
                table: "Heroes");

            migrationBuilder.RenameColumn(
                name: "guideId",
                table: "Heroes",
                newName: "GuideId");

            migrationBuilder.RenameIndex(
                name: "IX_Heroes_guideId",
                table: "Heroes",
                newName: "IX_Heroes_GuideId");

            migrationBuilder.AddForeignKey(
                name: "FK_Heroes_AspNetUsers_GuideId",
                table: "Heroes",
                column: "GuideId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
