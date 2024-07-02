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
using PetCenter.Core.Stores;
using PetCenter.Domain.Model;
using PetCenter.WPF.BaseViewModels;
using PetCenter.WPF.MVVM;

namespace PetCenter.WPF.ViewModels
{
    public class PostListingViewModel : ViewModelBase
    {
        private readonly PostService _postService;
        private readonly AuthenticationStore _authenticationStore;

        private readonly ObservableCollection<PostViewModel> _posts;
        public ObservableCollection<PostViewModel> Posts => _posts;
        public ICommand LikePostCommand { get; }
        public ICommand AddCommentCommand { get; }

        public PostListingViewModel(PostService postService, AuthenticationStore authenticationStore)
        {
            _authenticationStore = authenticationStore;
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
            var comment = new Comment(_authenticationStore.LoggedUser!, obj.NewComment);
            obj.Comments.Add(new CommentViewModel(comment));
            _postService.AddComment(obj.Id, comment);
        }

        private void LikeCommand(PostViewModel obj)
        {

        }
    }
}
