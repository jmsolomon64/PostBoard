using Microsoft.AspNetCore.Components;
using PostBoard.Client.Services.Post;
using PostBoard.Shared.Models.Post;

namespace PostBoard.Client.Pages.Post
{
    public partial class ViewAllPosts
    {
        [Inject]
        HttpClient client { get; set; }

        [Inject]
        IPostService _post { get; set; }

        List<PostListView> _posts = new List<PostListView>();
        List<PostDetailView> postDetails = new List<PostDetailView>();
        PostDetailView errorDetail = new PostDetailView() { Title= "Error" };

        private void PostMaker()
        {
            _posts.Add(new PostListView { Id = 0, Category = "Cartoons", Posted = DateTime.Now, Title = "favorites", Comments = 3 });
            _posts.Add(new PostListView { Id = 1, Category = "Video Games", Posted = DateTime.MaxValue, Title = "Best Souls Game?", Comments = int.MaxValue });
            _posts.Add(new PostListView { Id = 2, Category = "History", Posted = DateTime.MinValue, Title = "Have you noticed nothings happened yet?", Comments = int.MaxValue });
        }

        protected override async Task OnInitializedAsync()
        {
            var posts = await _post.GetAllPostsAsync();
            foreach (PostListView post in posts)
            {
                var detail = await _post.GetPostById(post.Id);

                if (detail == null) { postDetails.Add(errorDetail); }
                else { postDetails.Add(detail); }

                _posts.Add(post);
            }
        }
    }
}
