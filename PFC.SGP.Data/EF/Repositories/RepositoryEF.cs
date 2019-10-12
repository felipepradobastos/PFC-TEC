using PFC.SGP.Domain.Contracts.Repositories;
using PFC.SGP.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace PFC.SGP.Data.EF.Repositories
{
    public abstract class RepositoryEF<T> : IRepository<T> where T:AbstractEntity
    {
        public RepositoryEF(PFCSGPDataContext ctx)
        {
            _ctx = ctx;
        }
        protected readonly PFCSGPDataContext _ctx;

        public IEnumerable<T> Find()
        {
            return _ctx.Set<T>()
                .ToList();
        }

        public abstract IEnumerable<T> Find(string auth);

        public T Find(long id)
        {
            return _ctx.Set<T>().Where(e => e.Id == id).FirstOrDefault();
        }

        public void Persist(T entity)
        {
            _ctx.Set<T>().Add(entity);
            _SaveChanges();
        }

        public void Merge(T entity)
        {
            _ctx.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            _SaveChanges();
        }

        public void Delete(T entity)
        {
            _ctx.Set<T>().Remove(entity);
            _SaveChanges();
        }

        private void _SaveChanges()
        {
            _ctx.SaveChanges();
        }

        public void Dispose()
        {}
    }
}
