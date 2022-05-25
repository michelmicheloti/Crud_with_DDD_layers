using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Data.Context;
using Data.Implementations;
using Data.Repository;
using Domain.Interfaces;
using Domain.Repository;

namespace CrossCutting.DependencyInjection
{
    public class ConfigureRepository
    {
        public static void ConfigureDependenciesRepository(IServiceCollection serviceColletion, IConfiguration configuration)
        {
            serviceColletion.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));

            serviceColletion.AddScoped<ICarRepository, CarImplementation>();

            // IConfiguration databaseConfiguration = new ConfigurationBuilder().AddJsonFile("database.json").Build();

            serviceColletion.AddDbContext<DataContext>(
                    options => options.UseLazyLoadingProxies()
                                      .UseSqlite(configuration.GetConnectionString("DefaultConnection")));
        }
    }
}
