using UserPermission.core.interfaces.contratos.servicios;
using Microsoft.Extensions.DependencyInjection;

namespace UserPermission.services
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IPermissionService, PermissionService>();

            return services;
        }
    }
}
