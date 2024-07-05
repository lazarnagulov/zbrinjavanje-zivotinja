using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetCenter.Domain.Model
{
    [Table("animal_type")]
    public class AnimalType
    {
        public AnimalType()
        {
        }

        public AnimalType(string type, string breed)
        {
            Type = type;
            Breed = breed;
        }

        [Key]
        [Column("id_animal_type")]
        public Guid Id { get; set; } = Guid.NewGuid();

        [MaxLength(30)]
        [Required]
        [Column("typename")]
        public string Type { get; set; }

        [MaxLength(30)]
        [Required]
        [Column("breed")]
        public string Breed { get; set; }

        public override string ToString() => $"{Type} ({Breed})";
    }
}
