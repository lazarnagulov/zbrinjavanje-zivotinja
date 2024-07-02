using System;
using PetCenter.Core.Stores;
using PetCenter.WPF.MVVM;

namespace PetCenter.WPF.Command
{
    public class NavigationCommand<TViewModel> : CommandBase where TViewModel : ViewModelBase
    {
        private readonly NavigationStore _navigationStore;
        private readonly Func<TViewModel> _createViewModel;
        public NavigationCommand(NavigationStore navigationStore, Func<TViewModel> createViewModel)
        {
            _navigationStore = navigationStore;
            _createViewModel = createViewModel;
        }
        public override void Execute(object? parameter)
        {
            _navigationStore.CurrentViewModel = _createViewModel();
        }
    }
}
