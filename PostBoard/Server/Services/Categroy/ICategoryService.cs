using PostBoard.Shared.Models.Category;
using PostBoard.Server.Models;

namespace PostBoard.Server.Services.Categroy
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryListItem>> GetAllCategoriesAsync();
        Task<CategoryEntity> GetCategoryEntityAsync(int id);
        Task<bool> CreateCategoryAsync(CategoryCreate model);
        Task<CategoryDetail> GetCategoryByIdAsync(int categoryId);
        Task<bool> UpdateCategoryAsync(CategoryEdit model);
        Task<bool> DeleteCategoryAsync(int categoryId);
    }
}
