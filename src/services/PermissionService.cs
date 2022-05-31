using UserPermission.core.dto;
using UserPermission.core.interfaces.contratos;
using UserPermission.core.interfaces.contratos.servicios;
using System;
using System.Linq;
using System.Collections.Generic;
using AutoMapper;
using UserPermission.core.entities;

namespace UserPermission.services
{
    public class PermissionService : IPermissionService
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryWrapper _repositoryWrapper;
        public static string notFoundMessage = "Permission with id: [id] not found";
        public PermissionService(IMapper mapper,
                                 IRepositoryWrapper repositoryWrapper)
        {
            _mapper = mapper;
            _repositoryWrapper = repositoryWrapper;
        }

        public PermissionDto RequestPermission(PermissionDto permission)
        {
            var entity = _repositoryWrapper
                ._permissionRepository
                .Insert(_mapper.Map<PermissionEntity>(permission));

            return _mapper.Map<PermissionDto>(entity);
        }

        public List<PermissionDto> GetPermissions()
        {
            var entities = _repositoryWrapper._permissionRepository.GetAll();
            return _mapper.Map<List<PermissionDto>>(entities);
        }

        public PermissionDto ModifyPermission(int permissionId, PermissionDto permission)
        {
            var entity = _repositoryWrapper
                ._permissionRepository
                .FindByCondition(x => x.Id == permissionId);

            if (entity == null || !entity.Any())
                throw new Exception(notFoundMessage.Replace("[id]", permissionId.ToString()));

            var entityUpdated = _repositoryWrapper._permissionRepository.Update(_mapper.Map<PermissionEntity>(permission));

            return _mapper.Map<PermissionDto>(entityUpdated);
        }
    }
}