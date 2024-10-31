using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LikeButtonProject.Migrations
{
    public partial class AddNewArticles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "ArticleId", "Content", "CreationDate", "Title" },
                values: new object[] { 2, "This is another sample article for demonstration purposes.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Another Sample Article" });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "ArticleId", "Content", "CreationDate", "Title" },
                values: new object[] { 3, "This is yet another sample article for demonstration purposes.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Yet Another Sample Article" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "ArticleId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "ArticleId",
                keyValue: 3);
        }
    }
}
