using System.ComponentModel.DataAnnotations;

namespace PostBoard.Shared.Models.Post
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
