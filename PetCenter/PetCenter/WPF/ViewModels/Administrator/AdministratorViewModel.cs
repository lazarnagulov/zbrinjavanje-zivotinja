using PetCenter.Core.Stores;
using PetCenter.Core.Util;
using PetCenter.Domain.Enumerations;
using PetCenter.WPF.Command;
using PetCenter.WPF.MVVM;
using PetCenter.WPF.ViewModels.Guest;
using PetCenter.WPF.ViewModels.Member;
using PetCenter.WPF.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetCenter.WPF.ViewModels.Administrator
{
    public class AdministratorViewModel : ViewModelBase
    {
        private readonly NavigationStore _navigationStore;
        private readonly INavigationService _navigationService;
        public ViewModelBase CurrentViewModel => _navigationStore.CurrentViewModel;

        public RelayCommand LogoutCommand { get; }
        public NavigationCommand<PostListingViewModel> NavPostListingCommand { get; }
        public NavigationCommand<CreatePostViewModel> NavCreatePostCommand { get; }

        public AdministratorViewModel(NavigationStore navigationStore, INavigationService navigationService)
        {
            _navigationStore = navigationStore;
            _navigationService = navigationService;
            _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;

            LogoutCommand = new RelayCommand(execute => _navigationService.SwitchWindow(WindowType.Authentication));
            NavPostListingCommand = _navigationService.CreateNavCommand<PostListingViewModel>(ViewType.PostListing);
            NavCreatePostCommand = _navigationService.CreateNavCommand<CreatePostViewModel>(ViewType.CreatePost);
        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
    }
}
