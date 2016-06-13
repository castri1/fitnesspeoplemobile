using System;
using System.Linq;
using System.Linq.Expressions;

namespace Core.Data
{
    public partial interface IRepository<T> where T : class
    {
        T GetById(object id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        IQueryable<T> Table { get; }
    }
}
