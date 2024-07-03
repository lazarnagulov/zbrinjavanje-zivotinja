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
using System.Windows;

namespace PetCenter.WPF.ViewModels.Member
{
    public class Test1ViewModel : ViewModelBase
    {
        private NavigationService _navigationService;
        public NavigationCommand<Test2ViewModel> NavigateCommand { get; }
        public RelayCommand ContinueAsGuestCommand { get; }
        public RelayCommand LogoutCommand { get; }
        public Test1ViewModel(NavigationService navigationService)
        {
            _navigationService = navigationService;
            NavigateCommand = navigationService.CreateNavCommand<Test2ViewModel>(ViewType.Test2);
            ContinueAsGuestCommand = new RelayCommand(execute => ContinueAsGuest());
            LogoutCommand = new RelayCommand(execute => Logout());
        }

        public void ContinueAsGuest()
            => _navigationService.SwitchWindow(WindowType.Member);

        public void Logout()
            => _navigationService.SwitchWindow(WindowType.Authentication);

    }
}
