using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Data.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Services
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DbContext _context;


        public Repository(DbContext context)
        {
            _context = context;
        }


        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void AddRange(IEnumerable<T> entities)
        {
            _context.Set<T>().AddRange(entities);
        }

        public T Find(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public T Find(params object[] keyValues)
        {
            return _context.Set<T>().Find(keyValues);
        }

        public IQueryable<T> Queryable()
        {
            return _context.Set<T>();
        }

        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            _context.Set<T>().RemoveRange(entities);
        }
    }
}
