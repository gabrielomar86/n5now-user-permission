using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserPermission.core.entities
{
    /// <summary>
    /// Entidad base
    /// </summary>
    public class EntidadBase<TKey>
    {
        /// <summary>
        /// Identificador de la entidad
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public TKey Id { get; set; }

    }
}