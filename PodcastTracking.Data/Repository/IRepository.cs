using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace PodcastTracking.Data.Repository
{
    public interface IRepository<T>
    {
        List<T> GetAll();
        List<T> Get(Expression<Func<T,bool>> predicate);
        T Find(Expression<Func<T,bool>> predicate);
        void InsertOrUpdate(T entity);
        void Delete(T entity);
    }
}
