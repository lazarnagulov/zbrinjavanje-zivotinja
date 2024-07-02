using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using PetCenter.Core.Service;
using PetCenter.WPF.BaseViewModels;
using PetCenter.WPF.MVVM;

namespace PetCenter.WPF.ViewModels
{
    public class PostListingViewModel : ViewModelBase
    {
        private readonly PostService _postService;

        private readonly ObservableCollection<PostViewModel> _posts;
        public ObservableCollection<PostViewModel> Posts => _posts;
        public ICommand LikePostCommand { get; }
        public ICommand AddCommentCommand { get; }

        public PostListingViewModel(PostService postService)
        {
            _postService = postService;
            _posts = new ObservableCollection<PostViewModel>();
            foreach (var post in postService.GetAccepted())
            {
                _posts.Add(new PostViewModel(post));
            }

            LikePostCommand = new RelayCommand<PostViewModel>(LikeCommand);
            AddCommentCommand = new RelayCommand<PostViewModel>(CommentCommand);
        }

        private void CommentCommand(PostViewModel obj)
        {

        }

        private void LikeCommand(PostViewModel obj)
        {
            ++obj.LikeCount;
        }
    }
}
