using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PostBoard.Shared.Models.Comment;
using PostBoard.Server.Services.Comment;

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

        [HttpPost("add/{id}")]
        public async Task<IActionResult> CreateComment(int id, CommentCreate comment)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            bool success = _comment.CreateComment(comment, id);
            if(!success) return BadRequest(ModelState);
            return Ok();
        }

        [HttpGet("view/{id}")]
        public async Task<IActionResult> ViewCommentsByPost(int id)
        {
            List<CommentDetail> comments = new List<CommentDetail>(_comment.GetComments(id));
            if (comments == null) return NotFound("There are no comments");
            return Ok(comments);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteCommentById(int id)
        {
            bool success = _comment.DeleteComment(id);

            if (!success) return BadRequest("Comment couldn't be deleted at this time.");
            return Ok("Post Deleted");
        }

    }
}
