using System;
using System.Linq;
using System.Linq.Expressions;
using UserPermission.core.interfaces.contratos;
using Microsoft.EntityFrameworkCore;

namespace UserPermission.infrastructure.data
{
    public class RepositorioGenerico<TEntidad> : IRepositorioGenerico<TEntidad> where TEntidad : class
    {
        protected readonly UserPermissionContexto _UserPermissionContexto;

        public RepositorioGenerico(UserPermissionContexto UserPermissionContexto)
        {
            _UserPermissionContexto = UserPermissionContexto;
        }

        public void Actualizar(TEntidad entidad)
        {
            _UserPermissionContexto.Set<TEntidad>().Update(entidad);
            _UserPermissionContexto.SaveChanges();
        }

        public IQueryable<TEntidad> BuscarPorCondicion(Expression<Func<TEntidad, bool>> expresion)
        {
            return _UserPermissionContexto.Set<TEntidad>().Where(expresion).AsNoTracking();
        }

        public void Eliminar(TEntidad entidad)
        {
            _UserPermissionContexto.Set<TEntidad>().Remove(entidad);
        }

        public void Insertar(TEntidad entidad)
        {
            _UserPermissionContexto.Set<TEntidad>().Add(entidad);
            _UserPermissionContexto.SaveChanges();
        }

        public IQueryable<TEntidad> ObtenerTodo()
        {
            return _UserPermissionContexto.Set<TEntidad>().AsNoTracking();
        }
    }
}