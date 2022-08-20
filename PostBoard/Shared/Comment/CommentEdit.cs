using System.ComponentModel.DataAnnotations;

namespace PostBoard.Shared.Comment
{
    public class CommentEdit
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Content { get; set; }

    }
}
