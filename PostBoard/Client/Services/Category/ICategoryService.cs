using PostBoard.Shared.Models.Category;

namespace PostBoard.Client.Services.Category
{
    public interface ICategoryService
    {
        Task<bool> CreateCategoryAsync(CategoryCreate model);
        Task<bool> DeleteCategoryByIdAsync(int id);
        Task<IEnumerable<CategoryListItem>> GetAllCategoriesAsync();
        Task<CategoryView> GetCategoryByIdAsync(int id);
        Task<bool> UpdateCategoryByIdAsync(int id, CategoryCreate model);
    }
}