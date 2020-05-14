using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace The_Job_Box.Migrations
{
    public partial class AddBLogPostToDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BlogpostsID",
                table: "SubCategory",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Blogposts",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: false),
                    Content = table.Column<string>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    ImageUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blogposts", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SubCategory_BlogpostsID",
                table: "SubCategory",
                column: "BlogpostsID");

            migrationBuilder.AddForeignKey(
                name: "FK_SubCategory_Blogposts_BlogpostsID",
                table: "SubCategory",
                column: "BlogpostsID",
                principalTable: "Blogposts",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubCategory_Blogposts_BlogpostsID",
                table: "SubCategory");

            migrationBuilder.DropTable(
                name: "Blogposts");

            migrationBuilder.DropIndex(
                name: "IX_SubCategory_BlogpostsID",
                table: "SubCategory");

            migrationBuilder.DropColumn(
                name: "BlogpostsID",
                table: "SubCategory");
        }
    }
}
