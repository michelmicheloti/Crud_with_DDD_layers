using Microsoft.Extensions.DependencyInjection;
using Domain.Interfaces.Services;
using Service.Services;

namespace CrossCutting.DependencyInjection
{
    public class ConfigureService
    {
        public static void ConfigureDependenciesService(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<ICarService, CarService>();
        }
    }
}
