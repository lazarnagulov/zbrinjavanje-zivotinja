using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetCenter.Domain.Enumerations;
using PetCenter.Domain.Model;
using PetCenter.WPF.MVVM;

namespace PetCenter.WPF.BaseViewModels
{
    public class NotificationViewModel(Notification notification) : ViewModelBase
    {
        public Guid Id
        {
            get => _id;
            set => SetField(ref _id, value);
        }

        public Person Recipient
        {
            get => _recipient;
            set => SetField(ref _recipient, value);
        }

        public string Message
        {
            get => _message;
            set => SetField(ref _message, value);
        }

        private Guid _id = notification.Id;
        private Person _recipient = notification.Recipient;
        private string _message = notification.Message;
    }
}
