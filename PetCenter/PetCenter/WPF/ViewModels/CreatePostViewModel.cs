using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;
using PetCenter.Core.Service;
using PetCenter.Core.Stores;
using PetCenter.Domain.Model;
using PetCenter.Domain.RepositoryInterfaces;
using PetCenter.Repository;
using PetCenter.WPF.BaseViewModels;
using PetCenter.WPF.Command;
using PetCenter.WPF.MVVM;

namespace PetCenter.WPF.ViewModels
{
    public class CreatePostViewModel : ViewModelBase
    {
        private PostViewModel _post = new();

        public List<AnimalType> AnimalTypes { get; }

        public PostViewModel Post
        {
            get => _post;
            set => SetField(ref _post, value);
        }

        public ICommand CreatePostCommand { get; }
        public ICommand CancelPostCommand { get; }

        public CreatePostViewModel(PostService postService, AuthenticationStore authenticationStore, NavigationStore navigationStore)
        {
            AnimalTypes = new();
            CreatePostCommand = new RelayCommand(CreateCommand, CanCreate);
            CancelPostCommand =
                new NavigationCommand<PostListingViewModel>(navigationStore, () => new PostListingViewModel(postService, authenticationStore));
        }

        private bool CanCreate(object? arg)
        {
            throw new NotImplementedException();
        }

        private void CreateCommand(object? obj)
        {
            throw new NotImplementedException();
        }
    }
}
