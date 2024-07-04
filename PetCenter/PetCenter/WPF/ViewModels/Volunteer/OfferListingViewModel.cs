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
using System.Windows;
using Microsoft.Extensions.Hosting;

namespace PetCenter.WPF.ViewModels.Volunteer
{
    public class OfferListingViewModel : ViewModelBase
    {
        private readonly PostService _postService;
        private readonly OfferService _offerService;
        private readonly NotificationService _notificationService;

        private ObservableCollection<OfferViewModel> _offers;
        public ObservableCollection<OfferViewModel> Offers
        {
            get => _offers;
            set => SetField(ref _offers, value);
        }
        public ICommand AcceptOfferCommand { get; }
        public ICommand RejectOfferCommand { get; }

        public OfferListingViewModel(PostService postService, OfferService offerService, NotificationService notificationService)
        {
            _postService = postService;
            _offerService = offerService;
            _notificationService = notificationService;

            _offers = new ObservableCollection<OfferViewModel>();
            foreach (var offer in _offerService.GetAllOnHold())
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
                Post? post = _postService.GetPostByOffer(offerViewModel.Id);
                if (post == null) 
                    throw new ArgumentNullException(nameof(post));
                var offerType = offerViewModel.Type;
                if (offerType == OfferType.Adoption)
                {
                    _postService.ChangeState(post, new Adopted(_postService));
                    string offererMessage = $"Congratulations, you adoption offer for animal {post.Animal.Name} was accepted! You should contact them using {post.Author.PhoneNumber}.";
                    string authorMessage = $"Congratulations, you animal {post.Animal.Name} got adopted by {offerViewModel.Offerer}! You should contact them using {offerViewModel.Offerer.PhoneNumber}.";
                    _notificationService.SendNotification(offerViewModel.Offerer, offererMessage);
                    _notificationService.SendNotification(post.Author, authorMessage);
                }
                else if (offerType == OfferType.TemporaryAccommodation) 
                {
                    _postService.ChangeState(post, new TemporaryAccommodation(_postService));
                    string offererMessage = $"Congratulations, you temporary accommodation offer for animal {post.Animal.Name} was accepted! You should contact them using {post.Author.PhoneNumber}.";
                    string authorMessage = $"Congratulations, you animal {post.Animal.Name} got temporary accommodation from {offerViewModel.Offerer}! You should contact them using {offerViewModel.Offerer.PhoneNumber}.";
                    _notificationService.SendNotification(offerViewModel.Offerer, offererMessage);
                    _notificationService.SendNotification(post.Author, authorMessage);
                }
                _offerService.UpdateOfferStatus(offerViewModel.Id, Status.Accepted);
                Offers.Remove(offerViewModel);
                MessageBox.Show("Successfully accepted the offer!", "Success!", MessageBoxButton.OK, MessageBoxImage.Information);
                OnPropertyChanged(nameof(Offers));
            }
        }

        private void RejectCommand(object? obj) 
        {
            if (obj is OfferViewModel offerViewModel)
            {
                _offerService.UpdateOfferStatus(offerViewModel.Id, Status.Declined); 
                string offererMessage = $"Unfortunately, your {offerViewModel.Type} offer for {offerViewModel.PostAuthor}'s animal {offerViewModel.PostAnimalName} was rejected.";
                _notificationService.SendNotification(offerViewModel.Offerer, offererMessage);
                Offers.Remove(offerViewModel);
                MessageBox.Show("Successfully rejected the offer!", "Success!", MessageBoxButton.OK, MessageBoxImage.Information);
                OnPropertyChanged(nameof(Offers));
            }
        }


    }
}
