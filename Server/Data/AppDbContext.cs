using Microsoft.EntityFrameworkCore;
using Shared.Models;

namespace Server.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Post> Posts { get; set; } = null!;

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed example posts with static values
            modelBuilder.Entity<Post>().HasData(
                new Post
                {
                    Id = 1,
                    Title = "Mastering C# Asynchronous Programming",
                    Category = "Technology",
                    Excerpt = "A short guide to async/await in C# ...",
                    Content = "Long article content about async/await and Task-based programming.",
                    ImageUrl = null,
                    PublishedOn = new DateTime(2024, 03, 10)
                },
                new Post
                {
                    Id = 2,
                    Title = "Decadent Chocolate Lava Cakes",
                    Category = "Recipes",
                    Excerpt = "A little chocolate treat perfect for parties.",
                    Content = "Detailed recipe content, ingredients and steps.",
                    ImageUrl = null,
                    PublishedOn = new DateTime(2024, 03, 15)
                }
            );
        }
    }
}
