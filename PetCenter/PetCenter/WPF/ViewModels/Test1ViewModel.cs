using LangLang.WPF.MVVM;
using PetCenter.Core.Stores;
using PetCenter.WPF.Command;
using PetCenter.WPF.MVVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetCenter.WPF.ViewModels
{
    public class Test1ViewModel : ViewModelBase
    {
        public NavigationCommand<Test2ViewModel> NavigateCommand { get; }
        public Test1ViewModel(NavigationStore navigationStore)
        {
            NavigateCommand = new NavigationCommand<Test2ViewModel>(navigationStore,
                () => new Test2ViewModel(navigationStore));
        }

        /*public void Navigate(string? destination)
        {
            ArgumentNullException.ThrowIfNull(destination);
            switch (destination)
            {
                case "test":
                    Navigate("a");
                    break;
            }
        }*/

    }
}
