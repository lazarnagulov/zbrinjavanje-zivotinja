using PetCenter.Core.Stores;
using PetCenter.Domain.Enumerations;
using PetCenter.WPF.ViewModels;
using PetCenter.WPF.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PetCenter.WPF.MVVM
{
    public class ViewModelFactory(
        CreateViewModel<Test1ViewModel> createTest1ViewModel,
        CreateViewModel<Test2ViewModel> createTest2ViewModel
        )
    {
        public CreateViewModel<T> GetCreateViewModel<T>(ViewType type) where T : ViewModelBase
        {
            return type switch
            {
                ViewType.Test1 => (createTest1ViewModel as CreateViewModel<T>)!,
                ViewType.Test2 => (createTest2ViewModel as CreateViewModel<T>)!,
                _ => throw new ArgumentException($"ViewType {type} doesn't have an associated ViewModel")
            };
        }
        public ViewModelBase CreateViewModel(ViewType type)
        {
            return type switch
            {
                ViewType.Test1 => createTest1ViewModel(),
                ViewType.Test2 => createTest2ViewModel(),
                _ => throw new ArgumentException($"ViewType {type} doesn't have an associated ViewModel")
            };
        }
    }
}
