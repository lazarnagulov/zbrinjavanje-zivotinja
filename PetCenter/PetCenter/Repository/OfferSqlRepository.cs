using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetCenter.Domain.Model;
using PetCenter.Domain.RepositoryInterfaces;

namespace PetCenter.Repository
{
    public class OfferSqlRepository(DataContext dataContext) : IOfferRepository
    {
        private readonly SqlRepository<Offer> _sqlRepository = new(dataContext, dataContext.Offers);
        public Task<List<Offer>> GetAll() => _sqlRepository.GetAll();
        public Task<Offer?> GetById(Guid id) => _sqlRepository.GetById(id);
        public Task<bool> Insert(Offer entity) => _sqlRepository.Insert(entity);
        public Task<bool> Delete(Offer entity) => _sqlRepository.Delete(entity);
    }
}
