using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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
        public List<Post> GetAccepted()
            => dataContext.Posts
                .Include(post => post.Animal)
                    .ThenInclude(animal => animal.Photos)
                .Include(post => post.Animal)
                    .ThenInclude(animal => animal.Type)
                .Include(post => post.Comments)
                    .ThenInclude(comment => comment.Author)
                .Include(post => post.State)
                //.Where(post => post.State is Accepted)
                .ToList();

        public List<Post> GetOnHold()
            => dataContext.Posts
                .Include(post => post.Animal)
                .ThenInclude(animal => animal.Photos)
                .Include(post => post.Animal)
                .ThenInclude(animal => animal.Type)
                .Include(post => post.Comments)
                .ThenInclude(comment => comment.Author)
                .Include(post => post.State)
                //.Where(post => post.State is OnHold)
                .ToList();
    }
}
