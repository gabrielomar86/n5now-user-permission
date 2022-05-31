using UserPermission.core.interfaces.contratos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace UserPermission.infrastructure.data
{
    public static class InfrastructureExtension
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, string stringConnection)
        {
            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();

            services.AddDbContext<PermissionContext>(
                x => x.UseSqlServer(stringConnection)
            );

            return services;
        }

    }
}
