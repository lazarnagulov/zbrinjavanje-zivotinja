using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using PetCenter.Core.Service;
using PetCenter.WPF.BaseViewModels;

namespace PetCenter.WPF.ViewModels
{
    public class PostListingViewModel : ViewModelBase
    {
        private readonly PostService _postService;
        public ObservableCollection<PostViewModel> Posts;
        public ICommand LikePostCommand { get; }
        public ICommand AddCommentCommand { get; }

        public PostListingViewModel(PostService postService)
        {
            _postService = postService;
            Posts = new ObservableCollection<PostViewModel>();
            foreach (var post in postService.GetAcceptedPosts())
            {
                Posts.Add(new PostViewModel(post));
            }
        }
    }
}
