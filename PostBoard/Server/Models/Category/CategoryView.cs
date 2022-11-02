using PostBoard.Server.Models.Post;

namespace PostBoard.Server.Models.Category
{
    public class CategoryView
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<PostListView> Posts { get; set; }
    }
}
