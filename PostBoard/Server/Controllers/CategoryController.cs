using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PostBoard.Client.Shared.Category;
using PostBoard.Server.Services.Categroy;

namespace PostBoard.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _category;

        public CategoryController(ICategoryService category)
        {
            _category = category;
        }

        [HttpGet] 
        public async Task<List<CategoryListItem>> Index()
        {
            var categories = await _category.GetAllCategoriesAsync();

            if (categories == null) return null;
            else return categories.ToList();
        }

        [HttpGet("{id}")]
        public async Task<CategoryDetail> GetCategoryById(int id)
        {
            var category = await _category.GetCategoryByIdAsync(id);

            if (category == null) return null;
            else return category;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CategoryCreate model)
        {
            if (model == null || !ModelState.IsValid) return BadRequest(model);

            bool success = await _category.CreateCategoryAsync(model);

            if (success) return Ok();
            else return BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(int id, CategoryEdit model)
        {
            if (model == null || !ModelState.IsValid) return BadRequest(model);

            bool success = await _category.UpdateCategoryAsync(model);

            if (success) return Ok();
            else return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var category = await _category.GetCategoryByIdAsync(id);
            if (category == null) return NotFound();

            bool success = await _category.DeleteCategoryAsync(id);

            if (success) return Ok();
            else return BadRequest();
        }
    }
}
