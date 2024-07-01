using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetCenter.Domain.Model
{
    [Table("address")]
    public class Address
    {
        public Address()
        {
        }

        public Address(string street, int number, string city, string country, int zipCode)
        {
            Street = street;
            Number = number;
            City = city;
            Country = country;
            ZipCode = zipCode;
        }

        [Key]
        [Column("id_adr")]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Column("street")]
        [Required]
        [MaxLength(30)]
        public string Street { get; set; }
        
        [Column("number")]
        public int Number { get; set; }

        [Column("city")]
        [Required]
        [MaxLength(30)]
        public string City { get; set; }

        [Column("country")]
        [Required]
        [MaxLength(30)]
        public string Country { get; set; }

        [Column("zipcode")]
        [Required]
        public int ZipCode { get; set; }
    }
}
