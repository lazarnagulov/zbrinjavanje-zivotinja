using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using PetCenter.Core.Util;
using PetCenter.Domain.Model;
using PetCenter.Domain.RepositoryInterfaces;

namespace PetCenter.Core.Service
{
    public class LoginService(IAccountRepository accountRepository)
    {
        public Account? LoginUser(string username, string password)
            => accountRepository.Authenticate(username, PasswordEncoder.Encode(password));

    }
}
