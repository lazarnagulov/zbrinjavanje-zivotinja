using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetCenter.Domain.Enumerations;

namespace PetCenter.Domain.Model
{
    [Table("person")]
    public class Person
    {
        public Person(){}
        public Person(Account account, string name, string surname, string phoneNumber, Gender gender, DateOnly birthDate, Address address)
        {
            Account = account;
            Name = name;
            Surname = surname;
            PhoneNumber = phoneNumber;
            Gender = gender;
            BirthDate = birthDate;
            Address = address;
        }

        [Key]
        [Column("id_person")]
        public Guid Id { get; set; } = Guid.NewGuid();
        
        [Required]
        [ForeignKey("account_id_acc")]
        public Account Account { get; set; }

        [MaxLength(30)]
        [Required]
        [Column("name")]
        public string Name { get; set; }

        [MaxLength(30)]
        [Required]
        [Column("surname")]
        public string Surname { get; set; }

        [MaxLength(30)]
        [Required]
        [Column("phone")]
        public string PhoneNumber { get; set; }

        [Column("gender")]
        [Required]
        public Gender Gender { get; set; }

        [Column("birth")]
        [Required]
        public DateOnly BirthDate { get; set; }
        
        [Required]
        [ForeignKey("address_id_adr")]
        public Address Address { get; set; }

    }
}
