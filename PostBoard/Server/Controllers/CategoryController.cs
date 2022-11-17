using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PostBoard.Shared.Models.Category;
using PostBoard.Shared.Models.Post;
using PostBoard.Server.Services.Category;

namespace PostBoard.Server.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryServices _category;

        public CategoryController(ICategoryServices category)
        {
            _category = category;
        }

        [HttpGet("view/all")]
        public async Task<IActionResult> ViewAllCategories()
        {
            List<CategoryListItem> categories = new List<CategoryListItem>(_category.GetCategories());

            if (categories == null) return BadRequest("Couldn't reach the categories at this time.");
            return Ok(categories);
        }

        [HttpGet("view/{id}")]
        public async Task<IActionResult> ViewCategory(int id)
        {
            CategoryView category = _category.GetCategory(id);

            if(category == null) return NotFound();
            return Ok(category);
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateCategory(CategoryCreate model)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);

            bool success = _category.AddCategory(model);
            if (!success) return BadRequest("Category could not be made at this time.");
            return Ok("Category Created");
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateCategory(CategoryCreate model, int id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            bool success = _category.UpdateCategory(model, id);
            if (!success) return BadRequest("Category couldn't be updated right now");
            return Ok("Category Updated");
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var category = _category.GetCategory(id);
            if (category == null) return NotFound();

            bool success = _category.DeleteCategory(id);
            if (!success) return BadRequest("Category couldn't be deleted");
            return Ok("Category Deleted");
        }

    }
}
