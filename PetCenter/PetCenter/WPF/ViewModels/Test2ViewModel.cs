using PetCenter.Core.Stores;
using PetCenter.WPF.Command;
using PetCenter.WPF.MVVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PetCenter.WPF.ViewModels
{
    public class Test2ViewModel : ViewModelBase
    {
        public NavigationCommand<Test1ViewModel> NavigateCommand { get; }
        public Test2ViewModel(NavigationStore navigationStore)
        {
            NavigateCommand = new NavigationCommand<Test1ViewModel>(navigationStore,
                () => new Test1ViewModel(navigationStore));
        }
    }
}
