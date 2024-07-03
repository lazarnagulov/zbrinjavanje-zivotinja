using LangLang.WPF.MVVM;
using PetCenter.Core.Stores;
using PetCenter.Core.Util;
using PetCenter.Domain.Enumerations;
using PetCenter.WPF.Command;
using PetCenter.WPF.MVVM;
using PetCenter.WPF.ViewModels.Member;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetCenter.WPF.ViewModels.Authentication
{
    public class LoginViewModel : ViewModelBase
    {
        private INavigationService _navigationService;

        public NavigationCommand<RegisterViewModel> ToRegisterCommand { get; }
        public RelayCommand LoginCommand { get; }

        public LoginViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            ToRegisterCommand = navigationService.CreateNavCommand<RegisterViewModel>(ViewType.Register);
            LoginCommand = new RelayCommand(execute => Login());
        }

        public void Login()
        {
            _navigationService.SwitchWindow(WindowType.Member);
        }
    }
}
