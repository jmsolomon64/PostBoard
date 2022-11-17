using PostBoard.Server.Models;
using PostBoard.Shared.Models.Post;

namespace PostBoard.Server.Services.Post
{
    public interface IPostService
    {
        bool CreatePost(PostCreate post);
        bool DeletePost(int id);
        List<PostListView> ViewAllPosts();
        PostDetailView ViewPost(int id);
    }
}