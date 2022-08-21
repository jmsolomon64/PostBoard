using System.ComponentModel.DataAnnotations;

namespace PostBoard.Shared.Models.Comment
{
    public class CommentEdit
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Content { get; set; }

    }
}
