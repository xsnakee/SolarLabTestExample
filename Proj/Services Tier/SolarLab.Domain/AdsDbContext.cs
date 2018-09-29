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

        /*
        public AdsDbContext(DbContextOptions<AdsDbContext> options): base(options)
        {
            Database.EnsureCreated();
        }*/

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var ConnectionString = "Server=(localdb)\\MSSQLLocalDB;Database=C:\\USERS\\NIKOLAY\\SOURCE\\REPOS\\SOLARLAB\\PROJ\\SERVICES TIER\\SOLARLAB.DOMAIN.DATA\\REPOSITORIES\\SOLARLABTESTPROJDB.MDF;user id=Generalov;password=1111;Trusted_Connection=True;";
            //"Server=BOND-LAPTOP;Database=SolarlabAds;user id=solarlabUser;password=solarlabUser;MultipleActiveResultSets=True;"
            
            optionsBuilder.UseSqlServer(ConnectionString);
        }

    }
}
