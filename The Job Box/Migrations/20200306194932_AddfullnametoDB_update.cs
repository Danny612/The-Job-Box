using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace The_Job_Box.Migrations
{
    public partial class AddfullnametoDB_update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Jobs",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Job_ID = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Category = table.Column<string>(nullable: false),
                    Location = table.Column<string>(nullable: false),
                    Salary = table.Column<double>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    Summary = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jobs", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Jobs");
        }
    }
}
