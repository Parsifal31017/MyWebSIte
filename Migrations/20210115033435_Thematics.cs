using Microsoft.EntityFrameworkCore.Migrations;

namespace MyWebSite.Migrations
{
    public partial class Thematics : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tags",
                table: "UserAssignment");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "UserAssignment");

            migrationBuilder.AddColumn<string>(
                name: "Thematics",
                table: "Company",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Thematics",
                table: "Company");

            migrationBuilder.AddColumn<string>(
                name: "Tags",
                table: "UserAssignment",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "UserAssignment",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
