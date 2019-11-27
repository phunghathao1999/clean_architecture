using System.Collections.Generic;
using System.Linq;
using ApplicationCore.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
    public class EFRepository<T> : IRepository<T> where T : class, IAggregateRoot
    {
        private readonly DbContext _context;

        public EFRepository(DbContext context)
        {
            _context = context;
        }

        protected DbContext Context => _context;

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public T GetBy(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public IEnumerable<T> Find(ISpecification<T> spec)
        {
            return ApplySpecification(_context.Set<T>().AsQueryable(), spec);
            //return Context.Set<T>().Where(spec);
        }

        private IEnumerable<T> ApplySpecification(IQueryable<T> query, ISpecification<T> spec)
        {
            if (spec.Criteria != null)
                query = query.Where(spec.Criteria);

            if (spec.IsPaginated)
                query = query.Skip((spec.PageIndex - 1) * spec.PageSize).Take(spec.PageSize);
            return query.ToList();
        }

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void AddRange(IEnumerable<T> entities)
        {
            _context.Set<T>().AddRange(entities);
        }

        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            _context.Set<T>().RemoveRange(entities);
        }

        public int Count()
        {
            return _context.Set<T>().Count();
        }
    }
}
