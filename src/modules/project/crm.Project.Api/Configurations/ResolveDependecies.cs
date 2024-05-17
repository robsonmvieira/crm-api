using crm.Project.Domain.repositories;
using crm.Project.Infra.Repositories;

namespace crm.Project.Api.Configurations
{
    public static class ResolveDependencies
    {
        public static IServiceCollection AddUseCases(this IServiceCollection services)
        {
            services.ResolveDomainDependencies();
            return services;
        }
        private static IServiceCollection ResolveDomainDependencies(this IServiceCollection services)
        {
            // services.AddScoped<IUnitOfWork, UnitOfWork>();
            // services.AddScoped<INotificatorService, NotificationService>();
            services.AddScoped<IProjectRepository, ProjectRepository>();
            return services;
        }
    }
}