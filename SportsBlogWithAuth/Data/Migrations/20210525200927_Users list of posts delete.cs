using Microsoft.EntityFrameworkCore.Migrations;

namespace SportsBlogWithAuth.Data.Migrations
{
    public partial class Userslistofpostsdelete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_AspNetUsers_AppUserId",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_AppUserId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Posts");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "Posts",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Posts_AppUserId",
                table: "Posts",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_AspNetUsers_AppUserId",
                table: "Posts",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
