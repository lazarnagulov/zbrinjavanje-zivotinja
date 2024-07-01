using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetCenter.Domain.Model;
using PetCenter.Domain.State;

namespace PetCenter.WPF.BaseViewModels
{
    public class PostViewModel(Post post) : ViewModelBase
    {
        public Guid Id
        {
            get => _id;
            set
            {
                _id = value;
                OnPropertyChanged();
            }
        }

        public Person Author
        {
            get => _author;
            set
            {
                _author = value;
                OnPropertyChanged();
            }
        }

        public string Text
        {
            get => _text;
            set
            {
                _text = value;
                OnPropertyChanged();
            }
        }

        public Animal Animal
        {
            get => _animal;
            set
            {
                _animal = value;
                OnPropertyChanged();
            }
        }

        public PostState State
        {
            get => _state;
            set
            {
                _state = value;
                OnPropertyChanged();
            }
        }

        public DateOnly CreationDate
        {
            get => _creationDate;
            set
            {
                _creationDate = value;
                OnPropertyChanged();
            }
        }

        public IReadOnlyCollection<Person> Likes
        {
            get => _likes;
            set
            {
                _likes = value;
                OnPropertyChanged();
            }
        }

        public IReadOnlyCollection<Comment> Comments
        {
            get => _comments;
            set
            {
                _comments = value;
                OnPropertyChanged();
            }
        }

        public IReadOnlyCollection<Offer> Offers
        {
            get => _offers;
            set
            {
                _offers = value;
                OnPropertyChanged();
            }
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
