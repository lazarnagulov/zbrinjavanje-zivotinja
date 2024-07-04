using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetCenter.Domain.Model;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PetCenter.Core.Stores
{
    public class AuthenticationStore
    {
        public Account? CurrentUserProfile { get; set; }
        public Person? LoggedUser => CurrentUserProfile?.Person;
        public bool IsLoggedIn => CurrentUserProfile is not null;

        public void Logout()
        {
            CurrentUserProfile = null;
        }
    }
}
