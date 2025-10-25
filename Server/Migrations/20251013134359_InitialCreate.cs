using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Server.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Category = table.Column<string>(type: "TEXT", nullable: false),
                    Excerpt = table.Column<string>(type: "TEXT", nullable: false),
                    Content = table.Column<string>(type: "TEXT", nullable: false),
                    ImageUrl = table.Column<string>(type: "TEXT", nullable: true),
                    PublishedOn = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "Category", "Content", "Excerpt", "ImageUrl", "PublishedOn", "Title" },
                values: new object[,]
                {
                    { 1, "Technology", "Long article content about async/await and Task-based programming.", "A short guide to async/await in C# ...", null, new DateTime(2024, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mastering C# Asynchronous Programming" },
                    { 2, "Recipes", "Detailed recipe content, ingredients and steps.", "A little chocolate treat perfect for parties.", null, new DateTime(2024, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Decadent Chocolate Lava Cakes" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Posts");
        }
    }
}
