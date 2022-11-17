using PostBoard.Shared.Models.Comment;

namespace PostBoard.Client.Services.Comment
{
    public interface ICommentService
    {
        Task<bool> CreateACommentAsync(int postId, CommentCreate model);
        Task<bool> DeleteCommentByIdAsync(int id);
        Task<List<CommentDetail>> ViewCommentsByPostIdAsync(int postId);
    }
}