using PostBoard.Client.Shared.Category;

namespace PostBoard.Server.Services.Categroy
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryListItem>> GetAllCategoriesAsync();
        Task<bool> CreateCategoryAsync(CategoryCreate model);
        Task<CategoryDetail> GetCategoryByIdAsync(int categoryId);
        Task<bool> UpdateCategoryAsync(CategoryEdit model);
        Task<bool> DeleteCategoryAsync(int categoryId);
    }
}
