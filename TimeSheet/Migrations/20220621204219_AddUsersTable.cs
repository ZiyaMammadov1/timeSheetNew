using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TimeSheet.Migrations
{
    public partial class AddUsersTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    uuid = table.Column<string>(nullable: true),
                    cid = table.Column<string>(nullable: true),
                    fin = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    fullName = table.Column<string>(nullable: true),
                    firstName = table.Column<string>(nullable: true),
                    lastName = table.Column<string>(nullable: true),
                    isDeleted = table.Column<bool>(nullable: false),
                    dateOfBirthday = table.Column<DateTime>(nullable: false),
                    age = table.Column<int>(nullable: false),
                    createdTime = table.Column<DateTime>(nullable: false),
                    positionId = table.Column<int>(nullable: false),
                    departmentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.id);
                    table.ForeignKey(
                        name: "FK_Users_Departments_departmentId",
                        column: x => x.departmentId,
                        principalTable: "Departments",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_Positions_positionId",
                        column: x => x.positionId,
                        principalTable: "Positions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_departmentId",
                table: "Users",
                column: "departmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_positionId",
                table: "Users",
                column: "positionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
