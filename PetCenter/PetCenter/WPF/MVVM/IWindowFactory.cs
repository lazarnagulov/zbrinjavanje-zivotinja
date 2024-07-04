using PetCenter.Domain.Enumerations;
using System.Windows;

namespace PetCenter.WPF.MVVM
{
    public interface IWindowFactory
    {
        public ViewType GetFirstViewModelType(WindowType type);
        public Window CreateWindow(WindowType type);
    }
}