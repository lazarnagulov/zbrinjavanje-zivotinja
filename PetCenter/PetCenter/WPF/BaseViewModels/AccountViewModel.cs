using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetCenter.Domain.Model;

namespace PetCenter.WPF.BaseViewModels
{
    public class AccountViewModel(Account account) : ViewModelBase
    {
        public Guid Id
        {
            get => _id;
            set => SetField(ref _id, value);
        }

        public string Username
        {
            get => _username;
            set => SetField(ref _username, value);
        }

        public string Email
        {
            get => _email;
            set => SetField(ref _email, value);
        }

        public string Password
        {
            get => _password;
            set => SetField(ref _password, value);
        }

        public Person? Person
        {
            get => _person;
            set => SetField(ref _person, value);
        }

        private Guid _id = account.Id;
        private string _username = account.Username;
        private string _email = account.Email;
        private string _password = account.Password;
        private Person? _person = account.Person;
    }
}
