using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,IConfiguration configuration )
        {
            services.AddDbContext<ProductDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DBConnection"), x =>
                {
                    x.EnableRetryOnFailure();


                    x.MigrationsAssembly(typeof(DependencyInjection).Assembly.FullName);
                });

            });
            return services;
        }
    }
}
