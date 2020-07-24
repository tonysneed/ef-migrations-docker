using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EfMigrationsDocker
{
    public class ProductsDbContext : DbContext
    {
        private readonly IConfiguration config;

        public DbSet<Product> Products { get; set; }

        public ProductsDbContext(IConfiguration config)
        {
            this.config = config;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = config.GetSection($"ConnectionStrings:{nameof(ProductsDbContext)}").Value;
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
