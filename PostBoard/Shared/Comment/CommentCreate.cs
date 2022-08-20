using System.ComponentModel.DataAnnotations;

namespace PostBoard.Shared.Comment
{
    public class CommentCreate
    {
        [Required]
        public int PostId { get; set; }

        [Required]
        public string Content { get; set; }
    }
}
