using PetCenter.Core.Service;
using PetCenter.Domain.Model;
using PetCenter.Repository;
using PetCenter.WPF.BaseViewModels;
using PetCenter.WPF.MVVM;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using PetCenter.Domain.Enumerations;
using PetCenter.Domain.State;
using System.Windows;
using Microsoft.Extensions.Hosting;
using PetCenter.Core.Stores;

namespace PetCenter.WPF.ViewModels.Member
{
    public class NotificationListingViewModel : ViewModelBase
    {
        private readonly NotificationService _notificationService;
        private readonly AuthenticationStore _authenticationStore;

        private ObservableCollection<NotificationViewModel> _notifications = new();
        public ObservableCollection<NotificationViewModel> Notifications
        {
            get => _notifications;
            set => SetField(ref _notifications, value);
        }
        public ICommand DeleteNotificationCommand { get; }

        public NotificationListingViewModel(NotificationService notificationService, AuthenticationStore authenticationStore)
        {
            _notificationService = notificationService;
            _authenticationStore = authenticationStore;
            LoadNotifications();

            DeleteNotificationCommand = new RelayCommand<NotificationViewModel>(DeleteNotification);
        }

        private void LoadNotifications()
        {
            Notifications = new();
            if (_authenticationStore.LoggedUser != null)
                foreach (var notification in _notificationService.GetAllForPerson(_authenticationStore.LoggedUser))
                    Notifications.Add(new NotificationViewModel(notification));
        }

        private void DeleteNotification(object? obj)
        {
            if (obj is NotificationViewModel notificationViewModel)
            {
                _notificationService.DeleteById(notificationViewModel.Id);
                LoadNotifications();
            }
        }


    }
}
