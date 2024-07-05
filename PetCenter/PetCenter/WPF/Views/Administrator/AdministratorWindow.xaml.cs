using PetCenter.WPF.ViewModels.Administrator;
using PetCenter.WPF.ViewModels.Member;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PetCenter.WPF.Views.Administrator
{
    /// <summary>
    /// Interaction logic for AdministratorWindow.xaml
    /// </summary>
    public partial class AdministratorWindow : Window
    {
        public AdministratorWindow(AdministratorViewModel viewModel)// : base(viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
