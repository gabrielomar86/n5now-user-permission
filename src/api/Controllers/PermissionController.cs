using System;
using UserPermission.core.interfaces.contratos.servicios;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using UserPermission.core.dto;

namespace UserPermission.api.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class PermissionController : ControllerBase
    {
        private readonly IPermissionService _permissionService;
        private readonly ILogger<PermissionController> _logger;

        public PermissionController(ILogger<PermissionController> logger,
                                    IPermissionService permissionService)
        {
            _logger = logger;
            _permissionService = permissionService;
        }

        [HttpGet]
        public IActionResult Get() => Ok(_permissionService.GetPermissions());

        [HttpPost]
        public IActionResult Create([FromBody] PermissionDto permissionDto) => Created("", _permissionService.RequestPermission(permissionDto));

        [HttpPatch("{id}")]
        public IActionResult Update(int id, [FromBody] PermissionDto permissionDto) => Ok(_permissionService.ModifyPermission(id, permissionDto));

    }
}
