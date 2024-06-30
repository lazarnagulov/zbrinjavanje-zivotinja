using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetCenter.Domain.Model
{
    public class Address(string street, int number, string city, string country, int zipCode)
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Street { get; set; } = street;
        public int Number { get; set; } = number;
        public string City { get; set; } = city;
        public string Country { get; set; } = country;
        public int ZipCode { get; set; } = zipCode;
    }
}
