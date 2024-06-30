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
        public Person Author { get; set; } = author;
        public OfferType Type { get; set; } = type;
        public Status Status { get; set; } = Status.OnHold;
        public IReadOnlyCollection<Review> Reviews => _reviews;
        private readonly List<Review> _reviews = [];
        
        public void AddReview(Review review) => _reviews.Add(review);
        public void RemoveReview(Review review) => _reviews.Remove(review);
    }
}
