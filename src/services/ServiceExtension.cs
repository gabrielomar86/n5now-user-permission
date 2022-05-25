using UserPermission.core.interfaces.contratos.servicios;
using Microsoft.Extensions.DependencyInjection;

namespace UserPermission.services
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddServicios(this IServiceCollection servicios)
        {
            servicios.AddScoped<IUserPermissionServicio, UserPermissionServicio>();

            return servicios;
        }
    }
}
