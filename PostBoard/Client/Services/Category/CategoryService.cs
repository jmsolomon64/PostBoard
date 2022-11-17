using PostBoard.Shared.Models.Category;
using PostBoard.Shared.Models.Post;
using System.Net.Http.Json;

namespace PostBoard.Client.Services.Category
{
    public class CategoryService : ICategoryService
    {
        private HttpClient _client;
        public CategoryService(HttpClient client)
        {
            _client = client;
        }

        public async Task<IEnumerable<CategoryListItem>> GetAllCategoriesAsync()
        {
            var categories = await _client.GetFromJsonAsync<List<CategoryListItem>>("/api/category/view/all");
            return categories;
        }

        public async Task<CategoryView> GetCategoryByIdAsync(int id)
        {
            var category = await _client.GetFromJsonAsync<CategoryView>($"/api/category/view/{id}");
            return category;
        }

        public async Task<bool> CreateCategoryAsync(CategoryCreate model)
        {
            var result = await _client.PostAsJsonAsync<CategoryCreate>("/api/category/create", model);
            if (result.IsSuccessStatusCode) return true;
            return false;
        }

        public async Task<bool> UpdateCategoryByIdAsync(int id, CategoryCreate model)
        {
            var result = await _client.PutAsJsonAsync<CategoryCreate>($"/api/update/{id}", model);
            if (result.IsSuccessStatusCode) return true;
            return false;
        }

        public async Task<bool> DeleteCategoryByIdAsync(int id)
        {
            var result = await _client.DeleteAsync($"/api/delete/{id}");
            if (result.IsSuccessStatusCode) return true;
            return false;
        }
    }
}
