using PetCenter.Core.Stores;
using PetCenter.Core.Util;
using PetCenter.Domain.Enumerations;
using PetCenter.WPF.MVVM;
using PetCenter.WPF.ViewModels.Guest;
using PetCenter.WPF.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetCenter.WPF.ViewModels.Member
{
    public class MemberViewModel : ViewModelBase
    {
        private readonly NavigationStore _navigationStore;
        private readonly AuthenticationStore _authenticationStore;
        private readonly INavigationService _navigationService;
        public ViewModelBase CurrentViewModel => _navigationStore.CurrentViewModel;

        public RelayCommand LogoutCommand { get; }
        public NavigationCommand<PostListingViewModel> NavPostListingCommand { get; }
        public NavigationCommand<CreatePostViewModel> NavCreatePostCommand { get; }
        public NavigationCommand<NotificationListingViewModel> NavNotificationCommand { get; }

        public MemberViewModel(NavigationStore navigationStore, INavigationService navigationService, AuthenticationStore authenticationStore)
        {
            _authenticationStore = authenticationStore;
            _navigationStore = navigationStore;
            _navigationService = navigationService;
            _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;

            LogoutCommand = new RelayCommand(execute => Logout());
            NavPostListingCommand = _navigationService.CreateNavCommand<PostListingViewModel>(ViewType.PostListing);
            NavCreatePostCommand = _navigationService.CreateNavCommand<CreatePostViewModel>(ViewType.CreatePost);
            NavNotificationCommand = _navigationService.CreateNavCommand<NotificationListingViewModel>(ViewType.NotificationListing);
        }

        private void Logout()
        {
            _authenticationStore.Logout();
            _navigationService.SwitchWindow(WindowType.Authentication);
        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
    }
}
