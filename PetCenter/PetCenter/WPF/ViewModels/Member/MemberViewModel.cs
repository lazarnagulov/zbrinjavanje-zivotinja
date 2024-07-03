using LangLang.WPF.MVVM;
using PetCenter.Core.Stores;
using PetCenter.Core.Util;
using PetCenter.Domain.Enumerations;
using PetCenter.WPF.Command;
using PetCenter.WPF.MVVM;
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
        private readonly INavigationService _navigationService;
        public ViewModelBase CurrentViewModel => _navigationStore.CurrentViewModel;

        public RelayCommand LogoutCommand { get; }
        public NavigationCommand<Test1ViewModel> NavTest1Command { get; }
        public NavigationCommand<Test2ViewModel> NavTest2Command { get; }

        public MemberViewModel(NavigationStore navigationStore, INavigationService navigationService)
        {
            _navigationStore = navigationStore;
            _navigationService = navigationService;
            _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;

            LogoutCommand = new RelayCommand(execute => _navigationService.SwitchWindow(WindowType.Authentication));
            NavTest1Command = _navigationService.CreateNavCommand<Test1ViewModel>(ViewType.Test1);
            NavTest2Command = _navigationService.CreateNavCommand<Test2ViewModel>(ViewType.Test2);
        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
    }
}
