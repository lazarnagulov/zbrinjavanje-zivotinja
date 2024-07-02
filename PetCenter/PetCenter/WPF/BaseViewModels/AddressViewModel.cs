using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetCenter.Domain.Model;

namespace PetCenter.WPF.BaseViewModels
{
    public class AddressViewModel(Address address) : ViewModelBase
    {
        public Guid Id
        {
            get => _id;
            set => SetField(ref _id, value);
        }

        public string Street
        {
            get => _street;
            set => SetField(ref _street, value);
        }

        public string City
        {
            get => _city;
            set => SetField(ref _city, value);
        }

        public string Country
        {
            get => _country;
            set => SetField(ref _country, value);
        }

        public int ZipCode
        {
            get => _zipCode;
            set => SetField(ref _zipCode, value);
        }

        private Guid _id = address.Id;
        private string _street = address.Street;
        private string _city = address.City;
        private string _country = address.Country;
        private int _zipCode = address.ZipCode;
    }
}
