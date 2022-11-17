using PostBoard.Server.Models;
using PostBoard.Shared.Models.Category;

namespace PostBoard.Server.Services.Category
{
    public interface ICategoryServices
    {
        bool AddCategory(CategoryCreate category);
        bool DeleteCategory(int id);
        IEnumerable<CategoryListItem> GetCategories();
        CategoryView GetCategory(int id);
        bool UpdateCategory(CategoryCreate category, int id);
        string GetCategoryName(int id);
        CategoryEntity GetCategoryEntity(int id);
    }
}