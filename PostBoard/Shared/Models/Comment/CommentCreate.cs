using System.ComponentModel.DataAnnotations;

namespace PostBoard.Shared.Models.Comment
{
    public class CommentCreate
    {
        [Required]
        [MaxLength(100000)]
        public string Content { get; set; }
    }
}
