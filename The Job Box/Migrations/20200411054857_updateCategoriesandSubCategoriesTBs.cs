using Microsoft.EntityFrameworkCore.Migrations;

namespace The_Job_Box.Migrations
{
    public partial class updateCategoriesandSubCategoriesTBs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CartegoryName",
                table: "Category");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Category",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Category");

            migrationBuilder.AddColumn<string>(
                name: "CartegoryName",
                table: "Category",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
