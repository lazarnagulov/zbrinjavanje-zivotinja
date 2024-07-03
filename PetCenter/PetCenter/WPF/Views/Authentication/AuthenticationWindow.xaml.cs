using PetCenter.Core.Stores;
using PetCenter.WPF.MVVM;
using PetCenter.WPF.ViewModels.Authentication;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PetCenter.WPF.Views.Authentication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class AuthenticationWindow : Window
    {
        public AuthenticationWindow(AuthenticationViewModel viewModel)// : base(viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}