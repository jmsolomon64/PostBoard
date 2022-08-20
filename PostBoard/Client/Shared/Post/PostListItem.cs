using DocumentFormat.OpenXml.Presentation;

namespace PostBoard.Client.Shared.Post
{
    public class PostListItem
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public int Title { get; set; }
        public DateTime Posted { get; set; }
        public DateTime Modified { get; set; }
    }
}
