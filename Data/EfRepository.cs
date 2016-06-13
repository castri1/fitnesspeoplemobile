using System;
using System.Linq;
using Core.Data;
using System.Data.Entity;

namespace Data
{
    public partial class EfRepository<T> : IRepository<T> where T : class
    {
        private readonly FpContext _context;
        private IDbSet<T> _entities;

        public EfRepository(string nameOrConnectionString)
        {
            _context = new FpContext(nameOrConnectionString);
        }

        public IQueryable<T> Table
        {
            get
            {
                return this.Entities;
            }
        }

        //public IQueryable<T> Queryable

        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public T GetById(object id)
        {
            return this.Entities.Find(id);
        }

        public void Insert(T entity)
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }

        protected virtual IDbSet<T> Entities
        {
            get
            {
                if (_entities == null)
                    _entities = _context.Set<T>();
                return _entities;
            }
        }
    }
}
