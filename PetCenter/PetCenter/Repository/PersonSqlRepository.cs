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
    public class PersonSqlRepository(DataContext dataContext) : IPersonRepository
    {
        private readonly SqlRepository<Person> _sqlRepository = new(dataContext, dataContext.Persons);
        public Task<List<Person>> GetAll() => _sqlRepository.GetAll();
        public Task<Person?> GetById(Guid id) => _sqlRepository.GetById(id);
        public Task<bool> Insert(Person entity) => _sqlRepository.Insert(entity);
        public Task<bool> Delete(Person entity) => _sqlRepository.Delete(entity);
    }
}
