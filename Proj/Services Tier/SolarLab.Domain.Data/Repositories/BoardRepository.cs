using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SolarLab.Domain.Data.Repositories.Base;

namespace SolarLab.Domain.Data.Repositories
{
    public class BoardRepository : RepositoryBase<Board>
    {

        public BoardRepository(AdsDbContext dbContext) : base(dbContext)
        {
        }

        public override void Delete(Board entity)
        {
            throw new NotImplementedException();
        }

        public override Board Get(int id)
        {
            Board board = _dbContext
                        .Boards
                        .Include(z => z.Adverts)
                        .ThenInclude(z => z.AdvertComments)
                        .FirstOrDefaultAsync(x => x.Id == id)
                        .Result;

            return board;
        }

        public override IList<Board> GetAll()
        {
            throw new NotImplementedException();
        }

        public override Board SaveOrUpdate(Board entity)
        {
            throw new NotImplementedException();
        }
    }
}
