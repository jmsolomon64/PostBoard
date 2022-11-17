using Microsoft.AspNetCore.Components;
using PostBoard.Client.Services.Post;
using PostBoard.Shared.Models.Post;
using System.Resources;

namespace PostBoard.Client.Pages.Post
{
    public partial class CreatePost : ComponentBase
    {
        [Parameter]
        public EventCallback<bool> CloseEventCallBack { get; set; }
        [Inject]
        IPostService _post { get; set; } //injected at component initialization

        public PostCreate NewPost { get; set; } = new PostCreate(); //Instance of PostCreate

        public bool ShowDialog { get; set; } = true; //bool to control if this pop up is open
        string ErrorMessage { get; set; }

        public void Show()
        {
            ResetDialog(); //Clears any info held in object NewPost
            ShowDialog = true; //Changes bool to true, causing HTML to appear
            StateHasChanged(); //Makes component aware of a change to rerender
        }

        public void Close()
        {
            ShowDialog = false; //changes bool, will make HTML hide
            StateHasChanged(); //makes change occur
        }

        private void ResetDialog()
        {
            NewPost = new PostCreate();
        }

        protected async Task OnInitializedAsync()
        {
            Console.WriteLine("Please work");
        }

        protected async Task HandleValidSubmit()
        {
            Console.WriteLine(NewPost);
            await _post.CreatePost(NewPost);
            ShowDialog= false;
            await CloseEventCallBack.InvokeAsync(true); //I think this lets parent component know event is done
            StateHasChanged();
            
        }
    }
}
