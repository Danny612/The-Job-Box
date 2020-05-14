using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace The_Job_Box.Migrations
{
    public partial class UpdateJobsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_Category_CategoryId",
                table: "Jobs");

            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_JobLocation_LocationId",
                table: "Jobs");

            migrationBuilder.DropIndex(
                name: "IX_Jobs_CategoryId",
                table: "Jobs");

            migrationBuilder.DropIndex(
                name: "IX_Jobs_LocationId",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "Job_ID",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "Jobs");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Jobs",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "CompanyName",
                table: "Jobs",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "JobLocation",
                table: "Jobs",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Telephone",
                table: "Jobs",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_JobCategoryId",
                table: "Jobs",
                column: "JobCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_JobLocation",
                table: "Jobs",
                column: "JobLocation");

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_Category_JobCategoryId",
                table: "Jobs",
                column: "JobCategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_JobLocation_JobLocation",
                table: "Jobs",
                column: "JobLocation",
                principalTable: "JobLocation",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_Category_JobCategoryId",
                table: "Jobs");

            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_JobLocation_JobLocation",
                table: "Jobs");

            migrationBuilder.DropIndex(
                name: "IX_Jobs_JobCategoryId",
                table: "Jobs");

            migrationBuilder.DropIndex(
                name: "IX_Jobs_JobLocation",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "CompanyName",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "JobLocation",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "Telephone",
                table: "Jobs");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Jobs",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Jobs",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "Job_ID",
                table: "Jobs",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "LocationId",
                table: "Jobs",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_CategoryId",
                table: "Jobs",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_LocationId",
                table: "Jobs",
                column: "LocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_Category_CategoryId",
                table: "Jobs",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_JobLocation_LocationId",
                table: "Jobs",
                column: "LocationId",
                principalTable: "JobLocation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
