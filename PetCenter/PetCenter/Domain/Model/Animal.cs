using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetCenter.Domain.Model
{
    [Table("animal")]
    public class Animal
    {
        public Animal()
        {

        }
        public Animal(AnimalType type, string name, int age, string description)
        {
            Type = type;
            Name = name;
            Age = age;
            Description = description;
        }

        [Key]
        [Column("id_animal")]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey("animaltype_id_type")]
        public AnimalType Type { get; set; }
        
        [MaxLength(30)]
        [Required]
        [Column("name_a")]
        public string Name { get; set; }
        [Required]
        [Column("age_a")]
        public int Age { get; set; }

        [MaxLength(300)]
        [Required]
        [Column("desc_a")]
        public string Description { get; set; }
        private readonly List<Photo> _photos = [];

        public IReadOnlyCollection<Photo> Photos => _photos;
        
        public void AddPhoto(Photo photo) => _photos.Add(photo);
        public void RemovePhoto(Photo photo) => _photos.Remove(photo);
    }
}
