using PetCenter.Core.Stores;
using PetCenter.Domain.Enumerations;
using PetCenter.WPF.MVVM;
using System.Windows;

namespace PetCenter.Core.Util
{
    public class NavigationService(NavigationStore navigationStore, IWindowFactory windowFactory, ViewModelFactory viewModelFactory) : INavigationService
    {
        public void SwitchWindow(WindowType target)
        {
            Window? previousWindow = navigationStore.CurrentWindow;
            navigationStore.CurrentWindow = windowFactory.CreateWindow(target);
            ViewType firstViewModelType = windowFactory.GetFirstViewModelType(target);
            navigationStore.CurrentWindow.Show();
            navigationStore.CurrentViewModel = viewModelFactory.CreateViewModel(firstViewModelType);
            previousWindow?.Close();
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
