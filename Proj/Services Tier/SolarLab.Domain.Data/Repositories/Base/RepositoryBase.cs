using System;
using System.Collections.Generic;
using SolarLab.Domain.RepositoryInterfaces.Base;
using SolarLab.Domain.Entities.Base;

namespace SolarLab.Domain.Data.Repositories.Base
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T, int> where T : EntityBase
    {
        public RepositoryBase(AdsDbContext dbContext)
        {   
            _dbContext = dbContext;
        }

        protected readonly AdsDbContext _dbContext;

        public virtual void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public virtual T Get(int id)
        {
            throw new NotImplementedException();
        }

        public virtual IList<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public virtual T SaveOrUpdate(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
