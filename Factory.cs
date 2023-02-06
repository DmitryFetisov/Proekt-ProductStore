using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using ProductStore.Data;

namespace ProductStore
{
    //создание фабрики для работы с базой данных(миграциями)
    public class Factory : IDesignTimeDbContextFactory<AppDBContext>
    {
        public AppDBContext CreateDbContext(string[] args)
        {
           var optionsBuilder = new DbContextOptionsBuilder<AppDBContext>();
            ConfigurationBuilder builder1 = new ConfigurationBuilder();
            builder1.SetBasePath(Directory.GetCurrentDirectory());
            builder1.AddJsonFile("dbsettings.json");
            IConfigurationRoot config = builder1.Build();

            string? connectionString = config.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(connectionString, opts => opts.CommandTimeout((int)TimeSpan.FromMinutes(10).TotalSeconds));
            return new AppDBContext(optionsBuilder.Options);
        }
    }
}
