﻿using PostBoard.Client.Shared.Post;

namespace PostBoard.Client.Shared.Category
{
    public class CategoryDetail
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<PostListItem> Posts { get; set; }
    }
}
