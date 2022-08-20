using System.ComponentModel.DataAnnotations;

namespace PostBoard.Client.Shared.Comment
{
    public class CommentCreate
    {
        [Required]
        public string Content { get; set; }
    }
}
