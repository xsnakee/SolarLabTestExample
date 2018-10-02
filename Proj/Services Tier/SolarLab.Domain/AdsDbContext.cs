using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace SolarLab.Domain
{
    public class AdsDbContext : DbContext
    {

        public DbSet<Advert> Adverts { get; set; }
        public DbSet<Board> Boards { get; set; }
        public DbSet<AdvertComment> AdvertComments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var ConnectionString = "Server=(localdb)\\MSSQLLocalDB;Database=C:\\USERS\\NIKOLAY\\SOURCE\\REPOS\\SOLARLAB\\PROJ\\SERVICES TIER\\SOLARLAB.DOMAIN.DATA\\ADVERTDB.MDF;Trusted_connection = True";
            //"Server=BOND-LAPTOP;Database=SolarlabAds;user id=solarlabUser;password=solarlabUser;MultipleActiveResultSets=True;"
            
            optionsBuilder.UseSqlServer(ConnectionString);
        }

    }
}
