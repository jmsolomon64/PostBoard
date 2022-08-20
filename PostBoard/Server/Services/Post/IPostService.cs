using PostBoard.Client.Shared.Post;

namespace PostBoard.Server.Services.Post
{
    public interface IPostService
    {
        Task<IEnumerable<PostListItem>> GetAllUserPostsAsync();
        Task<IEnumerable<PostListItem>> GetAllPostsAsync();
        Task<IEnumerable<PostListItem>> GetPostsByCategoryAsync(int categoryId);
        Task<bool> CreatePostAsync(PostCreate model);
        Task<PostDetail> GetPostByIdAsync(int postId);
        Task<bool> UpdatePostAsync(PostEdit model);
        Task<bool> DeletePostAsync(int postId);
        Task<bool> DeletePostAsync(string userId);
        void SetUserId(string userID);
    }
}
