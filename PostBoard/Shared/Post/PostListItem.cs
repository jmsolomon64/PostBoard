namespace PostBoard.Shared.Post
{
    public class PostListItem
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string Title { get; set; }
        public DateTime Posted { get; set; }
        public DateTime Modified { get; set; }
    }
}
