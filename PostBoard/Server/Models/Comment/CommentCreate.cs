using System.ComponentModel.DataAnnotations;

namespace PostBoard.Server.Models.Comment
{
    public class CommentCreate
    {
        [Required]
        [MaxLength(100000)]
        public string Content { get; set; }
    }
}
