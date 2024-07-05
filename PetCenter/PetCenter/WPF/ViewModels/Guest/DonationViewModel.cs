using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetCenter.Core.Service;
using PetCenter.Domain.Model;
using PetCenter.Domain.RepositoryInterfaces;
using PetCenter.WPF.BaseViewModels;
using PetCenter.WPF.MVVM;

namespace PetCenter.WPF.ViewModels.Guest
{
    public class DonationViewModel(AssociationService associationService) : ViewModelBase
    {
        public AssociationViewModel Association { get; set; } = new(associationService.GetFirst()!);
    }
}
