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
    public class RegisterViewModel : ViewModelBase
    {
        private INavigationService _navigationService;

        public NavigationCommand<LoginViewModel> ToLoginCommand { get; }
        public RelayCommand RegisterCommand { get; }

        public RegisterViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            ToLoginCommand = navigationService.CreateNavCommand<LoginViewModel>(ViewType.Login);
            RegisterCommand = new RelayCommand(execute => Register());
        }

        public void Register()
        {
            _navigationService.SwitchWindow(WindowType.Member);
        }
    }
}
