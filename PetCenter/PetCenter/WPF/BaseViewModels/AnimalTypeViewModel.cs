using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetCenter.Domain.Model;

namespace PetCenter.WPF.BaseViewModels
{
    public class AnimalTypeViewModel(AnimalType animalType) : ViewModelBase
    {
        public Guid Id
        {
            get => _id;
            set => SetField(ref _id, value);
        }

        public string Type
        {
            get => _type;
            set => SetField(ref _type, value);
        }

        public string Breed
        {
            get => _breed;
            set => SetField(ref _breed, value);
        }

        private Guid _id = animalType.Id;
        private string _type = animalType.Type;
        private string _breed = animalType.Breed;
    }
}
