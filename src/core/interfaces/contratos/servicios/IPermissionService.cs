using System;
using System.Collections.Generic;
using UserPermission.core.dto;

namespace UserPermission.core.interfaces.contratos.servicios
{
    public interface IPermissionService
    {
        List<PermissionDto> GetPermissions();
        PermissionDto RequestPermission(PermissionDto permission);
        PermissionDto ModifyPermission(int permissionId, PermissionDto permission);
    }
}