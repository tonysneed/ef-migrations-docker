using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Threading.Tasks;

namespace EfMigrationsDocker
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var config = LoadConfiguration();
            using (var context = new ProductsDbContext(config))
            {
                Console.WriteLine("Applying migrations ...");
                await context.Database.MigrateAsync();
                Console.WriteLine("Migrations applied.");
            }
        }

        private static IConfiguration LoadConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables();
            return builder.Build();
        }
    }
}
