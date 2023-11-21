using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Storage
{
    public static class Config
    {
        public static void ConfigureStorage(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DatabaseContext>(
                options => options.UseSqlite(configuration.GetConnectionString("Default"),
                options => options.MigrationsAssembly(typeof(DatabaseContext).Assembly.FullName)));

            services.AddScoped<DatabaseContext>();
        }
    }
}
