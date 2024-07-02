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
    public class WindowFactory
    {
        private readonly Dictionary<WindowType, Window> _windows;
        public WindowFactory(
            LoginWindow loginWindow,
            MemberWindow memberWindow)
        {
            _windows = new Dictionary<WindowType, Window>()
            {
                [WindowType.Login] = loginWindow,
                [WindowType.Member] = memberWindow
            };
        }

        public Window GetWindow(WindowType type)
        {
            if (_windows.TryGetValue(type, out Window? value))
                return value;
            else
                throw new ArgumentException($"WindowType {type} doesn't have an associated window");
        }

        public ViewType GetFirstViewModelType(WindowType type)
        {
            return type switch
            {
                WindowType.Login => ViewType.Test1,
                WindowType.Member => ViewType.Test2,
                _ => throw new ArgumentException($"WindowType {type} doesn't have an associated first view")
            };
        }
    }
}
