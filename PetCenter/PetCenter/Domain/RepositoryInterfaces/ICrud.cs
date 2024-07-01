﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetCenter.Domain.RepositoryInterfaces
{
    public interface ICrud<T> where T : class
    {
        Task<List<T>> GetAll();
        Task<T?> GetById(Guid id);
        Task<bool> Insert(T entity);
        Task<bool> Delete(T entity);
    }
}