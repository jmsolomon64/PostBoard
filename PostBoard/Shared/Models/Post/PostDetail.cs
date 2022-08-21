using PostBoard.Shared.Models.Category;
using PostBoard.Shared.Models.Comment;

namespace PostBoard.Shared.Models.Post
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
