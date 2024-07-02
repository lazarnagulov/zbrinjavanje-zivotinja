using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetCenter.Domain.Model;
using PetCenter.Domain.State;
using PetCenter.WPF.MVVM;

namespace PetCenter.WPF.BaseViewModels
{
    public class PostViewModel : ViewModelBase
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

        public ObservableCollection<PersonViewModel> Likes
        {
            get => _likes;
            set => SetField(ref _likes, value);
        }

        public ObservableCollection<CommentViewModel> Comments
        {
            get => _comments;
            set => SetField(ref _comments, value);
        }

        public ObservableCollection<OfferViewModel> Offers
        {
            get => _offers;
            set => SetField(ref _offers, value);
        }

        private Guid _id;
        private Person _author;
        private string _text;
        private Animal _animal;
        private PostState _state;
        private DateOnly _creationDate;
        private ObservableCollection<PersonViewModel> _likes;
        private ObservableCollection<CommentViewModel> _comments;
        private ObservableCollection<OfferViewModel> _offers;

        public PostViewModel(Post post)
        {
            _id = post.Id;
            _author = post.Author;
            _text = post.Text;
            _animal = post.Animal;
            _state = post.State;
            _creationDate = post.CreationDate;

            _comments = new ObservableCollection<CommentViewModel>();
            foreach (var comment in post.Comments)
            {
                _comments.Add(new CommentViewModel(comment));    
            }

            _likes = new ObservableCollection<PersonViewModel>();
            foreach (var like in post.Likes)
            {
                _likes.Add(new PersonViewModel(like));
            }

            _offers = new ObservableCollection<OfferViewModel>();
            foreach (var offer in post.Offers)
            {
                _offers.Add(new OfferViewModel(offer));
            }
        }
    }
}
