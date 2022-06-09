using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class ChangeUseCaseLog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Date",
                table: "UseCaseLogs",
                newName: "CreatedAt");

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "UseCaseLogs",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "UseCaseLogs",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "UseCaseLogs");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "UseCaseLogs");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "UseCaseLogs",
                newName: "Date");
        }
    }
}
