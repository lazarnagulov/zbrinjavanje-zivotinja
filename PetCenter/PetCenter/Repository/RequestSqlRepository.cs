﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetCenter.Domain.Model;
using PetCenter.Domain.RepositoryInterfaces;

namespace PetCenter.Repository
{
    public class RequestSqlRepository(DataContext dataContext) : IRequestRepository
    {
        private readonly SqlRepository<Request> _sqlRepository = new(dataContext, dataContext.Requests);
        public List<Request> GetAll() => _sqlRepository.GetAll();
        public Request? GetById(Guid id) => _sqlRepository.GetById(id);
        public bool Insert(Request entity) => _sqlRepository.Insert(entity);
        public bool Delete(Request entity) => _sqlRepository.Delete(entity);
        public bool Update(Request entity) => _sqlRepository.Update(entity);
        public List<Request> GetAllIncluded() => dataContext.Requests.Include(r => r.Author).Include(r => r.Voters).ToList();
    }
}
