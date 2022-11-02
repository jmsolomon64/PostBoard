using System.ComponentModel.DataAnnotations;

namespace PostBoard.Server.Models.Post
{
    public class PostCreate
    {
        [Required]
        public int CategoryId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required]
        [MaxLength(100000000)]
        public string Content { get; set; }
    }
}
