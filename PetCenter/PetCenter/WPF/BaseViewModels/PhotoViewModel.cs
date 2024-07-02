using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetCenter.Domain.Model;
using PetCenter.WPF.MVVM;

namespace PetCenter.WPF.BaseViewModels
{
    public class PhotoViewModel(Photo photo) : ViewModelBase
    {
        public Guid Id
        {
            get => _id;
            set => SetField(ref _id, value);
        }

        public string Description
        {
            get => _description;
            set => SetField(ref _description, value);
        }

        public string Url
        {
            get => _url;
            set => SetField(ref _url, value);
        }

        private Guid _id = photo.Id;
        private string _description = photo.Description;
        private string _url = photo.Url;
    }
}
