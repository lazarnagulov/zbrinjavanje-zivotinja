using PetCenter.Core.Stores;
using PetCenter.Core.Util;
using PetCenter.Domain.Enumerations;
using PetCenter.WPF.MVVM;
using PetCenter.WPF.ViewModels.Member;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using PetCenter.Core.Service;
using PetCenter.Domain.Model;
using PetCenter.Domain.RepositoryInterfaces;
using PetCenter.WPF.BaseViewModels;

namespace PetCenter.WPF.ViewModels.Authentication
{
    public class RegisterViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly PersonService _personService;

        private PersonViewModel _person = new(new Person());
        public PersonViewModel Person
        {
            get => _person;
            set => SetField(ref _person, value);
        }

        public Array Genders => Enum.GetNames(typeof(Gender));
        public NavigationCommand<LoginViewModel> ToLoginCommand { get; }
        public RelayCommand RegisterCommand { get; }

        public RegisterViewModel(INavigationService navigationService, PersonService personService)
        {
            _personService = personService;
            _navigationService = navigationService;
            ToLoginCommand = navigationService.CreateNavCommand<LoginViewModel>(ViewType.Login);
            RegisterCommand = new RelayCommand(execute => Register(), CanRegister);
        }

        private bool CanRegister(object? arg)
            => !string.IsNullOrEmpty(Person.Name) &&
               !string.IsNullOrEmpty(Person.Surname) &&
               !string.IsNullOrEmpty(Person.PhoneNumber) &&
               !string.IsNullOrEmpty(Person.Address.City) &&
               !string.IsNullOrEmpty(Person.Address.Country) &&
               !string.IsNullOrEmpty(Person.Address.Street) &&
               !string.IsNullOrEmpty(Person.Account.Email) &&
               !string.IsNullOrEmpty(Person.Account.Password) &&
               !string.IsNullOrEmpty(Person.Account.Username);
        
        public void Register()
        {
            Person.Account.Type = AccountType.Member;
            var address = new Address(Person.Address.Street, Person.Address.Number, Person.Address.City,
                Person.Address.Country, Person.Address.ZipCode);
            var person = new Person(Person.Account, Person.Name, Person.Surname, Person.PhoneNumber, Person.Gender,
                Person.BirthDate, address);

            if (_personService.Insert(person))
            {
                MessageBox.Show("Successfully created an account!");
            }
            ToLoginCommand.Execute(null);
        }
    }
}
