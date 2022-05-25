using UserPermission.core.interfaces.contratos;

namespace UserPermission.infrastructure.data
{
    public class RepositorioWrapper : IRepositorioWrapper
    {
        private readonly UserPermissionContexto _UserPermissionContexto;
        private IUserPermissionRepositorio _UserPermissionRepositorio;

        public RepositorioWrapper(UserPermissionContexto UserPermissionContexto)
        {
            _UserPermissionContexto = UserPermissionContexto;
        }

        public IUserPermissionRepositorio UserPermissionRepositorio
        {
            get
            {
                if (_UserPermissionRepositorio == null)
                {
                    _UserPermissionRepositorio = new UserPermissionRepositorio(_UserPermissionContexto);
                }
                return _UserPermissionRepositorio;
            }
        }

        public void ConfirmarTransaccion()
        {
            _UserPermissionContexto.ConfirmarTransaccion();
        }

        public void Guardar()
        {
            _UserPermissionContexto.SaveChanges();
        }

        public void IniciarTransaccion()
        {
            _UserPermissionContexto.IniciarTransaccion();
        }

        public void RevertirTransaccion()
        {
            _UserPermissionContexto.RevertirTransaccion();
        }
    }
}