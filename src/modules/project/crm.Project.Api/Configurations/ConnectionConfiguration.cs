using crm.Project.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace crm.Project.Api.Configurations
{
    public static class ConnectionConfiguration
    {
        public static IServiceCollection AddCustomConnections(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext(configuration);
            // .AddMediatR(typeof(CreateSupplierUseCase));
            return services;
        }

        private static IServiceCollection AddDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("crmDb");

            services.AddDbContext<MyDbContext>(options =>
            {
                // force run migrations
                options.UseNpgsql(connectionString)
                    .LogTo(Console.WriteLine, LogLevel.Information);
            });

            return services;
        }
    }
}