using AutoMapper;
using UserPermission.core.dto;
using UserPermission.core.entities;

namespace UserPermission.core.extensiones
{
    public class UserPermissionMappingProfile : Profile
    {
        public UserPermissionMappingProfile()
        {
            CreateMap<UserPermissionEntity, UserPermissionDto>();
        }
    }
}
