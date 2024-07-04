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

        public RelayCommand UpdateCommand { get; }

        public PetCenterInfoViewModel(INavigationService navigationService, AssociationService associationService)
        {
            _navigationService = navigationService;
            _associationService = associationService;
            UpdateCommand = new RelayCommand(execute => Update());
            LoadFirstAssociation();
        }

        private void Update()
        {
            var association = new Association(Association.Name, Association.AccountNumber, Association.WebsiteLink);
            if (_associationService.UpdateById(Association.Id, association))
            {
                Feedback.SuccessfullyUpdatedInfo();
            }
            else
            {
                Feedback.UpdateInfoError();
            }
        }

        private void LoadFirstAssociation()
        {
            var firstAssociation = _associationService.GetFirst();
            if (firstAssociation != null)
            {
                Association = new AssociationViewModel(firstAssociation);
            }
        }
    }
}
