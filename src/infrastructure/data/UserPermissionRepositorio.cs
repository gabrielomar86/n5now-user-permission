using UserPermission.core.entities;
using UserPermission.core.interfaces.contratos;

namespace UserPermission.infrastructure.data
{
    public class UserPermissionRepositorio : RepositorioGenerico<UserPermissionEntity>, IUserPermissionRepositorio
    {
        public UserPermissionRepositorio(UserPermissionContexto UserPermissionContexto) : base(UserPermissionContexto)
        {

        }
    }
}