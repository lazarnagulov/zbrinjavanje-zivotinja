using PetCenter.Core.Service;
using PetCenter.Domain.Model;
using PetCenter.Repository;
using PetCenter.WPF.BaseViewModels;
using PetCenter.WPF.MVVM;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using PetCenter.Domain.Enumerations;
using PetCenter.Domain.State;

namespace PetCenter.WPF.ViewModels.Volunteer
{
    public class OfferListingViewModel : ViewModelBase
    {
        private readonly PostService _postService;
        private readonly OfferService _offerService;

        private ObservableCollection<OfferViewModel> _offers;
        public ObservableCollection<OfferViewModel> Offers
        {
            get => _offers;
            set => SetField(ref _offers, value);
        }
        public ICommand AcceptOfferCommand { get; }
        public ICommand RejectOfferCommand { get; }

        public OfferListingViewModel(PostService postService, OfferService offerService)
        {
            _postService = postService;
            _offerService = offerService;

            _offers = new ObservableCollection<OfferViewModel>();
            foreach (var offer in _offerService.GetAllIncluded())
            {
                _offers.Add(new OfferViewModel(offer, _postService.GetPostByOffer(offer.Id)!));
            }

            AcceptOfferCommand = new RelayCommand<OfferViewModel>(AcceptCommand);
            RejectOfferCommand = new RelayCommand<OfferViewModel>(RejectCommand);
            
        }

        private void AcceptCommand(object? obj) 
        {
            if (obj is OfferViewModel offerViewModel)
            { 
                Post post = _postService.GetPostByOffer(offerViewModel.Id);
                var offerType = offerViewModel.Type;
                if (offerType == OfferType.Adoption)
                {
                    _postService.ChangeState(post, new Adopted(_postService));
                }
                else if (offerType == OfferType.TemporaryAccommodation) 
                {
                    _postService.ChangeState(post, new TemporaryAccommodation(_postService));
                }
                _offerService.UpdateOfferStatus(offerViewModel.Id, Status.Accepted);
            }
        }

        private void RejectCommand(object? obj) 
        {
            if (obj is OfferViewModel offerViewModel)
            {
                _offerService.UpdateOfferStatus(offerViewModel.Id, Status.Declined);
            }
        }


    }
}
