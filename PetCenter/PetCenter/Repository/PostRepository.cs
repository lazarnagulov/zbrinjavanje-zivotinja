using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetCenter.Domain.Model;
using PetCenter.Domain.RepositoryInterfaces;

namespace PetCenter.Repository
{
    public class PostRepository(DataContext dataContext) : IPostRepository
    {
        private readonly SqlRepository<Post> _sqlRepository = new(dataContext, dataContext.Posts);
        public Task<List<Post>> GetAll() => _sqlRepository.GetAll();
        public Task<Post?> GetById(Guid id) => _sqlRepository.GetById(id);
        public Task<bool> Insert(Post entity) => _sqlRepository.Insert(entity);
        public Task<bool> Delete(Post entity) => _sqlRepository.Delete(entity);
    }
}
