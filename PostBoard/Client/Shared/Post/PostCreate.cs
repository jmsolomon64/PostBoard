using System.ComponentModel.DataAnnotations;

namespace PostBoard.Client.Shared.Post
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
