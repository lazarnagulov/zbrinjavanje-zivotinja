using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PetCenter.Core.Util;
using PetCenter.Domain.Model;
using PetCenter.Domain.RepositoryInterfaces;

namespace PetCenter.Repository
{
    public class PersonSqlRepository(DataContext dataContext) : IPersonRepository
    {
        private readonly SqlRepository<Person> _sqlRepository = new(dataContext, dataContext.Persons);
        public List<Person> GetAll() => _sqlRepository.GetAll();
        public Person? GetById(Guid id) => _sqlRepository.GetById(id);

        public bool Insert(Person entity)
        {
            entity.Account.Person = entity;
            entity.Account.Password = PasswordEncoder.Encode(entity.Account.Password);
            return _sqlRepository.Insert(entity);
        }

        public bool Delete(Person entity) => _sqlRepository.Delete(entity);
        public bool Update(Person entity) => _sqlRepository.Update(entity);
    }
}
