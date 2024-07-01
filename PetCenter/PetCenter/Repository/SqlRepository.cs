using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PetCenter.Domain.RepositoryInterfaces;

namespace PetCenter.Repository
{
    public class SqlRepository<T>(DbContext dataContext, DbSet<T> container) : ICrud<T>
        where T : class
    {
        public async Task<List<T>> GetAll() => await container.ToListAsync();
        public async Task<T?> GetById(Guid id) => await container.FindAsync(id);
        public async Task<bool> Insert(T entity)
        {
            try
            {
                await container.AddAsync(entity);
                return await dataContext.SaveChangesAsync() > 0;
            }
            catch
            {
                return false;
            }

        }
        public async Task<bool> Delete(T entity)
        {
            container.Remove(entity);
            return await dataContext.SaveChangesAsync() > 0;
        }
    }
}
