using PostBoard.Shared.Models.Post;
using System.Net.Http.Json;

namespace PostBoard.Client.Services.Post
{
    public class PostService : IPostService
    {
        private readonly HttpClient _client;
        public PostService(HttpClient client)
        {
            _client = client;
        }

        public async Task<IEnumerable<PostListView>> GetAllPostsAsync()
        {
            var posts = await _client.GetFromJsonAsync<List<PostListView>>("api/post/view/all");
            return posts;
        }

        public async Task<PostDetailView> GetPostById(int id)
        {
            var post = await _client.GetFromJsonAsync<PostDetailView>($"api/post/view/{id}");
            return post;
        }

        public async Task<bool> CreatePost(PostCreate model)
        {
            if (model == null) return false;

            var results = await _client.PostAsJsonAsync<PostCreate>("api/post/create", model);
            if(results.IsSuccessStatusCode) return true;

            return false;
        }
    }
}
