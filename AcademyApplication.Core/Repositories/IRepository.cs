﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AcademyApplication.Core.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetEntity(Expression<Func<T, bool>> predicate = null, params Func<IQueryable<T>, IQueryable<T>>[] includes);
        Task<List<T>> GetAll(Expression<Func<T, bool>> predicate = null, params Func<IQueryable<T>, IQueryable<T>>[] includes);
        Task Create(T entity);
        Task Update(T entity);
        Task Delete(T entity);
        Task<bool> isExists(Expression<Func<T, bool>> predicate = null);
        Task Commit();
    }
}
