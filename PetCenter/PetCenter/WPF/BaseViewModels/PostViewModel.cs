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

        public ObservableCollection<Person> Likes
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

        public int LikeCount
        {
            get => _likeCount;
            set => SetField(ref _likeCount, value);
        }

        public string NewComment
        {
            get => _newComment;
            set => SetField(ref _newComment, value);
        }

        private Guid _id;
        private Person _author;
        private string _text;
        private Animal _animal;
        private PostState _state;
        private DateOnly _creationDate;
        private ObservableCollection<Person> _likes = new();
        private ObservableCollection<CommentViewModel> _comments = new();
        private ObservableCollection<OfferViewModel> _offers = new();
        private int _likeCount;
        private string _newComment;

        public PostViewModel()
        {
            _animal = new();
        }

        public PostViewModel(Post post)
        {
            _id = post.Id;
            _author = post.Author;
            _text = post.Text;
            _animal = post.Animal;
            _state = post.State;
            _creationDate = post.CreationDate;
            _likeCount = post.LikeCount;
            _newComment = string.Empty;
            foreach (var offer in post.Offers)
            {
                _offers.Add(new OfferViewModel(offer));
            }
            foreach (var comment in post.Comments)
            {
                _comments.Add(new CommentViewModel(comment));    
            }
        }
    }
}
