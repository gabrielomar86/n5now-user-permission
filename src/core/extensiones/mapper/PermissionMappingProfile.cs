using AutoMapper;
using UserPermission.core.dto;
using UserPermission.core.entities;

namespace UserPermission.core.extensiones
{
    public class PermissionMappingProfile : Profile
    {
        public PermissionMappingProfile()
        {
            CreateMap<PermissionEntity, PermissionDto>().ReverseMap();
        }
    }
}
