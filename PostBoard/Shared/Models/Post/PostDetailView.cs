using PostBoard.Shared.Models.Comment;

namespace PostBoard.Shared.Models.Post
{
    public class PostDetailView
    {
        public int Id { get; set; }
        public string Category { get; set; }
        public DateTime Posted { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public List<CommentDetail> Comments; 
    }
}
