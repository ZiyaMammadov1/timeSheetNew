using Microsoft.EntityFrameworkCore.Migrations;

namespace TimeSheet.Migrations
{
    public partial class UpdateUserTableForPhotoColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "imageUrl",
                table: "Users");

            migrationBuilder.AddColumn<string>(
                name: "photo",
                table: "Users",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "photo",
                table: "Users");

            migrationBuilder.AddColumn<string>(
                name: "imageUrl",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
