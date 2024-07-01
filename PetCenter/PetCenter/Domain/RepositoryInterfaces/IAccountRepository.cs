using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetCenter.Domain.Model;

namespace PetCenter.Domain.RepositoryInterfaces
{
    public interface IAccountRepository : ICrud<Account>
    {
        Account? Authenticate(string username, string encodedPassword);
    }
}
