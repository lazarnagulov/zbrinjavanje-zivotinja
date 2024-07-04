using PetCenter.WPF.BaseViewModels;
using PetCenter.WPF.MVVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetCenter.Domain.Model;
using PetCenter.Core.Util;
using PetCenter.Core.Service;
using PetCenter.Domain.Enumerations;

namespace PetCenter.WPF.ViewModels.Administrator
{
    public class PetCenterInfoViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly AssociationService _associationService;

        private AssociationViewModel _association = new(new Association());
        public AssociationViewModel Association
        {
            get => _association;
            set => SetField(ref _association, value);
        }

        public NavigationCommand<AdministratorViewModel> ToAdministratorWindowCommand { get; }
        public RelayCommand UpdateCommand;

        public PetCenterInfoViewModel(INavigationService navigationService, AssociationService associationService)
        {
            _navigationService = navigationService;
            _associationService = associationService;
            ToAdministratorWindowCommand = _navigationService.CreateNavCommand<AdministratorViewModel>(ViewType.Administrator);
            UpdateCommand = new RelayCommand(execute => Update());
            LoadFirstAssociation();
        }

        private void Update()
        {
            Association association = new Association(Association.Name, Association.AccountNumber, Association.WebsiteLink);
            _associationService.Update(association);
        }

        private void LoadFirstAssociation()
        {
            var firstAssociation = _associationService.GetFirst();
            if (firstAssociation != null)
            {
                Association.Name = firstAssociation.Name;
                Association.AccountNumber = firstAssociation.AccountNumber;
                Association.WebsiteLink = firstAssociation.WebsiteLink;
            }
        }
    }
}
