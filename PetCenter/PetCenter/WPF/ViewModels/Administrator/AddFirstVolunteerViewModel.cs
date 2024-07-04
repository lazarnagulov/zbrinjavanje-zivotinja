using PetCenter.Core.Service;
using PetCenter.Core.Util;
using PetCenter.WPF.BaseViewModels;
using PetCenter.WPF.MVVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetCenter.Domain.Model;
using PetCenter.Domain.Enumerations;
using System.Windows;

namespace PetCenter.WPF.ViewModels.Administrator
{
    public class AddFirstVolunteerViewModel : ViewModelBase
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
        public RelayCommand AddCommand { get; }

        public AddFirstVolunteerViewModel(INavigationService navigationService, PersonService personService)
        {
            _navigationService = navigationService;
            _personService = personService;
            AddCommand = new RelayCommand(execute => Register(AccountType.Volunteer), CanRegister);
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

        public void Register(AccountType type)
        {
            Person.Account.Type = type;
            var address = new Address(Person.Address.Street, Person.Address.Number, Person.Address.City,
                Person.Address.Country, Person.Address.ZipCode);
            var person = new Person(Person.Account, Person.Name, Person.Surname, Person.PhoneNumber, Person.Gender,
                Person.BirthDate, address);

            if (_personService.Insert(person))
            {
                MessageBox.Show("Successfully created an account!");
            }
            AddCommand.Execute(null);
        }
    }
}
