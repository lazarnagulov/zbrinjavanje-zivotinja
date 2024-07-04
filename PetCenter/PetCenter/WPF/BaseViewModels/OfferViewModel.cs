using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetCenter.Domain.Enumerations;
using PetCenter.Domain.Model;
using PetCenter.WPF.MVVM;

namespace PetCenter.WPF.BaseViewModels
{
    public class OfferViewModel(Offer offer, Post post) : ViewModelBase
    {
        public Guid Id
        {
            get => _id;
            set => SetField(ref _id, value);
        }

        public Person Offerer
        {
            get => _offerer;
            set => SetField(ref _offerer, value);
        }

        public OfferType Type
        {
            get => _type;
            set => SetField(ref _type, value);
        }

        public Status Status
        {
            get => _status;
            set => SetField(ref _status, value);
        }

        public IReadOnlyCollection<Review> Reviews
        {
            get => _reviews;
            set => SetField(ref _reviews, value);
        }

        public string PostText
        {
            get => _postText;
            set => SetField(ref _postText, value);
        }

        public string PostAnimalName
        {
            get => _postAnimalName;
            set => SetField(ref _postAnimalName, value);
        }

        public string PostAuthor
        {
            get => _postAuthor;
            set => SetField(ref _postAuthor, value);
        }

        private Guid _id = offer.Id;
        private Person _offerer = offer.Offerer;
        private OfferType _type = offer.Type;
        private Status _status = offer.Status;
        private IReadOnlyCollection<Review> _reviews = offer.Reviews;
        private string _postText = post.Text;
        private string _postAnimalName = post.Animal.Name;
        private string _postAuthor = post.Author.ToString();
    }
}
