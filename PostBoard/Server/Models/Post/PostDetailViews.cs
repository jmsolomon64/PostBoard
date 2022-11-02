using PostBoard.Server.Models.Comment;

namespace PostBoard.Server.Models.Post
{
    public class PostDetailViews
    {
        public string Category { get; set; }
        public DateTime Posted { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public List<CommentDetail> Comments; 
    }
}
