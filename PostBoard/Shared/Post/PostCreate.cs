using System.ComponentModel.DataAnnotations;

namespace PostBoard.Shared.Post
{
    public class PostCreate
    {
        public int CategoryId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

    }
}
