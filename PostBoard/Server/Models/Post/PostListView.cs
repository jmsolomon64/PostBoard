namespace PostBoard.Server.Models.Post
{
    public class PostListView
    {
        public string Category { get; set; }
        public DateTime Posted { get; set; }
        public string Title { get; set; }
        public int Comments { get; set; }
    }
}
