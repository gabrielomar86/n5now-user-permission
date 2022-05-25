using UserPermission.core.dto;
using UserPermission.core.interfaces.contratos;
using UserPermission.core.interfaces.contratos.servicios;
using System;
using System.Linq;
using System.Collections.Generic;
using AutoMapper;

namespace UserPermission.services
{
    public class UserPermissionServicio : IUserPermissionServicio
    {
        private readonly IMapper _mapper;
        private readonly IRepositorioWrapper _repositorioWrapper;

        public UserPermissionServicio(IMapper mapper,
                                        IRepositorioWrapper repositorioWrapper)
        {
            _mapper = mapper;
            _repositorioWrapper = repositorioWrapper;
        }

        public UserPermissionDto ObtenerPorId(Guid id)
        {
            var entity = _repositorioWrapper
                .UserPermissionRepositorio
                .BuscarPorCondicion(smp => smp.Id == id)
                .FirstOrDefault();
            return _mapper.Map<UserPermissionDto>(entity);
        }

        public List<UserPermissionDto> ObtenerTodos()
        {
            var entities = _repositorioWrapper.UserPermissionRepositorio.ObtenerTodo();
            return _mapper.Map<List<UserPermissionDto>>(entities);
        }

    }
}