using System.ComponentModel.DataAnnotations;

namespace PostBoard.Shared.Models.Comment
{
    public class CommentCreate
    {
        [Required]
        public int PostId { get; set; }

        [Required]
        public string Content { get; set; }
    }
}
