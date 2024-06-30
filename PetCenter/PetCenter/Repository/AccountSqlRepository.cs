using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PetCenter.Domain.Model;
using PetCenter.Domain.RepositoryInterfaces;

namespace PetCenter.Repository
{
    public class AccountSqlRepository(DataContext dataContext) : IAccountRepository
    {
        private readonly SqlRepository<Account> _sqlRepository = new(dataContext, dataContext.Accounts);
        public Task<List<Account>> GetAll() => _sqlRepository.GetAll();
        public Task<Account?> GetById(Guid id) => _sqlRepository.GetById(id);
        public Task<bool> Insert(Account entity) => _sqlRepository.Insert(entity);
        public Task<bool> Delete(Account entity) => _sqlRepository.Delete(entity);
    }
}
