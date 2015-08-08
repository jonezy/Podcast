using PodcastTracking.Data.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace PodcastTracking.Data.EntityFramework.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly PodcastTrackingContext _context;
        protected DbSet<T> dbSet;

        public Repository(PodcastTrackingContext context)
        {
            _context = context;
            dbSet = _context.Set<T>();
        }

        public List<T> GetAll()
        {
            return dbSet.ToList();
        }

        public void InsertOrUpdate(T entity)
        {
            if (_context.Entry(entity).State == EntityState.Detached)
                _context.Set<T>().Add(entity);

            _context.SaveChanges();
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public List<T> Get(Expression<Func<T, bool>> predicate)
        {
            return dbSet.Where(predicate).ToList();
        }

        public T Find(Expression<Func<T, bool>> predicate)
        {
            return dbSet.FirstOrDefault(predicate);
        }
    }
}
