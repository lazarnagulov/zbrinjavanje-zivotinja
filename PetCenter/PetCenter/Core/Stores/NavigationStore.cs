using System;
using PetCenter.WPF.ViewModels;
using PetCenter.WPF.MVVM;

namespace PetCenter.Core.Stores
{
    public class NavigationStore
    {
        public event Action CurrentViewModelChanged = default!;

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
