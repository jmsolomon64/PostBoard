using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PostBoard.Client.Shared.Post;
using PostBoard.Server.Services.Post;
using System.Security.Claims;

namespace PostBoard.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostService _post;
        public PostController(IPostService service)
        {
            _post = service;
        }

        private string GetUserId()
        {
            //recieves userId from the token sent to API
            string userIdClaim = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value;

            if (userIdClaim == null) return null;
            return userIdClaim;
        }

        private bool SetUserIdInService()
        {
            var userId = GetUserId();

            if(userId == null) return false;

            _post.SetUserId(userId);
            return true;
        }

        [HttpGet]
        public async Task<List<PostListItem>> Index()
        {
            if (!SetUserIdInService()) return new List<PostListItem>();

            var posts = await _post.GetAllPostsAsync();
            return posts.ToList();
        }

        [HttpGet("user")]
        public async Task<List<PostListItem>> UserPosts()
        {
            if (!SetUserIdInService()) return new List<PostListItem>();

            var posts = await _post.GetAllUserPostsAsync();
            return posts.ToList();
        }

        [HttpGet("{id}")]
        public async Task<PostDetail> Post(int id)
        {
            var post = await _post.GetPostByIdAsync(id);

            if (post == null) return null;
            return post;
        }

        [HttpGet("{id}")]
        public async Task<List<PostListItem>> PostsByCategory(int categoryId)
        {
            var posts = await _post.GetPostsByCategoryAsync(categoryId);

            if (posts == null) return null;
            return posts.ToList();
        }

        [HttpPost]
        public async Task<IActionResult> Create(PostCreate model)
        {
            if (model == null) return BadRequest();
            if (!SetUserIdInService()) return Unauthorized();

            bool success = await _post.CreatePostAsync(model);

            if (success) return Ok();
            else return UnprocessableEntity();
        }

        [HttpPut("edit/{id}")]
        public async Task<IActionResult> Edit(int id, PostEdit model)
        {
            if (!SetUserIdInService()) return Unauthorized();
            if (model == null) return BadRequest();

            bool success = await _post.UpdatePostAsync(model);

            if (success) return Ok();
            else return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (!SetUserIdInService()) return Unauthorized();

            var post = await _post.GetPostByIdAsync(id);
            if(post == null) return NotFound();

            bool success = await _post.DeletePostAsync(id);

            if (!success) return BadRequest();
            else return Ok();
        }
    }
}
