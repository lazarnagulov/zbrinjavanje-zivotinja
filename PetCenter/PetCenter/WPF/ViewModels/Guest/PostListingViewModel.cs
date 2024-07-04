using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.TextFormatting;
using PetCenter.Core.Service;
using PetCenter.Core.Stores;
using PetCenter.Core.Util;
using PetCenter.Domain.Enumerations;
using PetCenter.Domain.Model;
using PetCenter.Domain.State;
using PetCenter.WPF.BaseViewModels;
using PetCenter.WPF.MVVM;
using PetCenter.WPF.ViewModels.Member;

namespace PetCenter.WPF.ViewModels.Guest
{
    public class PostListingViewModel : ViewModelBase
    {
        private readonly PostService _postService;
        private readonly AuthenticationStore _authenticationStore;

        public bool LoggedUser => _authenticationStore.IsLoggedIn;
        public AccountType? LoggedAccount => _authenticationStore.CurrentUserProfile?.Type;

        public ObservableCollection<PostViewModel> Posts { get; } = [];
        public ICommand LikePostCommand { get; }
        public ICommand AddCommentCommand { get; }
        public ICommand RequestAdoptionCommand { get; }
        public ICommand RequestTemporaryAccommodationCommand { get; }
        public ICommand HidePostCommand { get; }
        public ICommand DeleteCommentCommand { get; }

        public PostListingViewModel(PostService postService, AuthenticationStore authenticationStore, CreatePostViewModel createPostViewModel)
        {
            _authenticationStore = authenticationStore;
            _postService = postService;

            var posts = authenticationStore.CurrentUserProfile?.Type switch
            {
                AccountType.Volunteer => postService.GetAcceptedWithHidden(),
                _ => postService.GetAccepted()
            };

            foreach (var post in posts)
            {
                Posts.Add(new PostViewModel(post));
            }

            LikePostCommand = new RelayCommand<PostViewModel>(LikeCommand);
            AddCommentCommand = new RelayCommand<PostViewModel>(CommentCommand, CanComment);
            RequestAdoptionCommand = new RelayCommand(AdoptionCommand);
            RequestTemporaryAccommodationCommand = new RelayCommand(TemporaryAccommodationCommand);
            HidePostCommand = new RelayCommand<PostViewModel>(HidePost);
            DeleteCommentCommand = new RelayCommand(DeleteComment);

            createPostViewModel.OnPostInsert += InsertPostEvent;
        }

        private void InsertPostEvent(PostViewModel postViewModel)
        {
            Posts.Add(postViewModel);
            Feedback.SuccessfullyCreatedPost();
        }

        private void DeleteComment(object? obj)
        {
            var parameters = obj as object[];
            var post = parameters?[0] as PostViewModel;
            var comment = parameters?[1] as CommentViewModel;

            post!.Comments.Remove(comment!);
            _postService.DeleteComment(comment!.Id);
        }

        private void HidePost(PostViewModel postViewModel)
        {
            if (postViewModel.State is Accepted)
            {
                postViewModel.State.HidePost();
                postViewModel.State = postViewModel.State.Context.State;
                Feedback.SuccessfulHiddenPost();
            }
            else if (postViewModel.State is Hidden)
            {
                postViewModel.State.ShowPost();
                postViewModel.State = postViewModel.State.Context.State;
                Feedback.SuccessfullyDisplayedPost();
            }
            else
            {
                Feedback.CannotHidePost(postViewModel.State.ToString()!);
            }
            _postService.Update(postViewModel.State.Context);
        }

        private void TemporaryAccommodationCommand(object? obj)
        {
            throw new NotImplementedException();
        }

        private void AdoptionCommand(object? obj)
        {
            throw new NotImplementedException();
        }

        private static bool CanComment(PostViewModel arg) => !string.IsNullOrEmpty(arg.NewComment);
        private void CommentCommand(PostViewModel obj)
        {
            var comment = new Comment(_authenticationStore.LoggedUser!, obj.NewComment);
            obj.Comments.Add(new CommentViewModel(comment));
            _postService.AddComment(obj.Id, comment);
        }

        private void LikeCommand(PostViewModel obj) => obj.LikeCount = _postService.AddLike(obj.Id);
    }
}
