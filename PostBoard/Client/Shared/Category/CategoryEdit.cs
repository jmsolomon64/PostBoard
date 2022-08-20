using System.ComponentModel.DataAnnotations;

namespace PostBoard.Client.Shared.Category
{
    public class CategoryEdit
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }
    }
}
