using Microsoft.EntityFrameworkCore;
using PostBoard.Client.Shared.Category;
using PostBoard.Client.Shared.Comment;
using PostBoard.Client.Shared.Post;
using PostBoard.Server.Data;
using PostBoard.Server.Models;
using PostBoard.Server.Services.Categroy;

namespace PostBoard.Server.Services.Post
{
    public class PostService : IPostService
    {
        private readonly ApplicationDbContext _context;
        private readonly ICategoryService _category;
        private string _userId;

        public PostService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void SetUserId(string userId) => _userId = userId;

        public async Task<bool> CreatePostAsync(PostCreate model)
        {
            var entity = new PostEntity()
            {
                CategoryId = model.CategoryId,
                Category = await _category.GetCategoryEntityAsync(model.CategoryId),
                OwnerId = _userId,
                Posted = DateTime.Now,
                Title = model.Title,
                Content = model.Content,
            };

            _context.Posts.Add(entity);
            return await _context.SaveChangesAsync() == 1;
        }

        public async Task<bool> DeletePostAsync(int postId)
        {
            var entity = await _context.Posts.FirstOrDefaultAsync(x => x.Id == postId);

            if (entity?.OwnerId != _userId) return false;

            _context.Posts.Remove(entity);
            return await _context.SaveChangesAsync() == 1;
        }

        public Task<bool> DeletePostAsync(string userId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<PostListItem>> GetAllUserPostsAsync()
        {
            var postQuery = _context.Posts
                .Where(x => x.OwnerId == _userId)
                .Select(x => //chains all items that fit Where criteria to PostListItem
                new PostListItem()
                {
                    Id = x.Id,
                    CategoryName = x.Category.Name,
                    Title = x.Title,
                    Posted = x.Posted,
                    Modified = x.Modified
                });

            return await postQuery.ToListAsync();
        }

        public async Task<IEnumerable<PostListItem>> GetAllPostsAsync()
        {
            var postQuery = _context.Posts
                .Select(x =>
                new PostListItem()
                {
                    Id = x.Id,
                    CategoryName = x.Category.Name,
                    Title = x.Title,
                    Posted = x.Posted,
                    Modified = x.Modified
                });

            return await postQuery.ToListAsync();
        }

        public async Task<IEnumerable<PostListItem>> GetPostsByCategoryAsync(int categoryId)
        {
            var postQuery = _context.Posts
                .Where(x => x.CategoryId == categoryId)
                .Select(x => new PostListItem()
                {
                    Id = x.Id,
                    CategoryName = x.Category.Name,
                    Title = x.Title,
                    Posted = x.Posted,
                    Modified = x.Modified
                });

            return await postQuery.ToListAsync();
        }

        public async Task<PostDetail> GetPostByIdAsync(int postId)
        {
            var entity = await _context.Posts
                .Include(x => x.Comments)
                .FirstOrDefaultAsync(x => x.Id == postId);

            if(entity == null) return null;

            return new PostDetail()
            {
                Category = new CategoryListItem()
                {
                    Id = entity.Id,
                    Name = entity.Category.Name,
                },
                Posted = entity.Posted,
                Modified = entity.Modified,
                Title = entity.Title,
                Content = entity.Content,
                Comments = (List<CommentDetail>)entity.Comments
            };
        }


        public async Task<bool> UpdatePostAsync(PostEdit model)
        {
            if (model == null) return false;

            var entity = await _context.Posts.FirstOrDefaultAsync(x => x.Id == model.Id);

            //Checks to see if User owns the post
            if (entity?.OwnerId != _userId) return false;

            entity.Title = model.Title;
            entity.CategoryId = model.CategoryId;
            entity.Category = await _category.GetCategoryEntityAsync(model.CategoryId);
            entity.Title = model.Title;
            entity.Content = model.Content;
            entity.Modified = DateTime.Now;

            return await _context.SaveChangesAsync() == 1;
        }
    }
}
