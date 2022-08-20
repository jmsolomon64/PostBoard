using DocumentFormat.OpenXml.Office2021.PowerPoint.Comment;
using PostBoard.Client.Shared.Category;
using PostBoard.Client.Shared.Comment;

namespace PostBoard.Client.Shared.Post
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
