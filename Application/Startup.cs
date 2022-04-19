using Application.Configuration;
using CrossCutting.DependencyInjection;

namespace Application
{
    public class Startup : IStartup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddIdentityConfiguration(Configuration);
            services.AddApiConfiguration();

            IConfiguration databaseConfiguration = new ConfigurationBuilder().AddJsonFile("database.json").Build();

            ConfigureService.ConfigureDependenciesService(services);
            ConfigureRepository.ConfigureDependenciesRepository(services, databaseConfiguration);

            services.AddSwaggerConfiguration();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(WebApplication app, IWebHostEnvironment environment)
        {
            app.UseSwaggerConfiguration();
            app.UseApiConfiguration(environment);
        }
    }

    public interface IStartup
    {
        IConfiguration Configuration { get; }
        void Configure(WebApplication app, IWebHostEnvironment environment);
        void ConfigureServices(IServiceCollection services);
    }

    public static class StartupExtensions
    {
        public static WebApplicationBuilder UseStartup<TStartup>(this WebApplicationBuilder webAppBuilder) where TStartup : IStartup
        {
            if (Activator.CreateInstance(typeof(TStartup), webAppBuilder.Configuration) is not IStartup startup)
            {
                throw new ArgumentException("Invalid Startup.cs class");
            }

            startup.ConfigureServices(webAppBuilder.Services);

            WebApplication app = webAppBuilder.Build();
            startup.Configure(app, app.Environment);

            app.Run();

            return webAppBuilder;
        }
    }
}
