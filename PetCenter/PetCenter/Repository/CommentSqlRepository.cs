using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetCenter.Domain.Model;
using PetCenter.Domain.RepositoryInterfaces;

namespace PetCenter.Repository
{
    public class CommentSqlRepository(DataContext dataContext) : ICommentRepository
    {
        private readonly SqlRepository<Comment> _sqlRepository = new(dataContext, dataContext.Comments);
        public Task<List<Comment>> GetAll() => _sqlRepository.GetAll();
        public Task<Comment?> GetById(Guid id) => _sqlRepository.GetById(id);
        public Task<bool> Insert(Comment entity) => _sqlRepository.Insert(entity);
        public Task<bool> Delete(Comment entity) => _sqlRepository.Delete(entity);
    }
}
