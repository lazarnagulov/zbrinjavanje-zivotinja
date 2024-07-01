using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetCenter.Domain.Enumerations;
using PetCenter.Domain.Model;

namespace PetCenter.WPF.BaseViewModels
{
    public class OfferViewModel(Offer offer) : ViewModelBase
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

        public Person Offerer
        {
            get => _offerer;
            set
            {
                _offerer = value;
                OnPropertyChanged();
            }
        }

        public OfferType Type
        {
            get => _type;
            set
            {
                _type = value;
                OnPropertyChanged();
            }
        }

        public Status Status
        {
            get => _status;
            set
            {
                _status = value;
                OnPropertyChanged();
            }
        }

        public IReadOnlyCollection<Review> Reviews
        {
            get => _reviews;
            set
            {
                _reviews = value;
                OnPropertyChanged();
            }
        }

        private Guid _id = offer.Id;
        private Person _offerer = offer.Offerer;
        private OfferType _type = offer.Type;
        private Status _status = offer.Status;
        private IReadOnlyCollection<Review> _reviews = offer.Reviews;
    }
}
