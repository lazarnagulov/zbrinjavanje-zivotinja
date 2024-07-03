using PetCenter.Domain.Enumerations;
using PetCenter.WPF.Command;
using PetCenter.WPF.MVVM;

namespace PetCenter.Core.Util
{
    public interface INavigationService
    {
        NavigationCommand<T> CreateNavCommand<T>(ViewType type) where T : ViewModelBase;
        void Exit();
        void SwitchWindow(WindowType target);
    }
}