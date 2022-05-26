using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class FixLanguageNameTypo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Languague_LanguagueId",
                table: "Books");

            migrationBuilder.DropTable(
                name: "Languague");

            migrationBuilder.RenameColumn(
                name: "LanguagueId",
                table: "Books",
                newName: "LanguageId");

            migrationBuilder.RenameIndex(
                name: "IX_Books_LanguagueId",
                table: "Books",
                newName: "IX_Books_LanguageId");

            migrationBuilder.CreateTable(
                name: "Language",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Language", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Language_Name",
                table: "Language",
                column: "Name",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Language_LanguageId",
                table: "Books",
                column: "LanguageId",
                principalTable: "Language",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Language_LanguageId",
                table: "Books");

            migrationBuilder.DropTable(
                name: "Language");

            migrationBuilder.RenameColumn(
                name: "LanguageId",
                table: "Books",
                newName: "LanguagueId");

            migrationBuilder.RenameIndex(
                name: "IX_Books_LanguageId",
                table: "Books",
                newName: "IX_Books_LanguagueId");

            migrationBuilder.CreateTable(
                name: "Languague",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languague", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Languague_LanguagueId",
                table: "Books",
                column: "LanguagueId",
                principalTable: "Languague",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
