using UserPermission.core.extensiones;
using Microsoft.Extensions.DependencyInjection;

namespace UserPermission.core
{
    public static class CoreExtension
    {
        public static IServiceCollection AddCore(this IServiceCollection servicios)
        {
            //Enable AutoMapper
            servicios.AddAutoMapper(typeof(UserPermissionMappingProfile));

            return servicios;
        }

    }
}
