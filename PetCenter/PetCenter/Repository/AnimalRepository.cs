using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetCenter.Domain.Model;
using PetCenter.Domain.RepositoryInterfaces;

namespace PetCenter.Repository
{
    public class AnimalRepository(DataContext dataContext) : IAnimalRepository
    {
        private readonly SqlRepository<Animal> _sqlRepository = new(dataContext, dataContext.Animals);
        public List<Animal> GetAll() => _sqlRepository.GetAll();
        public Animal? GetById(Guid id) => _sqlRepository.GetById(id);
        public bool Insert(Animal entity) => _sqlRepository.Insert(entity);
        public bool Delete(Animal entity) => _sqlRepository.Delete(entity);
    }
}
