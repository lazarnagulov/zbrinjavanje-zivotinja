using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using PetCenter.Core.Service;
using PetCenter.Core.Util;
using PetCenter.WPF.BaseViewModels;
using PetCenter.WPF.MVVM;
using PetCenter.Domain.Model;

namespace PetCenter.WPF.ViewModels.Volunteer
{
    public class AnimalTypeCRUDViewModel : ViewModelBase
    {
        private readonly AnimalTypeService _animalTypeService;

        private INavigationService _navigationService;

        private ObservableCollection<AnimalTypeViewModel> _animalTypes;
        private AnimalTypeViewModel _selectedAnimalType;
        private AnimalTypeViewModel _newAnimalType;

        public ObservableCollection<AnimalTypeViewModel> AnimalTypes
        {
            get => _animalTypes;
            set => SetField(ref _animalTypes, value);
        }

        public AnimalTypeViewModel SelectedAnimalType
        {
            get => _selectedAnimalType;
            set => SetField(ref _selectedAnimalType, value);
        }

        public AnimalTypeViewModel NewAnimalType
        {
            get => _newAnimalType;
            set => SetField(ref _newAnimalType, value);
        }

        public ICommand AddAnimalTypeCommand { get; }
        public ICommand UpdateAnimalTypeCommand { get; }
        public ICommand DeleteAnimalTypeCommand { get; }

        public AnimalTypeCRUDViewModel(AnimalTypeService animalTypeService, INavigationService navigationService)
        {
            _animalTypeService = animalTypeService;
            _navigationService = navigationService;
            LoadAnimalTypes();

            NewAnimalType = new AnimalTypeViewModel(new AnimalType());

            AddAnimalTypeCommand = new RelayCommand(AddAnimalType, CanAddAnimalType);
            UpdateAnimalTypeCommand = new RelayCommand(UpdateAnimalType, CanUpdateOrDelete);
            DeleteAnimalTypeCommand = new RelayCommand(DeleteAnimalType, CanUpdateOrDelete);
        }

        private void LoadAnimalTypes()
        {
            AnimalTypes = new ObservableCollection<AnimalTypeViewModel>();
            foreach (var animalType in _animalTypeService.GetAll())
            {
                AnimalTypes.Add(new AnimalTypeViewModel(animalType));
            }
        }
        private bool CanAddAnimalType(object? obj)
        {
            return !string.IsNullOrWhiteSpace(NewAnimalType.Type) && !string.IsNullOrWhiteSpace(NewAnimalType.Breed);
        }
        private void AddAnimalType(object? obj)
        {
            var newAnimalType = new AnimalType(NewAnimalType.Type, NewAnimalType.Breed);
            _animalTypeService.Insert(newAnimalType);
            AnimalTypes.Add(new AnimalTypeViewModel(newAnimalType));
            NewAnimalType = new AnimalTypeViewModel(new AnimalType());
        }

        private void UpdateAnimalType(object? obj)
        {
            if (SelectedAnimalType == null) return;
        }

        private void DeleteAnimalType(object? obj)
        {
            if (SelectedAnimalType == null) return;

            _animalTypeService.Delete(SelectedAnimalType.ToModel());
            AnimalTypes.Remove(SelectedAnimalType);
        }

        private bool CanUpdateOrDelete(object? obj)
        {
            return SelectedAnimalType != null;
        }
    }
}
