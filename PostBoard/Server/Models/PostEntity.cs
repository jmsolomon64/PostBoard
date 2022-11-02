using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PostBoard.Server.Models
{
    public class PostEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [Required]
        public DateTime Posted { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required]
        [MaxLength(100000000)]
        public string Content { get; set; }

        public virtual ICollection<CommentEntity> Comments { get; set; }

        public PostEntity()
        {
            Comments = new List<CommentEntity>();
        }
    }
}
