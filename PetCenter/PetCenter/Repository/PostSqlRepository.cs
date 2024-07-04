using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using PetCenter.Domain.Model;
using PetCenter.Domain.RepositoryInterfaces;
using PetCenter.Domain.State;

namespace PetCenter.Repository
{
    public class PostSqlRepository(DataContext dataContext) : IPostRepository
    {
        private readonly SqlRepository<Post> _sqlRepository = new(dataContext, dataContext.Posts);
        public List<Post> GetAll() => _sqlRepository.GetAll();
        public Post? GetById(Guid id) => _sqlRepository.GetById(id);
        public bool Insert(Post entity) => _sqlRepository.Insert(entity);
        public bool Delete(Post entity) => _sqlRepository.Delete(entity);
        public bool Update(Post entity) => _sqlRepository.Update(entity);

        public List<Post> GetAccepted()
            =>  GetIncludes()
                .Where(post => post.State is Accepted || post.State is Adopted || post.State is TemporaryAccommodation)
                .ToList();

        public List<Post> GetOnHold()
                =>  GetIncludes()
                .Where(post => post.State is OnHold)
                .ToList();

        public List<Post> GetAcceptedWithHidden()
            => GetIncludes()
                .Where(post =>
                    post.State is Accepted || post.State is Adopted || post.State is TemporaryAccommodation ||
                    post.State is Hidden)
                .ToList();


        private IIncludableQueryable<Post, PostState> GetIncludes()
            => dataContext.Posts
                .Include(post => post.Author)
                .ThenInclude(author => author.Account)
                .Include(post => post.Animal)
                .ThenInclude(animal => animal.Photos)
                .Include(post => post.Animal)
                .ThenInclude(animal => animal.Type)
                .Include(post => post.Comments)
                .ThenInclude(comment => comment.Author)
                .ThenInclude(author => author.Account)
                .Include(post => post.Likes)
                .Include(post => post.State);


        public List<Post> GetAllIncluded()
            => dataContext.Posts
                .Include(post => post.Animal)
                .ThenInclude(animal => animal.Photos)
                .Include(post => post.Animal)
                .ThenInclude(animal => animal.Type)
                .Include(post => post.Comments)
                .ThenInclude(comment => comment.Author)
                .Include(post => post.State)
                .Include(post => post.Offers)
                .ToList();
    }
}
