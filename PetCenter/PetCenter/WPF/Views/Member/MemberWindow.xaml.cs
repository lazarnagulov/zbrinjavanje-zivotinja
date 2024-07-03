using System.Windows;
using PetCenter.WPF.ViewModels.Member;

namespace PetCenter.WPF.Views.Member
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MemberWindow : Window
    {
        public MemberWindow(MemberViewModel viewModel)// : base(viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}