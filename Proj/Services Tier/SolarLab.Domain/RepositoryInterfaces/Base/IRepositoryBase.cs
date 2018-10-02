using SolarLab.Domain.Entities.Base;
using System.Collections.Generic;

namespace SolarLab.Domain.RepositoryInterfaces.Base
{
    public interface IRepositoryBase<T, TId> where T : EntityWithTypedIdBase<TId>
    {
        void Delete(T entity);
        T Get(TId id);
        IList<T> GetAll();
        T SaveOrUpdate(T entity);
    }
}
