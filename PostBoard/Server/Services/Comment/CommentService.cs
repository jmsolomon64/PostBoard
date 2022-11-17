using PostBoard.Server.Data;
using PostBoard.Server.Models;
using PostBoard.Shared.Models.Comment;
using PostBoard.Server.Services.Post;

namespace PostBoard.Server.Services.Comment
{
    public class CommentService : ICommentService
    {
        private readonly ApplicationDbContext _ctx;
        public CommentService(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public bool CreateComment(CommentCreate comment, int postId)
        {
            CommentEntity entity = new CommentEntity()
            {
                Content = comment.Content,
                PostId = postId,
                Post = FindPostById(postId),
                Posted = DateTime.Now,
            };

            _ctx.Comments.Add(entity);
            return _ctx.SaveChanges() > 0;
        }

        public IEnumerable<CommentDetail> GetComments(int postId)
        {
            var comments = _ctx.Comments
                .Select(x => new CommentDetail()
                {
                    Posted = x.Posted,
                    Content = x.Content
                });

            if (comments == null) return null;
            return comments.ToList();
        }

        public bool DeleteComment(int id)
        {
            CommentEntity comment = _ctx.Comments
                .FirstOrDefault(x => x.Id == id);

            if (comment == null) return false;

            _ctx.Comments.Remove(comment);
            return _ctx.SaveChanges() > 0;
        }

        

        private PostEntity FindPostById(int id)
        {
            PostEntity post = _ctx.Posts.FirstOrDefault(x => x.Id == id);
            return post;
        }
    }
}
