using PetCenter.Core.Service;
using PetCenter.Core.Stores;
using PetCenter.WPF.BaseViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using PetCenter.WPF.MVVM;
using PetCenter.WPF.ViewModels.Guest;
using PetCenter.Core.Util;

namespace PetCenter.WPF.ViewModels.Volunteer
{
    public class PostReviewViewModel : ViewModelBase
    {
        private readonly PostService _postService;
        private readonly AuthenticationStore _authenticationStore;

        public ObservableCollection<PostViewModel> Posts { get; } = [];
        public ICommand AcceptPostCommand { get; }
        public ICommand DeclinePostCommand { get; }

        public PostReviewViewModel(PostService postService, AuthenticationStore authenticationStore)
        {
            _authenticationStore = authenticationStore;
            _postService = postService;
            foreach (var post in postService.GetOnHold())
            {
                Posts.Add(new PostViewModel(post));        
            }

            AcceptPostCommand = new RelayCommand<PostViewModel>(AcceptPost);
            DeclinePostCommand = new RelayCommand<PostViewModel>(DeclinePost);
        }

        private void DeclinePost(PostViewModel postViewModel)
        {
            postViewModel.State.DeclinePost();
            postViewModel.State = postViewModel.State.Context.State;
            _postService.Update(postViewModel.State.Context);
        }

        private void AcceptPost(PostViewModel postViewModel)
        {
            postViewModel.State.AcceptPost();
            postViewModel.State = postViewModel.State.Context.State;
            _postService.Update(postViewModel.State.Context);
        }
    }
}
