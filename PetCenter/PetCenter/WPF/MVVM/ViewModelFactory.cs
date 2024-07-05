using PetCenter.Core.Stores;
using PetCenter.Domain.Enumerations;
using PetCenter.WPF.ViewModels.Authentication;
using PetCenter.WPF.ViewModels.Guest;
using PetCenter.WPF.ViewModels.Member;
using PetCenter.WPF.ViewModels.Volunteer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using PetCenter.WPF.ViewModels.Administrator;

namespace PetCenter.WPF.MVVM
{
    public class ViewModelFactory(
        CreateViewModel<LoginViewModel> createLoginViewModel,
        CreateViewModel<RegisterViewModel> createRegisterViewModel,
        CreateViewModel<PostListingViewModel> createPostListingViewModel,
        CreateViewModel<CreatePostViewModel> createCreatePostViewModel,
        CreateViewModel<OfferListingViewModel> createOfferListingViewModel,
        CreateViewModel<NotificationListingViewModel> createNotificationListingViewModel,
        CreateViewModel<PetCenterInfoViewModel> createPetCenterInfoViewModel,
        CreateViewModel<AddVolunteerViewModel> createAddVolunteerViewModel,
        CreateViewModel<PostReviewViewModel> createPostReviewViewModel,
        CreateViewModel<AnimalTypeCrudViewModel> createAnimalTypeCrudViewModel,
        CreateViewModel<DonationViewModel> createDonationViewModel,
        CreateViewModel<RequestListingViewModel> createRequestListingViewModel
        )
    {
        public CreateViewModel<T> GetCreateViewModel<T>(ViewType type) where T : ViewModelBase
        {
            return type switch
            {
                ViewType.Login => (createLoginViewModel as CreateViewModel<T>)!,
                ViewType.Register => (createRegisterViewModel as CreateViewModel<T>)!,
                ViewType.PostListing => (createPostListingViewModel as CreateViewModel<T>)!,
                ViewType.CreatePost => (createCreatePostViewModel as CreateViewModel<T>)!,
                ViewType.AddVolunteer => (createAddVolunteerViewModel as CreateViewModel<T>)!,
                ViewType.PetCenterInfo => (createPetCenterInfoViewModel as CreateViewModel<T>)!,
                ViewType.OfferListing => (createOfferListingViewModel as CreateViewModel<T>)!,
                ViewType.NotificationListing => (createNotificationListingViewModel as CreateViewModel<T>)!,
                ViewType.RequestListing => (createRequestListingViewModel as CreateViewModel<T>)!,
                ViewType.PostReview => (createPostReviewViewModel as CreateViewModel<T>)!,
                ViewType.AnimalTypeCrud => (createAnimalTypeCrudViewModel as CreateViewModel<T>)!,
                ViewType.Donation => (createDonationViewModel as CreateViewModel<T>)!,
                _ => throw new ArgumentException($"ViewType {type} doesn't have an associated ViewModel")
            };
        }
        public ViewModelBase CreateViewModel(ViewType type)
        {
            return type switch
            {
                ViewType.Login => createLoginViewModel(),
                ViewType.Register => createRegisterViewModel(),
                ViewType.PostListing => createPostListingViewModel(),
                ViewType.CreatePost => createCreatePostViewModel(),
                ViewType.AddVolunteer => createAddVolunteerViewModel(),
                ViewType.PetCenterInfo => createPetCenterInfoViewModel(),
                ViewType.OfferListing => createOfferListingViewModel(),
                ViewType.NotificationListing => createNotificationListingViewModel(),
                ViewType.RequestListing=> createRequestListingViewModel(),
                ViewType.PostReview => createPostReviewViewModel(),
                ViewType.AnimalTypeCrud => createAnimalTypeCrudViewModel(),
                ViewType.Donation => createDonationViewModel(),
                _ => throw new ArgumentException($"ViewType {type} doesn't have an associated ViewModel")
            };
        }
    }
}
