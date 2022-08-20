using System.ComponentModel.DataAnnotations;

namespace PostBoard.Shared.Category
{
    public class CategoryCreate
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }
    }
}
