using PostBoard.Shared.Category;
using PostBoard.Shared.Comment;

namespace PostBoard.Shared.Post
{
    public class PostDetail
    {
        public CategoryListItem Category { get; set; }
        public DateTime Posted { get; set; } 
        public DateTime Modified { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public List<CommentDetail> Comments { get; set; }
    }
}
