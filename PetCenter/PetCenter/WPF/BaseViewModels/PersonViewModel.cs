using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetCenter.Domain.Enumerations;
using PetCenter.Domain.Model;
using PetCenter.WPF.MVVM;

namespace PetCenter.WPF.BaseViewModels
{
    public class PersonViewModel(Person person) : ViewModelBase
    {
        public Guid Id
        {
            get => _id;
            set => SetField(ref _id, value);
        }

        public string Name
        {
            get => _name;
            set => SetField(ref _name, value);
        }

        public string Surname
        {
            get => _surname;
            set => SetField(ref _surname, value);
        }

        public string PhoneNumber
        {
            get => _phoneNumber;
            set => SetField(ref _phoneNumber, value);
        }

        public Gender Gender
        {
            get => _gender;
            set => SetField(ref _gender, value);
        }

        public DateTime BirthDate
        {
            get => _birthDate;
            set => SetField(ref _birthDate, value);
        }

        public AddressViewModel Address
        {
            get => _address;
            set => SetField(ref _address, value);
        }

        public Account Account
        {
            get => _account;
            set => SetField(ref _account, value);
        }

        private Guid _id = person.Id;
        private string _name = person.Name;
        private string _surname = person.Surname;
        private string _phoneNumber = person.PhoneNumber;
        private Gender _gender = person.Gender;
        private DateTime _birthDate = person.BirthDate.ToDateTime(TimeOnly.MinValue);
        private AddressViewModel _address = new(person.Address);
        private Account _account = person.Account;
    }
}
