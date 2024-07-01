using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetCenter.Domain.Enumerations;
using PetCenter.Domain.Model;

namespace PetCenter.WPF.BaseViewModels
{
    public class PersonViewModel(Person person) : ViewModelBase
    {
        public Guid Id
        {
            get => _id;
            set
            {
                _id = value;
                OnPropertyChanged();
            }
        }

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        public string Surname
        {
            get => _surname;
            set
            {
                _surname = value;
                OnPropertyChanged();
            }
        }

        public string PhoneNumber
        {
            get => _phoneNumber;
            set
            {
                _phoneNumber = value;
                OnPropertyChanged();
            }
        }

        public Gender Gender
        {
            get => _gender;
            set
            {
                _gender = value;
                OnPropertyChanged();
            }
        }

        public DateOnly BirthDate
        {
            get => _birthDate;
            set
            {
                _birthDate = value;
                OnPropertyChanged();
            }
        }

        public Address Address
        {
            get => _address;
            set
            {
                _address = value;
                OnPropertyChanged();
            }
        }


        private Guid _id = person.Id;
        private string _name = person.Name;
        private string _surname = person.Surname;
        private string _phoneNumber = person.PhoneNumber;
        private Gender _gender = person.Gender;
        private DateOnly _birthDate = person.BirthDate;
        private Address _address = person.Address;
    }
}
