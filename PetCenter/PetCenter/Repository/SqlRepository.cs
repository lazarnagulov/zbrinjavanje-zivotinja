using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PetCenter.Domain.Model;
using PetCenter.Domain.RepositoryInterfaces;

namespace PetCenter.Repository
{
    public class SqlRepository<T>(DbContext dataContext, DbSet<T> container) : ICrud<T>
        where T : class
    {
        public List<T> GetAll() => container.ToList();

        public T? GetById(Guid id) => container.Find(id);

        public bool Insert(T entity)
        {
            try
            {
                container.AddAsync(entity);
                return dataContext.SaveChanges() > 0;
            }
            catch
            {
                return false;
            }

        }

        public bool Delete(T entity)
        {
            container.Remove(entity);
            return dataContext.SaveChanges() > 0;
        }
    }
}
