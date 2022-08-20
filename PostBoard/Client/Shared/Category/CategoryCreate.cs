using System.ComponentModel.DataAnnotations;

namespace PostBoard.Client.Shared.Category
{
    public class CategoryCreate
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }
    }
}
