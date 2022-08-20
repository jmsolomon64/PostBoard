using System.ComponentModel.DataAnnotations;

namespace PostBoard.Server.Models
{
    public class CommentEntity
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int PostId { get; set; }

        [Required]
        public DateTime Posted { get; set; }

        public DateTime Modified { get; set; }

        [Required]
        [MaxLength(100000)]
        public string Content { get; set; }
    }
}
