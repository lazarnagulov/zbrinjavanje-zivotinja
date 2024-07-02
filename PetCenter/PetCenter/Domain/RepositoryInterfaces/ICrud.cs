using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetCenter.Domain.RepositoryInterfaces
{
    public interface ICrud<T> where T : class
    {
        List<T> GetAll();
        T? GetById(Guid id);
        bool Insert(T entity);
        bool Delete(T entity);
    }
}
