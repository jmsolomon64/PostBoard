using Microsoft.EntityFrameworkCore;
using PostBoard.Server.Data;
using PostBoard.Server.Models;
using PostBoard.Shared.Models.Comment;
using PostBoard.Shared.Models.Post;
using PostBoard.Server.Services.Category;
using PostBoard.Server.Services.Comment;

namespace PostBoard.Server.Services.Post
{
    public class PostService : IPostService
    {
        private readonly ICategoryServices _category;
        private readonly ApplicationDbContext _ctx;

        public PostService(ApplicationDbContext ctx, ICategoryServices category)
        {
            _ctx = ctx;
            _category = category;

        }

        public bool CreatePost(PostCreate post)
        {
            PostEntity entity = new PostEntity()
            {
                CategoryId = post.CategoryId,
                Category = _category.GetCategoryEntity(post.CategoryId),
                Title = post.Title,
                Content = post.Content,
                Posted = DateTime.Now
            };

            _ctx.Posts.Add(entity);
            return _ctx.SaveChanges() > 0;
        }

        public List<PostListView> ViewAllPosts()
        {
            var posts = _ctx.Posts
                .Include(x => x.Category)
                .Include(x => x.Comments)
                .Select(x => new PostListView()
                {
                    Id = x.Id,
                    Category = x.Category.Name,
                    Posted = x.Posted,
                    Title = x.Title,
                    Comments = x.Comments.Count()
                });

            return posts.ToList();
        }

        public PostDetailView ViewPost(int id)
        {
            List<CommentDetail> comments = new List<CommentDetail>();

            var entity = _ctx.Posts
                .Include(x => x.Comments)
                .Include(x => x.Category)
                .FirstOrDefault(x => x.Id == id);
            if (entity == null) return null;

            foreach(CommentEntity comment in entity.Comments)
            {
                CommentDetail details = new CommentDetail
                {
                    Posted = comment.Posted,
                    Content = comment.Content,
                };
                comments.Add(details);
            }


            PostDetailView post = new PostDetailView
            {
                Id = entity.Id,
                Category = entity.Category.Name,
                Posted = entity.Posted,
                Title = entity.Title,
                Content = entity.Content,
                Comments = comments
            };

            return post;
        }

        public bool DeletePost(int id)
        {
            var entity = _ctx.Posts.FirstOrDefault(x => x.Id == id);
            if (entity == null) return false;

            _ctx.Posts.Remove(entity);
            return _ctx.SaveChanges() > 0;
        }

    }
}
