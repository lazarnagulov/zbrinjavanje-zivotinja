using PetCenter.Core.Stores;
using PetCenter.Domain.Enumerations;
using PetCenter.WPF.Command;
using PetCenter.WPF.MVVM;
using PetCenter.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PetCenter.Core.Util
{
    public class NavigationService(NavigationStore navigationStore, WindowFactory windowFactory, ViewModelFactory viewModelFactory)
    {
        public void SwitchWindow(WindowType target)
        {
            Window? previousWindow = navigationStore.CurrentWindow;
            navigationStore.CurrentWindow = windowFactory.GetWindow(target);
            ViewType firstViewModelType = windowFactory.GetFirstViewModelType(target);
            navigationStore.CurrentWindow.Show();
            navigationStore.CurrentViewModel = viewModelFactory.CreateViewModel(firstViewModelType);
            previousWindow?.Hide();
        }

        public void Exit()
        {
            navigationStore.CurrentWindow?.Close();
        }

        public NavigationCommand<T> CreateNavCommand<T>(ViewType type) where T : ViewModelBase
        {
            return new NavigationCommand<T>(navigationStore, viewModelFactory.GetCreateViewModel<T>(type));
        }
    }
}
