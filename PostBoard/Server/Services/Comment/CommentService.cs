using Microsoft.EntityFrameworkCore;
using PostBoard.Shared.Models.Comment;
using PostBoard.Server.Data;
using PostBoard.Server.Models;

namespace PostBoard.Server.Services.Comment
{
    public class CommentService : ICommentService
    {
        private readonly ApplicationDbContext _context;
        private string _userId;

        public CommentService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void SetUserId(string userId) => _userId = userId;

        public async Task<bool> CreateCommentAsync(CommentCreate model)
        {
            var entity = new CommentEntity()
            {
                PostId = model.PostId,
                OwnerId = _userId,
                Posted = DateTime.Now,
                Content = model.Content
            };

            _context.Comments.Add(entity);
            return await _context.SaveChangesAsync() == 1;
        }

        public async Task<bool> DeleteCommentAsync(int id)
        {
            var entity = await _context.Comments.FirstOrDefaultAsync(x => x.Id == id);

            if (entity?.OwnerId != _userId) return false;

            _context.Comments.Remove(entity);
            return await _context.SaveChangesAsync() == 1;
        }

        public async Task<List<CommentDetail>> GetAllCommentsAsync(int postId)
        {
            var commentQuery = _context.Comments
                .Where(x => x.PostId == postId)
                .Select(x => new CommentDetail()
                {
                    Id = x.Id,
                    Posted = x.Posted,
                    Modified = x.Modified,
                    Content = x.Content
                });

            if (commentQuery == null) return null;
            return await commentQuery.ToListAsync();
        }

        public async Task<CommentDetail> GetCommentByIdAsync(int id)
        {
            var entity = await _context.Comments.FirstOrDefaultAsync(x => x.Id == id);

            if (entity == null) return null;

            return new CommentDetail()
            {
                Id = entity.Id,
                Posted = entity.Posted,
                Modified = entity.Modified,
                Content = entity.Content
            };
        }

        public async Task<bool> UpdateCommentAsync(CommentEdit model)
        {
            var entity = await _context.Comments.FirstOrDefaultAsync(x => x.Id == model.Id);

            if(entity?.OwnerId != _userId) return false;

            entity.Content = model.Content;

            return await _context.SaveChangesAsync() == 1;
        }
    }
}
