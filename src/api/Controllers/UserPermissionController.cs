using System;
using UserPermission.core.interfaces.contratos.servicios;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace UserPermission.api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserPermissionController : ControllerBase
    {
        private readonly IUserPermissionServicio _UserPermissionServicio;
        private readonly ILogger<UserPermissionController> _logger;

        public UserPermissionController(ILogger<UserPermissionController> logger,
                                          IUserPermissionServicio UserPermissionServicio)
        {
            _logger = logger;
            _UserPermissionServicio = UserPermissionServicio;
        }

        [HttpGet]
        public IActionResult Get() => Ok(_UserPermissionServicio.ObtenerTodos());

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(Guid id) => Ok(_UserPermissionServicio.ObtenerPorId(id));

    }
}
