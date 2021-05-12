using Microsoft.EntityFrameworkCore.Migrations;

namespace SportsBlogV2.Migrations
{
    public partial class Tagsadd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ETag",
                table: "Posts",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ETag",
                table: "Posts");
        }
    }
}
