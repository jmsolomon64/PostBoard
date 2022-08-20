using System.ComponentModel.DataAnnotations;

namespace PostBoard.Server.Models
{
    public class CategoryEntity
    {
        [Required]
        public int Id { get; set; }

        public virtual ICollection<PostEntity> Posts { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(10000)]
        public string Description { get; set; }

        public CategoryEntity()
        {
            Posts = new List<PostEntity>();
        }
    }
}
