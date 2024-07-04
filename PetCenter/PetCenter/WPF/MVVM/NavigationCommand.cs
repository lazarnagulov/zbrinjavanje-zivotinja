using PetCenter.Core.Stores;

namespace PetCenter.WPF.MVVM
{
    public class NavigationCommand<TViewModel> : CommandBase where TViewModel : ViewModelBase
    {
        private readonly NavigationStore _navigationStore;
        private readonly CreateViewModel<TViewModel> _createViewModel;
        public NavigationCommand(NavigationStore navigationStore, CreateViewModel<TViewModel> createViewModel)
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
