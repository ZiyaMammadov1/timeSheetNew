using Microsoft.EntityFrameworkCore.Migrations;

namespace TimeSheet.Migrations
{
    public partial class AddUserIdToIdentityCard : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "userId",
                table: "IdentityCards",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_IdentityCards_userId",
                table: "IdentityCards",
                column: "userId");

            migrationBuilder.AddForeignKey(
                name: "FK_IdentityCards_Users_userId",
                table: "IdentityCards",
                column: "userId",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IdentityCards_Users_userId",
                table: "IdentityCards");

            migrationBuilder.DropIndex(
                name: "IX_IdentityCards_userId",
                table: "IdentityCards");

            migrationBuilder.DropColumn(
                name: "userId",
                table: "IdentityCards");
        }
    }
}
