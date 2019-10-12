using PFC.SGP.Domain.Entities;
using System;
using System.Collections.Generic;

namespace PFC.SGP.Domain.Contracts.Repositories
{
    public interface IRepository<T> : IDisposable where T : AbstractEntity
    {
        IEnumerable<T> Find();
        IEnumerable<T> Find(string auth);
        T Find(long id);

        void Persist(T entity);
        void Merge(T entity);

        void Delete(T entity);
    }
}
