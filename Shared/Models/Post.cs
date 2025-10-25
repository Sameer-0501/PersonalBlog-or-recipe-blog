namespace Shared.Models
{
    public class Post
    {
        public int Id { get; set; }

        // Title of the post or recipe
        public string Title { get; set; } = string.Empty;

        // Short category tag (e.g., "Recipes", "Technology")
        public string Category { get; set; } = string.Empty;

        // Short excerpt / description
        public string Excerpt { get; set; } = string.Empty;

        // Full content
        public string Content { get; set; } = string.Empty;

        // optional image url - for demo we can store a relative path or base64
        public string? ImageUrl { get; set; }

        // Created date
        public DateTime PublishedOn { get; set; } = DateTime.UtcNow;
    }
}
