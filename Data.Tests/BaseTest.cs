using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Data.Tests
{
    public abstract class BaseTest
    {
        public BaseTest()
        {

        }

        public class DbTest : IDisposable
        {
            private readonly string dataBaseName = $"dbApiTest_{Guid.NewGuid().ToString().Replace("-", string.Empty)}";
            public ServiceProvider ServiceProvider { get; private set; }

            public DbTest()
            {
                var serviceCollection = new ServiceCollection();
                serviceCollection.AddDbContext<DataContext>(
                    o => o.UseInMemoryDatabase($"Data Source={dataBaseName}.db"),
                    ServiceLifetime.Transient
                );

                ServiceProvider = serviceCollection.BuildServiceProvider();
                using var context = ServiceProvider.GetService<DataContext>();
                context?.Database.EnsureCreated();
            }

            public void Dispose()
            {
                using var context = ServiceProvider.GetService<DataContext>();
                if (context == null) { return; }
                Dispose(true, context);
                GC.SuppressFinalize(this);
            }

            protected virtual void Dispose(bool dispose, DataContext context)
            {
                if (dispose)
                {
                    context?.Database.EnsureDeleted();
                }
            }
        }
    }
}