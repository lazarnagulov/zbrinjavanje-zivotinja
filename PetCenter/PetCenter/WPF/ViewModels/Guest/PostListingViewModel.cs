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
        private readonly OfferService _offerService;

        public bool LoggedUser => _authenticationStore.IsLoggedIn;
        public AccountType? LoggedAccount => _authenticationStore.CurrentUserProfile?.Type;

        public ObservableCollection<PostViewModel> Posts { get; } = [];
        public ICommand LikePostCommand { get; }
        public ICommand AddCommentCommand { get; }
        public ICommand RequestAdoptionCommand { get; }
        public ICommand RequestTemporaryAccommodationCommand { get; }
        public ICommand HidePostCommand { get; }
        public ICommand DeleteCommentCommand { get; }
        public ICommand CancelOffersCommand { get; }
        public ICommand ToReviewsCommand { get; }

        public PostListingViewModel(PostService postService, AuthenticationStore authenticationStore, CreatePostViewModel createPostViewModel, OfferService offerService)
        {
            _authenticationStore = authenticationStore;
            _postService = postService;
            _offerService = offerService;

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
            RequestAdoptionCommand = new RelayCommand<PostViewModel>(AdoptionCommand, CanAdopt);
            RequestTemporaryAccommodationCommand = new RelayCommand<PostViewModel>(TemporaryAccommodationCommand, CanAccommodate);
            CancelOffersCommand = new RelayCommand<PostViewModel>(CancelOffers, CanCancel);
            HidePostCommand = new RelayCommand<PostViewModel>(HidePost);
            DeleteCommentCommand = new RelayCommand(DeleteComment);
            ToReviewsCommand = new RelayCommand<PostViewModel>(ToReviews);

            createPostViewModel.OnPostInsert += InsertPostEvent;
        }

        private void ToReviews(PostViewModel obj)
        {

        }

        private void InsertPostEvent(PostViewModel postViewModel)
        {
            Posts.Add(postViewModel);
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
        private void CancelOffers(PostViewModel postViewModel)
        {
            foreach (Offer offer in postViewModel.State.Context.Offers.ToList())
            {
                if (offer.Offerer.Id == _authenticationStore.LoggedUser!.Id)
                {
                    _offerService.Delete(offer);
                    postViewModel.State.Context.RemoveOffer(offer);
                }
            }
        }
        private bool CanCancel(PostViewModel postViewModel)
        {
            if (postViewModel.State is not Accepted) return false;

            Guid? userId = _authenticationStore.LoggedUser?.Id;

            if (userId == null) return false;

            foreach (Offer offer in postViewModel.State.Context.Offers)
            {
                if (offer.Offerer.Id == userId)
                {
                    return true;
                }
            }
            return false;
        }
        private void TemporaryAccommodationCommand(PostViewModel postViewModel)
        {
            Offer offer = new Offer(_authenticationStore.LoggedUser!, OfferType.TemporaryAccommodation);
            postViewModel.State.Context.AddOffer(offer);
            _offerService.Insert(offer);
            _postService.Update(postViewModel.State.Context);
        }
        private bool CanAccommodate(PostViewModel postViewModel)
        {
            if (postViewModel.State is not Accepted) return false;

            Guid? userId = _authenticationStore.LoggedUser?.Id;

            if (userId == null) return false;

            foreach (Offer offer in postViewModel.State.Context.Offers)
            {
                if (offer.Type == OfferType.TemporaryAccommodation && offer.Offerer.Id == userId) return false;
            }

            return true;
        }
        private bool CanAdopt(PostViewModel postViewModel)
        {
            if (postViewModel.State is not Accepted) return false;
            
            Guid? userId = _authenticationStore.LoggedUser?.Id;

            if (userId == null) return false;

            foreach (Offer offer in postViewModel.State.Context.Offers)
            {
                if (offer.Type == OfferType.Adoption && offer.Offerer.Id == userId) return false;
            }

            return true;
        }

        private void AdoptionCommand(PostViewModel postViewModel)
        {
            Offer offer = new Offer(_authenticationStore.LoggedUser!, OfferType.Adoption);
            postViewModel.State.Context.AddOffer(offer);
            _offerService.Insert(offer);
            _postService.Update(postViewModel.State.Context);
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
