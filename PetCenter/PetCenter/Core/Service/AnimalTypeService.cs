using PetCenter.Domain.Model;
using PetCenter.Domain.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetCenter.Core.Service
{
    public class AnimalTypeService(IAnimalTypeRepository animalTypeRepository)
    {
        public bool Insert(AnimalType post) => animalTypeRepository.Insert(post);
        public bool Delete(AnimalType post) => animalTypeRepository.Delete(post);
        public AnimalType? GetById(Guid id) => animalTypeRepository.GetById(id);
        public List<AnimalType> GetAll() => animalTypeRepository.GetAll();
    }
}
