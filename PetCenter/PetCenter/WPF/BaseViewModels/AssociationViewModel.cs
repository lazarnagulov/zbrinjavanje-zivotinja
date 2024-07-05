using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetCenter.Domain.Model;
using PetCenter.WPF.MVVM;

namespace PetCenter.WPF.BaseViewModels
{
    public class AssociationViewModel(Association association) : ViewModelBase
    {
        public string Name
        {
            get => _name;
            set => SetField(ref _name, value);
        }

        public string AccountNumber
        {
            get => _accountNumber;
            set => SetField(ref _name, value);
        }

        public string? WebsiteLink
        {
            get => _websiteLink;
            set => SetField(ref _websiteLink, value);
        }

        private string _name = association.Name;
        private string _accountNumber = association.AccountNumber;
        private string? _websiteLink = association.WebsiteLink;
    }
}
