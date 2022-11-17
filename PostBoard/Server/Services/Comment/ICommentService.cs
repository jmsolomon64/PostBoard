using PostBoard.Shared.Models;
using PostBoard.Shared.Models.Comment;

namespace PostBoard.Server.Services.Comment
{
    public interface ICommentService
    {
        bool CreateComment(CommentCreate comment, int postId);
        bool DeleteComment(int id);
        IEnumerable<CommentDetail> GetComments(int postId);
    }
}