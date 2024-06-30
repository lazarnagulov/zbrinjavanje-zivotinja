using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetCenter.Domain.Model
{
    [Table("animaltype")]
    public class AnimalType
    {
        public AnimalType()
        {
        }

        public AnimalType(string type, string race)
        {
            Type = type;
            Race = race;
        }

        [Key]
        [Column("id_animaltype")]
        public Guid Id { get; set; } = Guid.NewGuid();

        [MaxLength(30)]
        [Required]
        [Column("typename")]
        public string Type { get; set; }

        [MaxLength(30)]
        [Required]
        [Column("race")]
        public string Race { get; set; }
    }
}
