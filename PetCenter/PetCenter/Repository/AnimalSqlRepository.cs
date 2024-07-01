﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetCenter.Domain.Model;
using PetCenter.Domain.RepositoryInterfaces;

namespace PetCenter.Repository
{
    public class AnimalSqlRepository(DataContext dataContext) : IAnimalRepository
    {
        private readonly SqlRepository<Animal> _sqlRepository = new(dataContext, dataContext.Animals);
        public Task<List<Animal>> GetAll() => _sqlRepository.GetAll();
        public Task<Animal?> GetById(Guid id) => _sqlRepository.GetById(id);
        public Task<bool> Insert(Animal entity) => _sqlRepository.Insert(entity);
        public Task<bool> Delete(Animal entity) => _sqlRepository.Delete(entity);
    }
}
