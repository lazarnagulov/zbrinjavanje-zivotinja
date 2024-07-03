using Microsoft.Extensions.DependencyInjection;
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
    public class WindowFactory : IWindowFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public WindowFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public Window CreateWindow(WindowType type)
        {
            return type switch
            {
                WindowType.Authentication => _serviceProvider.GetRequiredService<AuthenticationWindow>(),
                WindowType.Guest => _serviceProvider.GetRequiredService<GuestWindow>(),
                WindowType.Member => _serviceProvider.GetRequiredService<MemberWindow>(),
                WindowType.Volunteer => _serviceProvider.GetRequiredService<VolunteerWindow>(),
                WindowType.Administrator => _serviceProvider.GetRequiredService<AdministratorWindow>(),
                _ => throw new ArgumentException($"WindowType {type} doesn't have an associated window")
            };
        }

        public ViewType GetFirstViewModelType(WindowType type)
        {
            return type switch
            {
                WindowType.Authentication => ViewType.Login,
                WindowType.Guest => ViewType.PostListing,
                WindowType.Member => ViewType.PostListing,
                WindowType.Volunteer => ViewType.PostListing,
                WindowType.Administrator => ViewType.PostListing,
                _ => throw new ArgumentException($"WindowType {type} doesn't have an associated first view")
            };
        }
    }
}
