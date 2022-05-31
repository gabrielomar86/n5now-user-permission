using UserPermission.core.entities;
using UserPermission.core.interfaces.contratos;

namespace UserPermission.infrastructure.data
{
    public class PermissionRepository : GenericRepository<PermissionEntity>, IPermissionRepository
    {
        public PermissionRepository(PermissionContext permissionContext) : base(permissionContext)
        {

        }
    }
}