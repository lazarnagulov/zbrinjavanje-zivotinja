using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetCenter.Domain.Model
{
    public class Animal(AnimalType type, string name, int age, string description)
    {
        public AnimalType Type { get; set; } = type;
        public string Name { get; set; } = name;
        public int Age { get; set; } = age;
        public string Description { get; set; } = description;
        private readonly List<Photo> _photos = [];
        public IReadOnlyCollection<Photo> Photos => _photos;

        public void AddPhoto(Photo photo) => _photos.Add(photo);
        public void RemovePhoto(Photo photo) => _photos.Remove(photo);
    }
}
