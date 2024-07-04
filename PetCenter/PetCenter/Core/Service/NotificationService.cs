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
        public bool Insert(Notification notification) => notificationRepository.Insert(notification);
        public bool Delete(Notification notification) => notificationRepository.Delete(notification);
        public Notification? GetById(Guid id) => notificationRepository.GetById(id);
        public List<Notification> GetAll() => notificationRepository.GetAll();
        public bool SendNotification(Person recipient, string message)
        {
            Notification notification = new Notification(recipient, message);
            return Insert(notification);
        }
        public bool DeleteById(Guid id)
        {
            Notification? notification = GetById(id);
            if (notification == null)
                return false;
            return notificationRepository.Delete(notification);
        }

        public List<Notification> GetAllIncluded()
            => notificationRepository.GetAllIncluded();

        public List<Notification> GetAllForPerson(Person person)
            => notificationRepository.GetAllIncluded().Where(n => n.Recipient.Id == person.Id).ToList();
    }
}
