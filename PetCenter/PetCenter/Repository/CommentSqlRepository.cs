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
        public List<Comment> GetAll() => _sqlRepository.GetAll();
        public Comment? GetById(Guid id) => _sqlRepository.GetById(id);
        public bool Insert(Comment entity) => _sqlRepository.Insert(entity);
        public bool Delete(Comment entity) => _sqlRepository.Delete(entity);
    }
}
