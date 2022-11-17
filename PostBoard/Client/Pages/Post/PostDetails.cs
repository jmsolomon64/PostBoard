using Microsoft.AspNetCore.Components;
using PostBoard.Client.Services.Post;
using PostBoard.Shared.Models.Post;

namespace PostBoard.Client.Pages.Post
{
    public partial class PostDetails
    {
        [Parameter]
        public PostDetailView PostDetail { get; set; }

        
    }
}
