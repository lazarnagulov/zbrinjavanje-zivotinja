using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetCenter.Domain.Model;
using PetCenter.Domain.State;
using PetCenter.WPF.MVVM;

namespace PetCenter.WPF.BaseViewModels
{
    public class PostViewModel(Post post) : ViewModelBase
    {
        public Guid Id
        {
            get => _id;
            set => SetField(ref _id, value);
        }

        public Person Author
        {
            get => _author;
            set => SetField(ref _author, value);
        }

        public string Text
        {
            get => _text;
            set => SetField(ref _text, value);
        }

        public Animal Animal
        {
            get => _animal;
            set => SetField(ref _animal, value);
        }

        public PostState State
        {
            get => _state;
            set => SetField(ref _state, value);
        }

        public DateOnly CreationDate
        {
            get => _creationDate;
            set => SetField(ref _creationDate, value);
        }

        public IReadOnlyCollection<Person> Likes
        {
            get => _likes;
            set => SetField(ref _likes, value);
        }

        public IReadOnlyCollection<Comment> Comments
        {
            get => _comments;
            set => SetField(ref _comments, value);
        }

        public IReadOnlyCollection<Offer> Offers
        {
            get => _offers;
            set => SetField(ref _offers, value);
        }

        private Guid _id = post.Id;
        private Person _author = post.Author;
        private string _text = post.Text;
        private Animal _animal = post.Animal;
        private PostState _state = post.State;
        private DateOnly _creationDate = post.CreationDate;
        private IReadOnlyCollection<Person> _likes = post.Likes;
        private IReadOnlyCollection<Comment> _comments = post.Comments;
        private IReadOnlyCollection<Offer> _offers = post.Offers;
    }
}
