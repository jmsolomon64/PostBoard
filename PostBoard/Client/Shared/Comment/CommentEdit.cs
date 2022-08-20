using System.ComponentModel.DataAnnotations;

namespace PostBoard.Client.Shared.Comment
{
    public class CommentEdit
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Content { get; set; }

    }
}
