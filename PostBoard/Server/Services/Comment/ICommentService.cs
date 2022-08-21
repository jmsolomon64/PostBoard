using PostBoard.Shared.Models.Comment;

namespace PostBoard.Server.Services.Comment
{
    public interface ICommentService
    {
        Task<bool> CreateCommentAsync(CommentCreate model);
        Task<List<CommentDetail>> GetAllCommentsAsync(int postId);
        Task<CommentDetail> GetCommentByIdAsync(int id);
        Task<bool> UpdateCommentAsync(CommentEdit model);
        Task<bool> DeleteCommentAsync(int id);
        void SetUserId(string userId);
    }
}
