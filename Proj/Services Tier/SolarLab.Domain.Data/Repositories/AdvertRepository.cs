using Microsoft.EntityFrameworkCore;
using SolarLab.Domain.Data.Repositories.Base;
using SolarLab.Domain.RepositoryInterfaces;
using System;
using System.Collections.Generic;

namespace SolarLab.Domain.Data.Repositories
{
    public class AdvertRepository : RepositoryBase<Advert>, IAdvertRepository
    {
        public AdvertRepository(AdsDbContext dbContext) : base(dbContext)
        {
        }
       
        public override void Delete(Advert entity)
        {
            throw new NotImplementedException();
        }

        public override Advert Get(int id)
        {
            
            Advert result = _dbContext
                                .Adverts
                                .Include(z => z.AdvertComments)
                                .FirstOrDefaultAsync(x => x.Id == id)
                                .Result;

            return result;
        }

        public override IList<Advert> GetAll()
        {
            throw new NotImplementedException();
        }

        public override Advert SaveOrUpdate(Advert entity)
        {
            throw new NotImplementedException();
        }
    }
}
