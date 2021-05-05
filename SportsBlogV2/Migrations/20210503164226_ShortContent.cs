using Microsoft.EntityFrameworkCore.Migrations;

namespace SportsBlogV2.Migrations
{
    public partial class ShortContent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ShortContent",
                table: "Posts",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShortContent",
                table: "Posts");
        }
    }
}
