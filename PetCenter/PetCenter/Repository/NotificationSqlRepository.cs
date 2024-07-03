using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetCenter.Domain.Model;
using PetCenter.Domain.RepositoryInterfaces;

namespace PetCenter.Repository
{
    public class NotificationSqlRepository(DataContext dataContext) : INotificationRepository
    {
        private readonly SqlRepository<Notification> _sqlRepository = new(dataContext, dataContext.Notifications);
        public List<Notification> GetAll() => _sqlRepository.GetAll();
        public Notification? GetById(Guid id) => _sqlRepository.GetById(id);
        public bool Insert(Notification entity) => _sqlRepository.Insert(entity);
        public bool Delete(Notification entity) => _sqlRepository.Delete(entity);
        public bool Update(Notification entity) => _sqlRepository.Update(entity);

    }
}
