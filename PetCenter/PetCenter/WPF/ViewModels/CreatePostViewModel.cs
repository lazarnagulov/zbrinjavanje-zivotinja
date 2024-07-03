using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;
using Microsoft.EntityFrameworkCore.Metadata;
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
        private readonly PostService _postService;
        private readonly AuthenticationStore _authenticationStore;
        private PostViewModel _post = new();

        public List<AnimalType> AnimalTypes { get; }

        public PostViewModel Post
        {
            get => _post;
            set => SetField(ref _post, value);
        }

        public ICommand CreatePostCommand { get; }
        public ICommand CancelPostCommand { get; }
        public ICommand AddPhotoCommand { get; }
        public ICommand DeletePhotoCommand { get; }

        public CreatePostViewModel(PostService postService, AuthenticationStore authenticationStore, NavigationStore navigationStore, AnimalTypeService animalTypeService)
        {
            _postService = postService;
            _authenticationStore = authenticationStore;
            AnimalTypes = animalTypeService.GetAll();
            AddPhotoCommand = new RelayCommand(AddPhoto, CanAddPhoto);
            DeletePhotoCommand = new RelayCommand(DeletePhoto, CanDeletePhoto);
            CreatePostCommand = new RelayCommand(CreatePost, CanCreatePost);
            CancelPostCommand =
                new NavigationCommand<PostListingViewModel>(navigationStore, () => new PostListingViewModel(postService, authenticationStore));
        }

        private bool CanDeletePhoto(object? arg) => Post.Animal.Photos.Count != 0;
        private void DeletePhoto(object? obj) => Post.Animal.Photos.RemoveAt(0);
        
        private bool CanAddPhoto(object? arg)
            => !string.IsNullOrEmpty(Post.Animal.NewPhoto.Url) &&
               !string.IsNullOrEmpty(Post.Animal.NewPhoto.Description);
        
        private void AddPhoto(object? obj)
        {
            var photo = Post.Animal.NewPhoto;
            Post.Animal.NewPhoto = new PhotoViewModel(new Photo());
            Post.Animal.Photos.Add(photo);
        }

        private bool CanCreatePost(object? arg) => true;
        private void CreatePost(object? obj)
        {
            var animal = new Animal(Post.Animal.Type, Post.Animal.Name, Post.Animal.Age, Post.Animal.Description);
            var photos = Post.Animal.Photos.Select(photo => new Photo(photo.Url, photo.Description)).ToList();
            animal.AddRangePhoto(photos);
            _postService.Insert(new Post(_authenticationStore.LoggedUser!, Post.Text, animal));
        }
    }
}
