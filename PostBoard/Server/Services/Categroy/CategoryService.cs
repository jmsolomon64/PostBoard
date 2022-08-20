using Microsoft.EntityFrameworkCore;
using PostBoard.Client.Shared.Category;
using PostBoard.Server.Data;
using PostBoard.Server.Models;

namespace PostBoard.Server.Services.Categroy
{
    public class CategoryService : ICategoryService
    {
        private readonly ApplicationDbContext _context;

        public CategoryService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateCategoryAsync(CategoryCreate model)
        {
            var entity = new CategoryEntity
            {
                Name = model.Name,
                Description = model.Description
            };

            _context.Categories.Add(entity);
            return await _context.SaveChangesAsync() == 1;
        }

        public async Task<bool> DeleteCategoryAsync(int categoryId)
        {
            var entity = await _context.Categories.FirstOrDefaultAsync(c => c.Id == categoryId);

            if(entity == null) return false;

            _context.Categories.Remove(entity);
            return await _context.SaveChangesAsync() == 1;
        }

        public async Task<IEnumerable<CategoryListItem>> GetAllCategoriesAsync()
        {
            var categoryQuery = _context.Categories
                .Select(x => new CategoryListItem()
                {
                    Id = x.Id,
                    Name = x.Name
                });

            return await categoryQuery.ToListAsync();
        }

        public async Task<CategoryEntity> GetCategoryEntityAsync(int categoryId)
        {
            var entity = await _context.Categories.FirstOrDefaultAsync(x => x.Id == categoryId);

            if (entity == null) return null;
            return entity;
        }

        public async Task<CategoryDetail> GetCategoryByIdAsync(int categoryId)
        {
            var entity = await _context.Categories.FirstOrDefaultAsync(x => x.Id == categoryId);

            if (entity == null) return null;

            var category = new CategoryDetail()
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description
            };

            return category;
        }

        public async Task<bool> UpdateCategoryAsync(CategoryEdit model)
        {
            var entity = await _context.Categories.FirstOrDefaultAsync(x => x.Id == model.Id);

            if(entity == null) return false;

            entity.Name = model.Name;
            entity.Description = model.Description;

            return await _context.SaveChangesAsync() == 1;
        }
    }
}
