using System;
using System.Collections.Generic;
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
        public Task<List<Request>> GetAll() => _sqlRepository.GetAll();
        public Task<Request?> GetById(Guid id) => _sqlRepository.GetById(id);
        public Task<bool> Insert(Request entity) => _sqlRepository.Insert(entity);
        public Task<bool> Delete(Request entity) => _sqlRepository.Delete(entity);
    }
}
