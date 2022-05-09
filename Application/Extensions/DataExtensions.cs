using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Extensions
{
    public static class DataExtensions
    {
        public static IApplicationBuilder ApplyMigrations<T>(this WebApplication app) where T : DbContext
        {
            using IServiceScope scope = app.Services.CreateScope();
            scope.ServiceProvider.GetRequiredService<T>().Database.Migrate();
            return app;
        }
    }
}
