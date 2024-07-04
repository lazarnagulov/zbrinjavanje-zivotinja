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
    public class OfferViewModel(Offer offer) : ViewModelBase
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

        private Guid _id = offer.Id;
        private Person _offerer = offer.Offerer;
        private OfferType _type = offer.Type;
        private Status _status = offer.Status;
        private IReadOnlyCollection<Review> _reviews = offer.Reviews;
    }
}
