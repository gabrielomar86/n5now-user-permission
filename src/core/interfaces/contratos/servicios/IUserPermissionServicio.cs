using System;
using System.Collections.Generic;
using UserPermission.core.dto;

namespace UserPermission.core.interfaces.contratos.servicios
{
    public interface IUserPermissionServicio
    {
        UserPermissionDto ObtenerPorId(Guid id);
        List<UserPermissionDto> ObtenerTodos();
    }
}