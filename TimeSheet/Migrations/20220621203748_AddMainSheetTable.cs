using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TimeSheet.Migrations
{
    public partial class AddMainSheetTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MainTimeSheets",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    uuid = table.Column<string>(nullable: true),
                    projectid = table.Column<string>(nullable: true),
                    workTypeid = table.Column<string>(nullable: true),
                    startDate = table.Column<DateTime>(nullable: true),
                    createdTime = table.Column<DateTime>(nullable: false),
                    hours = table.Column<decimal>(nullable: true),
                    description = table.Column<string>(nullable: true),
                    isDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MainTimeSheets", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MainTimeSheets");
        }
    }
}
