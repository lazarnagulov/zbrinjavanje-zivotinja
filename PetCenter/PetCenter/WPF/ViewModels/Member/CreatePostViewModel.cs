using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;
using Microsoft.EntityFrameworkCore.Metadata;
using PetCenter.Core.Service;
using PetCenter.Core.Stores;
using PetCenter.Core.Util;
using PetCenter.Domain.Enumerations;
using PetCenter.Domain.Model;
using PetCenter.Domain.RepositoryInterfaces;
using PetCenter.Repository;
using PetCenter.WPF.BaseViewModels;
using PetCenter.WPF.Command;
using PetCenter.WPF.MVVM;
using PetCenter.WPF.ViewModels.Guest;

namespace PetCenter.WPF.ViewModels.Member
{
    public class CreatePostViewModel : ViewModelBase
    {
        public Action<PostViewModel> OnPostInsert;
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
        public ICommand AddPhotoCommand { get; }
        public ICommand DeletePhotoCommand { get; }

        public CreatePostViewModel(PostService postService, AuthenticationStore authenticationStore,  AnimalTypeService animalTypeService)
        {
            _postService = postService;
            _authenticationStore = authenticationStore;
            AnimalTypes = animalTypeService.GetAll();
            AddPhotoCommand = new RelayCommand(AddPhoto, CanAddPhoto);
            DeletePhotoCommand = new RelayCommand(DeletePhoto, CanDeletePhoto);
            CreatePostCommand = new RelayCommand(CreatePost, CanCreatePost);
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

        private bool CanCreatePost(object? arg)
            => !string.IsNullOrEmpty(Post.Text) &&
               !string.IsNullOrEmpty(Post.Animal.Name) &&
               !string.IsNullOrEmpty(Post.Animal.Description) &&
               Post.Animal.Type is not null;

        private void CreatePost(object? obj)
        {
            Trace.Assert(_authenticationStore.LoggedUser is not null);
            Trace.Assert(Post.Animal.Type is not null);

            var animal = new Animal(Post.Animal.Type, Post.Animal.Name, Post.Animal.Age, Post.Animal.Description);
            var photos = Post.Animal.Photos.Select(photo => new Photo(photo.Url, photo.Description)).ToList();
            animal.AddRangePhoto(photos);
            var post = new Post(_authenticationStore.LoggedUser!, Post.Text, animal);
            if (_postService.Insert(post))
            {
                OnPostInsert?.Invoke(Post);
            }
        }
    }
}
