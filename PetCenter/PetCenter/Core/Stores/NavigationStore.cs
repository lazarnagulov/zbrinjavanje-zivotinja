using System;
using PetCenter.WPF.ViewModels;
using PetCenter.WPF.MVVM;
using System.Windows;

namespace PetCenter.Core.Stores
{
    public class NavigationStore
    {
        public event Action CurrentViewModelChanged = default!;
        
        public Window? CurrentWindow { get; set; } = null;
        private ViewModelBase _currentViewModel = default!;
        public ViewModelBase CurrentViewModel
        {
            get => _currentViewModel;
            set
            {
                _currentViewModel = value;
                OnCurrentViewModelChanged();
            }
        }
        private void OnCurrentViewModelChanged()
        {
            CurrentViewModelChanged?.Invoke();
        }
        public NavigationStore() { }
        public NavigationStore(ViewModelBase viewModel)
        {
            CurrentViewModel = viewModel;
        }
    }
}
