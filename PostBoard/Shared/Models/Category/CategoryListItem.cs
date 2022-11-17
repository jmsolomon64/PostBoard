namespace PostBoard.Shared.Models.Category
{
    public class CategoryListItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //Holds the number of posts in Category
        public int Posts { get; set; }
    }
}
