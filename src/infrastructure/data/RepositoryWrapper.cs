using UserPermission.core.interfaces.contratos;

namespace UserPermission.infrastructure.data
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly PermissionContext _permissionContext;
        private IPermissionRepository permissionRepository;

        public RepositoryWrapper(PermissionContext permissionContextWrapper)
        {
            _permissionContext = permissionContextWrapper;
        }

        public IPermissionRepository _permissionRepository
        {
            get
            {
                if (permissionRepository == null)
                {
                    permissionRepository = new PermissionRepository(_permissionContext);
                }
                return permissionRepository;
            }
        }

        public void CommitTransaction()
        {
            _permissionContext.CommitTransaction();
        }

        public void Save()
        {
            _permissionContext.SaveChanges();
        }

        public void BeginTransaction()
        {
            _permissionContext.BeginTransaction();
        }

        public void RollbackTransaction()
        {
            _permissionContext.RollbackTransaction();
        }
    }
}