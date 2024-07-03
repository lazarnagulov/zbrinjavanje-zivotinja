using PetCenter.Domain.Model;
using PetCenter.Domain.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetCenter.Core.Service
{
    public class NotificationService(INotificationRepository notificationRepository)
    {
        public bool Insert(Notification post) => notificationRepository.Insert(post);
        public bool Delete(Notification post) => notificationRepository.Delete(post);
        public Notification? GetById(Guid id) => notificationRepository.GetById(id);
        public List<Notification> GetAll() => notificationRepository.GetAll();
    }
}
