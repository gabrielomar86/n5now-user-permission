using UserPermission.core.interfaces.contratos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace UserPermission.infrastructure.data
{
    public static class InfrastructureExtension
    {
        public static IServiceCollection AddInfraestructura(this IServiceCollection servicios, string cadenaConexion)
        {
            servicios.AddScoped<IRepositorioWrapper, RepositorioWrapper>();

            servicios.AddDbContext<UserPermissionContexto>(
                x => x.UseSqlite(cadenaConexion)
            );

            return servicios;
        }

    }
}
