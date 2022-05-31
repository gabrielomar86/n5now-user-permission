using UserPermission.core.entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace UserPermission.infrastructure.data
{
    public class EmployeeSeed : IEntityTypeConfiguration<PermissionEntity>
    {
        public void Configure(EntityTypeBuilder<PermissionEntity> builder)
        {
            builder.HasData(
                new PermissionEntity
                {
                    Id = 1,

                    EmployeeForename = "mockData1",

                    EmployeeSurname = "mockData1",

                    PermissionTypeId = 1,
                    PermissionDate = DateTime.Now

                },
                new PermissionEntity
                {
                    Id = 2,

                    EmployeeForename = "mockData2",

                    EmployeeSurname = "mockData2",

                    PermissionTypeId = 2,
                    PermissionDate = DateTime.Now

                },
                new PermissionEntity
                {
                    Id = 3,

                    EmployeeForename = "mockData3",

                    EmployeeSurname = "mockData3",

                    PermissionTypeId = 3,
                    PermissionDate = DateTime.Now

                }
            );
        }
    }
}