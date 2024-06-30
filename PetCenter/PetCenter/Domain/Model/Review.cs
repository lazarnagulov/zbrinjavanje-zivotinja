using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetCenter.Domain.Model
{
    public class Review(Offer offer, int grade, string comment)
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Offer Offer { get; set; } = offer;
        public int Grade { get; set; } = grade;
        public string Comment { get; set; } = comment;
    }
}
