using System.ComponentModel.DataAnnotations;

namespace PostBoard.Shared.Models.Category
{
    public class CategoryCreate
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(10000)]
        public string Description { get; set; }
    }
}
