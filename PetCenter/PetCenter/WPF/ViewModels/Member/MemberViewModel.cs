using PetCenter.Core.Service;
using PetCenter.Core.Stores;
using PetCenter.Core.Util;
using PetCenter.Domain.Enumerations;
using PetCenter.Domain.Model;
using PetCenter.WPF.MVVM;
using PetCenter.WPF.ViewModels.Guest;
using PetCenter.WPF.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PetCenter.WPF.ViewModels.Member
{
    public class MemberViewModel : ViewModelBase
    {
        private readonly NavigationStore _navigationStore;
        private readonly AuthenticationStore _authenticationStore;
        private readonly INavigationService _navigationService;
        private readonly RequestService _requestService;
        public ViewModelBase CurrentViewModel => _navigationStore.CurrentViewModel;

        public RelayCommand LogoutCommand { get; }
        public NavigationCommand<PostListingViewModel> NavPostListingCommand { get; }
        public NavigationCommand<CreatePostViewModel> NavCreatePostCommand { get; }
        public NavigationCommand<NotificationListingViewModel> NavNotificationCommand { get; }
        public RelayCommand ToggleRequestCommand { get; }

        public bool HasRequest => _requestService.HasRequest();

        public MemberViewModel(NavigationStore navigationStore, INavigationService navigationService, AuthenticationStore authenticationStore, RequestService requestService)
        {
            _authenticationStore = authenticationStore;
            _navigationStore = navigationStore;
            _navigationService = navigationService;
            _requestService = requestService;
            _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;

            LogoutCommand = new RelayCommand(execute => Logout());
            NavPostListingCommand = _navigationService.CreateNavCommand<PostListingViewModel>(ViewType.PostListing);
            NavCreatePostCommand = _navigationService.CreateNavCommand<CreatePostViewModel>(ViewType.CreatePost);
            NavNotificationCommand = _navigationService.CreateNavCommand<NotificationListingViewModel>(ViewType.NotificationListing);
            ToggleRequestCommand = new RelayCommand(execute => ToggleRequest());
        }

        private void Logout()
        {
            _authenticationStore.Logout();
            _navigationService.SwitchWindow(WindowType.Authentication);
        }

        private void ToggleRequest()
        {
            if (HasRequest)
            {
                var result = MessageBox.Show("Are you sure you want to cancel your request?", "Are you sure?", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    _requestService.DeleteForCurrentUser();
                    MessageBox.Show("Success!");
                }
            }
            else
            {
                bool success = _requestService.CreateRequest();
                if (success)
                {
                    MessageBox.Show("Success!");
                    OnPropertyChanged(nameof(HasRequest));
                }
                else
                    MessageBox.Show("Failed to create request.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
    }
}
