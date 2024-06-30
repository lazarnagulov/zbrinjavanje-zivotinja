using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetCenter.Domain.State;

namespace PetCenter.Domain.Model
{
    public class Post(Person author, string text, Animal animal)
    {
        public Guid Id { get; set;} = Guid.NewGuid();
        public Person Author { get; set; } = author;
        public string Text { get; set; } = text;
        public Animal Animal { get; set; } = animal;
        public PostState State { get; set; }
        public IReadOnlyCollection<Offer> Offers => _offers;
        public IReadOnlyCollection<Person> Likes => _likes;
        public IReadOnlyCollection<Comment> Comments => _comments;
        public int LikeCount => Likes.Count;

        private readonly HashSet<Person> _likes = [];
        private readonly List<Offer> _offers = [];
        private readonly List<Comment> _comments = [];

        public void AddOffer(Offer offer) => _offers.Add(offer);
        public void RemoveOffer(Offer offer) => _offers.Remove(offer);
        public void AddLike(Person person) => _likes.Add(person);
        public void RemoveLike(Person person) => _likes.Remove(person);
        public void AddComment(Comment comment) => _comments.Add(comment);
        public void RemoveComment(Comment comment) => _comments.Remove(comment);
    }
}
