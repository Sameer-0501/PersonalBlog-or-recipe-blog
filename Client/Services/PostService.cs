using System.Net.Http.Json;
using Client.Models;
using Shared.Models;

namespace Client.Services
{
    public class PostService
    {
        private readonly HttpClient _http;

        public PostService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<Post>> GetAllAsync()
        {
            var posts = await _http.GetFromJsonAsync<List<Post>>("api/posts");
            return posts ?? new List<Post>();
        }

        public async Task<Post?> GetByIdAsync(int id)
        {
            return await _http.GetFromJsonAsync<Post>($"api/posts/{id}");
        }

        public async Task<Post?> CreateAsync(Post post)
        {
            var resp = await _http.PostAsJsonAsync("api/posts", post);
            if (!resp.IsSuccessStatusCode) return null;
            var created = await resp.Content.ReadFromJsonAsync<Post>();
            return created;
        }

        public async Task<bool> UpdateAsync(Post post)
        {
            var resp = await _http.PutAsJsonAsync($"api/posts/{post.Id}", post);
            return resp.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var resp = await _http.DeleteAsync($"api/posts/{id}");
            return resp.IsSuccessStatusCode;
        }
    }
}
