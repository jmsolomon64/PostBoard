using PostBoard.Shared.Models.Post;

namespace PostBoard.Client.Services.Post
{
    public interface IPostService
    {
        Task<IEnumerable<PostListView>> GetAllPostsAsync();
        Task<PostDetailView> GetPostById(int id);
        Task<bool> CreatePost(PostCreate model);
    }
}