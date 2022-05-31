using System;
using System.Linq;
using System.Linq.Expressions;
using UserPermission.core.interfaces.contratos;
using Microsoft.EntityFrameworkCore;

namespace UserPermission.infrastructure.data
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        protected readonly PermissionContext _permissionContext;

        public GenericRepository(PermissionContext permissionContext)
        {
            _permissionContext = permissionContext;
        }

        public TEntity Update(TEntity entity)
        {
            _permissionContext.Set<TEntity>().Update(entity);
            _permissionContext.SaveChanges();
            return entity;
        }

        public IQueryable<TEntity> FindByCondition(Expression<Func<TEntity, bool>> expresion)
        {
            return _permissionContext.Set<TEntity>().Where(expresion).AsNoTracking();
        }

        public void Delete(TEntity entity)
        {
            _permissionContext.Set<TEntity>().Remove(entity);
        }

        public TEntity Insert(TEntity entity)
        {
            _permissionContext.Set<TEntity>().Add(entity);
            _permissionContext.SaveChanges();
            return entity;
        }

        public IQueryable<TEntity> GetAll()
        {
            return _permissionContext.Set<TEntity>().AsNoTracking();
        }
    }
}