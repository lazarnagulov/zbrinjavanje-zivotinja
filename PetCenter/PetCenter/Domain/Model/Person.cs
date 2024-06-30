using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetCenter.Domain.Enumerations;

namespace PetCenter.Domain.Model
{
    public class Person(Account account, string name, string surname, string phoneNumber, Gender gender, DateOnly birthDate, Address address)
    {
        public Account Account { get; set; } = account;
        public string Name { get; set; } = name;
        public string Surname { get; set; } = surname;
        public string PhoneNumber { get; set; } = phoneNumber;
        public Gender Gender { get; set; } = gender;
        public DateOnly BirthDate { get; set; } = birthDate;
        public Address Address { get; set; } = address;
    }
}
