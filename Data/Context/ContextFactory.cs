using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Data.Context
{
    public class ContextFactory : IDesignTimeDbContextFactory<DataContext>
    {
        public DataContext CreateDbContext(string[] args)
        {
            string path = Directory.GetCurrentDirectory();
            path = Path.GetFullPath(Path.Combine(path, @"..\"));
            path = @$"{path}\Application\database.json";

            IConfiguration databaseConfiguration = new ConfigurationBuilder()
                                                        .AddJsonFile(path)
                                                        .Build();

            DbContextOptionsBuilder<DataContext> optionsBuilder = new();

            optionsBuilder.UseSqlite(databaseConfiguration.GetConnectionString("DefaultConnection"));
                        //   .UseSqlServer(databaseConfiguration.GetConnectionString("DefaultConnection"));

            return new DataContext(optionsBuilder.Options);
        }
    }
}
