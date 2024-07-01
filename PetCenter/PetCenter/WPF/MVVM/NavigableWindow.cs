using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PetCenter.WPF.MVVM
{
    public abstract class NavigableWindow : Window
    {
        ViewModelBase? currentViewModel;
        public NavigableWindow(ViewModelBase viewModel)
        {
            currentViewModel = viewModel;
        }
    }
}
