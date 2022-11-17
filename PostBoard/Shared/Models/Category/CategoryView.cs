using PostBoard.Shared.Models.Post;

namespace PostBoard.Shared.Models.Category
{
    public class CategoryView
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<PostListView> Posts { get; set; }
    }
}
