using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetCenter.Domain.Enumerations;

namespace PetCenter.Domain.Model
{
    public class Offer(Person author, OfferType type)
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Person Author { get; set; } = author;
        public OfferType Type { get; set; } = type;
        public Status Status { get; set; } = Status.OnHold;
        public Review? Review { get; set; }

    }
}
