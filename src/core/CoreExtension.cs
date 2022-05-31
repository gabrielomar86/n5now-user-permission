using UserPermission.core.extensiones;
using Microsoft.Extensions.DependencyInjection;

namespace UserPermission.core
{
    public static class CoreExtension
    {
        public static IServiceCollection AddCore(this IServiceCollection services)
        {
            //Enable AutoMapper
            services.AddAutoMapper(typeof(PermissionMappingProfile));

            return services;
        }

    }
}
