using PetCenter.Core.Stores;
using PetCenter.Domain.Enumerations;
using PetCenter.WPF.ViewModels;
using PetCenter.WPF.Views;
using PetCenter.WPF.Views.Administrator;
using PetCenter.WPF.Views.Authentication;
using PetCenter.WPF.Views.Guest;
using PetCenter.WPF.Views.Volunteer;
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
            AuthenticationWindow authenticationWindow,
            GuestWindow guestWindow,
            MemberWindow memberWindow,
            VolunteerWindow volunteerWindow,
            AdministratorWindow administratorWindow) 
        {
            _windows = new Dictionary<WindowType, Window>()
            {
                [WindowType.Authentication] = authenticationWindow,
                [WindowType.Guest] = guestWindow,
                [WindowType.Member] = memberWindow,
                [WindowType.Volunteer] = volunteerWindow,
                [WindowType.Administrator] = administratorWindow
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
                WindowType.Authentication => ViewType.Login,
                WindowType.Member => ViewType.Test1,
                _ => throw new ArgumentException($"WindowType {type} doesn't have an associated first view")
            };
        }
    }
}
