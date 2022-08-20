using DocumentFormat.OpenXml.Office2021.PowerPoint.Comment;

namespace PostBoard.Client.Shared.Post
{
    public class PostDetail
    {
        public int CategoryId { get; set; }
        public DateTime Posted { get; set; } 
        public DateTime Modified { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
