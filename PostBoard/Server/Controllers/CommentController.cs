using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PostBoard.Server.Services.Comment;
using PostBoard.Client.Shared.Comment;
using System.Security.Claims;

namespace PostBoard.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _comment;

        public CommentController(ICommentService comment)
        {
            _comment = comment;
        }

        private string GetUserId()
        {
            string userIdClaim = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value;

            if (userIdClaim == null) return null;
            return userIdClaim;
        }

        private bool SetUserIdInService()
        {
            var userId = GetUserId();

            if(userId == null) return false;

            _comment.SetUserId(userId);
            return true;
        }

        [HttpGet("{id}")]
        public async Task<List<CommentDetail>> GetCommentsByPost(int id)
        {
            var comments = _comment.GetAllCommentsAsync(id);

            if (comments == null) return null;

            return await comments;
        }

        [HttpPost]
        public async Task<IActionResult> CreateComment(CommentCreate model)
        {
            if(!ModelState.IsValid || model == null) return BadRequest(model);
            if (!SetUserIdInService()) return Unauthorized();

            bool success = await _comment.CreateCommentAsync(model);

            if (success) return Ok();
            else return BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateComment(int id, CommentEdit model)
        {
            if (!ModelState.IsValid || model == null) return BadRequest(model);
            if (!SetUserIdInService()) return Unauthorized();

            bool success = await _comment.UpdateCommentAsync(model);

            if (success) return Ok();
            else return BadRequest();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteComment(int id)
        {
            var comment = await _comment.GetCommentByIdAsync(id);
            if(comment == null) return NotFound();

            bool success = await _comment.DeleteCommentAsync(id);

            if (success) return Ok();
            else return BadRequest();
        }

    }
}
