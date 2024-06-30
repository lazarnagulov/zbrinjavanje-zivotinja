﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetCenter.Domain.State;

namespace PetCenter.Domain.Model
{
    [Table("post")]
    public class Post
    {
        public Post() {}
        public Post(Person author, string text, Animal animal)
        {
            Author = author;
            Text = text;
            Animal = animal;
        }
        
        [Key]
        [Column("id_post")]
        public Guid Id { get; set;} = Guid.NewGuid();

        [ForeignKey("person_author_p")]
        [Required]
        public Person Author { get; set; }

        [MaxLength(300)]
        [Required]
        [Column("text_p")]
        public string Text { get; set; }

        [ForeignKey("animal_animal_id")]
        [Required]
        public Animal Animal { get; set; }

        [Column("state")] 
        [Required] 
        public PostState State { get; set; }
        
        [Column("creation_date")]
        [Required]
        public DateOnly CreationDate { get; set; } = DateOnly.FromDateTime(DateTime.Now);
        public IReadOnlyCollection<Offer> Offers => _offers;
        public IReadOnlyCollection<Person> Likes => _likes;
        public IReadOnlyCollection<Comment> Comments => _comments;
        [NotMapped]
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
