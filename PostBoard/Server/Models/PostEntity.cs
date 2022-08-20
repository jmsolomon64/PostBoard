using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PostBoard.Server.Models
{
    public class PostEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int CategoryId { get; set; }
        public virtual CategoryEntity Category { get; set; }

        [Required]
        public string OwnerId { get; set; }

        [Required]
        public DateTime Posted { get; set; }

        public DateTime Modified { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required]
        [MaxLength(100000000)]
        public string Content { get; set; }

        [JsonIgnore]
        public virtual ICollection<CommentEntity> Comments { get; set; }

        public PostEntity()
        {
            Comments = new List<CommentEntity>();
        }
    }
}
