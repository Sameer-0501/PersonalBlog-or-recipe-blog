using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Data;
using Shared.Models;

namespace Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostsController : ControllerBase
    {
        private readonly AppDbContext _db;
        private readonly ILogger<PostsController> _logger;

        public PostsController(AppDbContext db, ILogger<PostsController> logger)
        {
            _db = db;
            _logger = logger;
        }

        // GET: api/posts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Post>>> GetAll()
        {
            var posts = await _db.Posts.OrderByDescending(p => p.PublishedOn).ToListAsync();
            return Ok(posts);
        }

        // GET: api/posts/{id}
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Post>> Get(int id)
        {
            var post = await _db.Posts.FindAsync(id);
            if (post == null) return NotFound();
            return Ok(post);
        }

        // POST: api/posts
        [HttpPost]
        public async Task<ActionResult<Post>> Create([FromBody] Post post)
        {
            post.PublishedOn = DateTime.UtcNow;
            _db.Posts.Add(post);
            await _db.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = post.Id }, post);
        }

        // PUT: api/posts/{id}
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] Post updated)
        {
            if (id != updated.Id) return BadRequest();

            var existing = await _db.Posts.FindAsync(id);
            if (existing == null) return NotFound();

            existing.Title = updated.Title;
            existing.Category = updated.Category;
            existing.Excerpt = updated.Excerpt;
            existing.Content = updated.Content;
            existing.ImageUrl = updated.ImageUrl;
            // keep PublishedOn as-is or update, depending on your rules
            await _db.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/posts/{id}
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existing = await _db.Posts.FindAsync(id);
            if (existing == null) return NotFound();

            _db.Posts.Remove(existing);
            await _db.SaveChangesAsync();
            return NoContent();
        }
    }
}
