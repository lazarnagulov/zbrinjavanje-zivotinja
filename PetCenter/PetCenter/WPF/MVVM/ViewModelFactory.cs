using PetCenter.Core.Stores;
using PetCenter.Domain.Enumerations;
using PetCenter.WPF.ViewModels.Authentication;
using PetCenter.WPF.ViewModels.Guest;
using PetCenter.WPF.ViewModels.Member;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PetCenter.WPF.MVVM
{
    public class ViewModelFactory(
        CreateViewModel<LoginViewModel> createLoginViewModel,
        CreateViewModel<RegisterViewModel> createRegisterViewModel,
        CreateViewModel<PostListingViewModel> createPostListingViewModel,
        CreateViewModel<CreatePostViewModel> createCreatePostViewModel
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
                _ => throw new ArgumentException($"ViewType {type} doesn't have an associated ViewModel")
            };
        }
    }
}
