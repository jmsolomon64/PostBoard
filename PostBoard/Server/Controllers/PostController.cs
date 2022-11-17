using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PostBoard.Shared.Models.Post;
using PostBoard.Server.Services.Post;

namespace PostBoard.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostService _post;
        public PostController(IPostService post)
        {
            _post = post;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreatePost(PostCreate model)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);

            bool success = _post.CreatePost(model);
            if (!success) return BadRequest("Post didn't land, please try again later!");

            return Ok("Post landed");
        }

        [HttpGet("view/all")]
        public async Task<IActionResult> ViewAllPosts()
        {
            List<PostListView> posts = new List<PostListView>(_post.ViewAllPosts());
            if (posts == null) return BadRequest("Posts could not be reached at this time. Please try again later.");

            return Ok(posts);
        }

        [HttpGet("view/{id}")]
        public async Task<IActionResult> ViewPostById(int id)
        {
            PostDetailView post = new PostDetailView();
            post = _post.ViewPost(id);

            if (post == null) return NotFound();
            return Ok(post);
        }

        [HttpDelete]
        public async Task<IActionResult> DeletePost(int id)
        {
            bool success = _post.DeletePost(id);

            if (!success) return BadRequest("Couldn't remove post from the board at this time.");
            return Ok("Post removed from board.");
        }

    }
}
