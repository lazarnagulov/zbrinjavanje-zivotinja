using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using PetCenter.Domain.Model;
using PetCenter.WPF.MVVM;

namespace PetCenter.WPF.BaseViewModels
{
    public class AnimalViewModel : ViewModelBase
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

        public string Description
        {
            get => _description;
            set => SetField(ref _description, value);
        }

        public AnimalType? Type
        {
            get => _type;
            set => SetField(ref _type, value);
        }

        public int Age
        {
            get => _age;
            set => SetField(ref _age, value);
        }

        public ObservableCollection<PhotoViewModel> Photos
        {
            get => _photos;
            set => SetField(ref _photos, value);
        }

        public PhotoViewModel NewPhoto
        {
            get => _newPhoto;
            set => SetField(ref _newPhoto, value);
        }

        private Guid _id;
        private string _name;
        private string _description;
        private AnimalType? _type;
        private ObservableCollection<PhotoViewModel> _photos;
        private int _age;
        private PhotoViewModel _newPhoto = new(new Photo());

        public AnimalViewModel(Animal animal)
        {
            _id = animal.Id;
            _name = animal.Name;
            _description = animal.Description;
            _type = animal.Type;
            _age = animal.Age;
            _photos = new();
            foreach (var photo in animal.Photos)
            {
                _photos.Add(new PhotoViewModel(photo));
            }
        }
    }
}
