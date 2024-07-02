using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetCenter.Domain.Model;

namespace PetCenter.WPF.BaseViewModels
{
    public class AnimalViewModel(Animal animal) : ViewModelBase
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

        public AnimalType Type
        {
            get => _type;
            set => SetField(ref _type, value);
        }

        public int Age
        {
            get => _age;
            set => SetField(ref _age, value);
        }

        public IReadOnlyCollection<Photo> Photos
        {
            get => _photos;
            set => SetField(ref _photos, value);
        }

        private Guid _id = animal.Id;
        private string _name = animal.Name;
        private string _description = animal.Description;
        private AnimalType _type = animal.Type;
        private IReadOnlyCollection<Photo> _photos = animal.Photos;
        private int _age = animal.Age;
    }
}
