using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetCenter.Domain.Model;
using PetCenter.Domain.RepositoryInterfaces;

namespace PetCenter.Core.Service
{
    public class PersonService(IPersonRepository personRepository)
    {
        public bool Insert(Person person) => personRepository.Insert(person);
        public bool Delete(Person person) => personRepository.Delete(person);
        public Person? GetById(Guid id) => personRepository.GetById(id);
        public List<Person> GetAll() => personRepository.GetAll();
    }
}
