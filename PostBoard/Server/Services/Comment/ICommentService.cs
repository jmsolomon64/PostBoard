using PostBoard.Client.Shared.Comment;

namespace PostBoard.Server.Services.Comment
{
    public interface ICommentService
    {
        Task<bool> CreateCommentAsync(CommentCreate model);
        Task<ICollection<CommentDetail>> GetAllCommentsAsync(int postId);
        Task<bool> UpdateCommentAsync(CommentEdit model);
        Task<bool> DeleteCommentAsync(int id);
        void SetUserId(string userId);
    }
}
