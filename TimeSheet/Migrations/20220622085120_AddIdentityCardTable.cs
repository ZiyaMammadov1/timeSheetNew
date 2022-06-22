using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TimeSheet.Migrations
{
    public partial class AddIdentityCardTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IdentityCards",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    uuid = table.Column<string>(nullable: true),
                    fin = table.Column<string>(nullable: true),
                    status = table.Column<bool>(nullable: false),
                    series = table.Column<string>(nullable: true),
                    deliveryTime = table.Column<DateTime>(nullable: false),
                    expiredTime = table.Column<DateTime>(nullable: false),
                    govermentName = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityCards", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IdentityCards");
        }
    }
}
