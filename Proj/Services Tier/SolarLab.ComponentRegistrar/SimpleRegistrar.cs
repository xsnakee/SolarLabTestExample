using Microsoft.EntityFrameworkCore;
using SimpleInjector;
using SolarLab.AppServices;
using SolarLab.Domain;
using SolarLab.Domain.Data.Repositories;
using SolarLab.Domain.RepositoryInterfaces;

namespace SolarLab.ComponentRegistrar
{
    public static class SimpleRegistrar
    {
     
        public static void RegisterAll(Container container)
        {
            container.Register<IAdvertService, AdvertService>();
            container.Register<IBoardService, BoardService>();
            container.Register<IAdvertRepository, AdvertRepository>();
            container.Register<IBoardRepository, BoardRepository>();
            container.Register<AdsDbContext>(ScopedLifestyle.Scoped);
        }
    }
}
