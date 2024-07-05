using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetCenter.Domain.Model;
using PetCenter.Domain.RepositoryInterfaces;

namespace PetCenter.Repository
{
    public class AssociationSqlRepository(DataContext dataContext) : IAssociationRepository
    {
        private readonly SqlRepository<Association> _sqlRepository = new(dataContext, dataContext.Associations);
        public List<Association> GetAll() => _sqlRepository.GetAll();
        public Association? GetById(Guid id) => _sqlRepository.GetById(id);
        public bool Insert(Association entity) => _sqlRepository.Insert(entity);
        public bool Delete(Association entity) => _sqlRepository.Delete(entity);
        public bool Update(Association entity) => _sqlRepository.Update(entity);
        public Association? GetFirst() => _sqlRepository.GetAll().FirstOrDefault();
    }
}
