using PostBoard.Shared.Models.Comment;
using System.Net.Http.Json;

namespace PostBoard.Client.Services.Comment
{
    public class CommentService : ICommentService
    {
        private HttpClient _client;
        public CommentService(HttpClient client)
        {
            _client = client;
        }

        public async Task<List<CommentDetail>> ViewCommentsByPostIdAsync(int postId)
        {
            var comments = await _client.GetFromJsonAsync<List<CommentDetail>>($"/api/comment/view/{postId}");
            return comments;
        }

        public async Task<bool> CreateACommentAsync(int postId, CommentCreate model)
        {
            var result = await _client.PostAsJsonAsync<CommentCreate>($"/api/comment/add/{postId}", model);
            if (result.IsSuccessStatusCode) return true;
            return false;
        }

        public async Task<bool> DeleteCommentByIdAsync(int id)
        {
            var result = await _client.DeleteAsync($"/api/comment/delete/{id}");
            if (result.IsSuccessStatusCode) return true;
            return false;
        }
    }
}
