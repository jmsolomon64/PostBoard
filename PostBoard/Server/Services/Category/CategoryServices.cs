using Microsoft.EntityFrameworkCore;
using PostBoard.Server.Data;
using PostBoard.Server.Models;
using PostBoard.Shared.Models.Category;
using PostBoard.Shared.Models.Post;

namespace PostBoard.Server.Services.Category
{
    public class CategoryServices : ICategoryServices
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

            //Find Specific category, include the Posts
            var entity = _ctx.Categories
                .Include(x => x.Posts)
                .FirstOrDefault(x => x.Id == id);

            //Makes sure query returned something
            if (entity == null) return null;

            //Loops through posts in Entity and creates them into PostListItems
            foreach (var post in entity.Posts)
            {
                PostListView item = new PostListView
                {
                    Category = GetCategoryName(post.CategoryId),
                    Posted = post.Posted,
                    Title = post.Title,
                    //need to add injection to comment service to pull amount of comments
                };
                categoryPosts.Add(item);
            }

            //CategoryView with posts appended
            CategoryView category = new CategoryView
            {
                Name = entity.Name,
                Description = entity.Description,
                Posts = categoryPosts
            };

            return category;
        }

        public bool AddCategory(CategoryCreate category)
        {
            var entity = new CategoryEntity()
            {
                Name = category.Name,
                Description = category.Description
            };

            _ctx.Categories.Add(entity);
            return _ctx.SaveChanges() > 0;
        }

        public bool UpdateCategory(CategoryCreate category, int id)
        {
            var entity = _ctx.Categories.FirstOrDefault(x => x.Id == id);
            if (entity == null) return false;

            entity.Name = category.Name;
            entity.Description = category.Description;

            return _ctx.SaveChanges() > 0;
        }

        public bool DeleteCategory(int id)
        {
            var entity = _ctx.Categories.FirstOrDefault(x => x.Id == id);

            if (entity == null) return false;

            _ctx.Categories.Remove(entity);
            return _ctx.SaveChanges() > 0;
        }

        public string GetCategoryName(int id)
        {
            string name = _ctx.Categories.FirstOrDefault(x => x.Id == id).Name;

            if (name == null) return null;

            return name;
        }

        public CategoryEntity GetCategoryEntity(int id)
        {
            var entity = _ctx.Categories.FirstOrDefault(x => x.Id == id);

            if (entity == null) return null;
            return entity;
        }
    }
}
