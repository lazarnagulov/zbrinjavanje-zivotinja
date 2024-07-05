using PetCenter.Domain.Model;
using PetCenter.WPF.MVVM;
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
        public Guid Id
        {
            get => _id;
            set => SetField(ref _id, value);
        }

        public string Name
        {
            get => _name;
            set => SetField(ref _name, value);
        }

        public string AccountNumber
        {
            get => _accountNumber;
            set => SetField(ref _accountNumber, value);
        }

        public string? WebsiteLink
        {
            get => _websiteLink;
            set => SetField(ref _websiteLink, value);
        }

        private Guid _id = association.Id;
        private string _name = association.Name;
        private string _accountNumber = association.AccountNumber;
        private string? _websiteLink = association.WebsiteLink;
    }
}
