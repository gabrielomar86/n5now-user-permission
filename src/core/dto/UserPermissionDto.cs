using System;

namespace UserPermission.core.dto
{
    public class UserPermissionDto
    {

        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Valor { get; set; }
        public DateTime FechaCreacionRegistro { get; set; }
        public bool Activo { get; set; } = true;

    }
}