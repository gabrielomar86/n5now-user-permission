using UserPermission.core.entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace UserPermission.infrastructure.data
{
    public class PermissionTypeSeed : IEntityTypeConfiguration<PermissionTypeEntity>
    {
        public void Configure(EntityTypeBuilder<PermissionTypeEntity> builder)
        {
            builder.HasData(
                new PermissionTypeEntity
                {
                    Id = 1,

                    Description = "mockData1"

                },
                new PermissionTypeEntity
                {
                    Id = 2,

                    Description = "mockData2"

                },
                new PermissionTypeEntity
                {
                    Id = 3,

                    Description = "mockData3"

                }
            );
        }
    }
}