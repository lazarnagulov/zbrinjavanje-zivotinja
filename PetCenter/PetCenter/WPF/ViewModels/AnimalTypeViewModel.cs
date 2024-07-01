using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetCenter.Domain.Model;

namespace PetCenter.WPF.ViewModels
{
    public class AnimalTypeViewModel(AnimalType animalType) : ViewModelBase
    {
        public Guid Id { 
            get => _id;
            set
            {
                _id = value;
                OnPropertyChanged();
            }
        }

        public string Type
        {
            get => _type;
            set
            {
                _type = value;
                OnPropertyChanged();
            }
        }

        public string Breed
        {
            get => _breed;
            set
            {
                _breed = value;
                OnPropertyChanged();
            }
        }

        private Guid _id = animalType.Id;
        private string _type = animalType.Type;
        private string _breed = animalType.Breed;
    }
}
