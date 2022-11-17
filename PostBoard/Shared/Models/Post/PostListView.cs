namespace PostBoard.Shared.Models.Post
{
    public class PostListView
    {
        public int Id { get; set; }
        public string Category { get; set; }
        public DateTime Posted { get; set; }
        public string Title { get; set; }
        public int Comments { get; set; }
    }
}
