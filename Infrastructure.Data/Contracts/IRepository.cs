using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Contracts
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> Queryable();

        T Find(int id);

        T Find(params object[] keyValues);

        void Add(T entity);

        void AddRange(IEnumerable<T> entities);

        void Remove(T entity);

        void RemoveRange(IEnumerable<T> entities);
    }
}
