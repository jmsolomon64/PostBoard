namespace PostBoard.Client.Shared.Comment
{
    public class CommentDetail
    {
        public int Id { get; set; }
        public DateTime Posted { get; set; }
        public DateTime Modified { get; set; }
        public string Content { get; set; }
    }
}
