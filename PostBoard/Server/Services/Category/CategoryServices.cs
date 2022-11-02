using Microsoft.EntityFrameworkCore;
using PostBoard.Server.Data;
using PostBoard.Server.Models.Category;
using PostBoard.Server.Models.Post;

namespace PostBoard.Server.Services.Category
{
    public class CategoryServices
    {
        private readonly ApplicationDbContext _ctx;

        public CategoryServices(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public IEnumerable<CategoryListItem> GetCategories()
        {
            var query = _ctx.Categories
                .Include(x => x.Posts) //Includes virtual lists in query
                .Select(x => new CategoryListItem //Select will loop through entire table
                {
                    Id = x.Id,
                    Name = x.Name,
                    Posts = x.Posts.Count()
                });

            return query.ToList();
        }

        public CategoryView GetCategory(int id)
        {
            List<PostListView> categoryPosts = new List<PostListView>();

            var entity = _ctx.Categories
                .Include(x => x.Posts)
                .FirstOrDefault(x => x.Id == id);

            if (entity == null) return null;

            foreach(var post in entity.Posts)
            {
                PostListView item = new PostListView
                {
                    Category = GetCategoryName(post.CategoryId),
                    Posted = post.Posted,
                    Title = post.Title,
                    //need to add injection to comment service to pull amount of comments
                };
            }
            CategoryView category = new CategoryView
            {
                Name = entity.Name,
                Description = entity.Description
            };



            return category;
        }

        private string GetCategoryName(int id)
        {
            string name = _ctx.Categories.FirstOrDefault(x => x.Id == id).Name;

            if (name == null) return null;

            return name;
        }
    }
}
