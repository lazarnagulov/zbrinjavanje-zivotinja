using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetCenter.Domain.Model;
using PetCenter.Domain.RepositoryInterfaces;

namespace PetCenter.Repository
{
    public class AnimalTypeSqlRepository(DataContext dataContext) : IAnimalTypeRepository
    {
        private readonly SqlRepository<AnimalType> _sqlRepository = new(dataContext, dataContext.AnimalTypes);
        public List<AnimalType> GetAll() => _sqlRepository.GetAll();
        public AnimalType? GetById(Guid id) => _sqlRepository.GetById(id);
        public bool Insert(AnimalType entity) => _sqlRepository.Insert(entity);
        public bool Delete(AnimalType entity) => _sqlRepository.Delete(entity);
        public bool Update(AnimalType entity) => _sqlRepository.Update(entity);
    }
}
