using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiGitHubProgram.Migrations
{
    public partial class Balumigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BaluTables",
                columns: table => new
                {
                    StdId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StdName = table.Column<string>(maxLength: 50, nullable: false),
                    Fee = table.Column<decimal>(nullable: false),
                    DOB = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaluTables", x => x.StdId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BaluTables");
        }
    }
}
