using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using PetCenter.Core.Stores;
using PetCenter.Core.Util;
using PetCenter.Domain.Model;
using PetCenter.Domain.RepositoryInterfaces;

namespace PetCenter.Core.Service
{
    public class LoginService(IAccountRepository accountRepository, AuthenticationStore authenticationStore)
    {
        public Account? Login(string username, string password)
        {
            var account = accountRepository.Authenticate(username, password);
            authenticationStore.CurrentUserProfile = account;
            return account;
        }
    }
}
