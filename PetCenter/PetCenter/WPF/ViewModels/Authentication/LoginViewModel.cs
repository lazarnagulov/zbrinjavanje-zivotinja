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
using PetCenter.Core.Service;

namespace PetCenter.WPF.ViewModels.Authentication
{
    public class LoginViewModel : ViewModelBase
    {
        private string _enteredPassword = string.Empty;
        public string EnteredPassword
        {
            get => _enteredPassword;
            set => SetField(ref _enteredPassword, value);
        }

        private string _enteredUsername = string.Empty;

        public string EnteredUsername
        {
            get => _enteredUsername;
            set => SetField(ref _enteredUsername, value);
        }

        private readonly INavigationService _navigationService;
        private readonly LoginService _loginService;

        public NavigationCommand<RegisterViewModel> ToRegisterCommand { get; }
        public RelayCommand LoginCommand { get; }
        public RelayCommand LoginAsGuestCommand { get; }

        public LoginViewModel(INavigationService navigationService, LoginService loginService)
        {
            _loginService = loginService;
            _navigationService = navigationService;
            ToRegisterCommand = navigationService.CreateNavCommand<RegisterViewModel>(ViewType.Register);
            LoginCommand = new RelayCommand(_ => Login());
            LoginAsGuestCommand = new RelayCommand(_ => LoginAsGuest());
        }

        private void LoginAsGuest() => _navigationService.SwitchWindow(WindowType.Guest);
        private void Login()
        {
            var account = _loginService.Login(EnteredUsername, EnteredPassword);
            if (account is not null)
            {
                _navigationService.SwitchWindow(
                    account.Type switch
                    {
                        AccountType.Member => WindowType.Member,
                        AccountType.Volunteer => WindowType.Volunteer,
                        AccountType.Administrator => WindowType.Administrator,
                        _ => throw new ArgumentOutOfRangeException(nameof(account.Type), $"Unexpected account type: {account.Type}")
                    });
            }
        }
    }
}
