using Microsoft.EntityFrameworkCore;
using Shared.Models;

namespace Server.Data
{
    // optional helper to seed at runtime
    public static class DummyDataLoader
    {
        public static async Task EnsureSeedDataAsync(AppDbContext db)
        {
            await db.Database.MigrateAsync();

            // Seed the welcome post if it doesn't exist (id 1)
            if (!await db.Posts.AnyAsync(p => p.Id == 1))
            {
                db.Posts.Add(new Post
                {
                    Id = 1,
                    Title = "Welcome to Personal Blog",
                    Category = "General",
                    Excerpt = "This is your first post. Edit or delete it.",
                    Content = "This sample project demonstrates Blazor + ASP.NET Core + SQLite.",
                    PublishedOn = new DateTime(2024, 03, 10)
                });

                await db.SaveChangesAsync();
            }
        }
    }
}
