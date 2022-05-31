using System;
using System.Linq;
using System.Linq.Expressions;

namespace UserPermission.core.interfaces.contratos
{
    /// <summary>
    /// Repositorio Genérico
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IGenericRepository<TEntity>
    {
        /// <summary>
        /// Método que permite el retorno de una colección de la entidad
        /// </summary>
        /// <returns>Retorna todos los elementos de tipo entidad</returns>
        IQueryable<TEntity> GetAll();

        /// <summary>
        /// Método que permimte obtener un filtrado según la expresión ingresada
        /// </summary>
        /// <param name="expresion">Expresión para el filtrado de la información</param>
        /// <returns>Obtiene informacón filtrada según la expresión ingresada</returns>
        IQueryable<TEntity> FindByCondition(Expression<Func<TEntity, bool>> expresion);

        /// <summary>
        /// Método que permite la inserción de un registro
        /// </summary>
        /// <param name="entidad">Entidad</param>
        TEntity Insert(TEntity entidad);

        /// <summary>
        /// Método que permite la modificación de un registro
        /// </summary>
        /// <param name="entidad">Entidad</param>
        TEntity Update(TEntity entidad);

        /// <summary>
        /// Método que permite la eliminación de un registro
        /// </summary>
        /// <param name="entidad">Entidad</param>
        void Delete(TEntity entidad);
    }
}