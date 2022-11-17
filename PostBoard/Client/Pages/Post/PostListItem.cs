using Microsoft.AspNetCore.Components;
using PostBoard.Shared.Models.Post;

namespace PostBoard.Client.Pages.Post
{
    
    public partial class PostListItem
    {
        [Parameter]
        public PostListView? PostItem { get; set; }
    }
}
