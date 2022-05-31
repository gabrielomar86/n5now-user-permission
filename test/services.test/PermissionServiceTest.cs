
using AutoMapper;
using UserPermission.core.dto;
using UserPermission.core.entities;
using UserPermission.core.extensiones;
using UserPermission.core.interfaces.contratos;
using UserPermission.core.interfaces.contratos.servicios;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Xunit;

namespace UserPermission.services.test
{
    public class PermissionServiceTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IRepositoryWrapper> _mockRepositoryWrapper;

        public PermissionServiceTest()
        {
            _mapper = new MapperConfiguration(opts => { opts.AddProfile(typeof(PermissionMappingProfile)); }).CreateMapper();
            _mockRepositoryWrapper = new Mock<IRepositoryWrapper>();
        }

        [Fact]
        public void Should_RequestPermission()
        {
            // Arrange
            var permissionService = GetPermissionService();
            _mockRepositoryWrapper
                .Setup(mrw => mrw._permissionRepository.Insert(It.IsAny<PermissionEntity>()))
                .Returns(new PermissionEntity { Id = 1 });

            // Act
            var result = permissionService.RequestPermission(It.IsAny<PermissionDto>());

            // Assert
            Assert.IsType<PermissionDto>(result);
            _mockRepositoryWrapper
                .Verify(mrw => mrw._permissionRepository.Insert(It.IsAny<PermissionEntity>()), Times.Once);
        }

        [Fact]
        public void Should_ModifyPermission()
        {
            // Arrange
            var permissionService = GetPermissionService();
            _mockRepositoryWrapper
                .Setup(mrw => mrw._permissionRepository.FindByCondition(It.IsAny<Expression<Func<PermissionEntity, bool>>>()))
                .Returns(new List<PermissionEntity> { new PermissionEntity { Id = 1 } }.AsQueryable());

            _mockRepositoryWrapper
                .Setup(mrw => mrw._permissionRepository.Update(It.IsAny<PermissionEntity>()))
                .Returns(new PermissionEntity { Id = 1 });

            // Act
            var result = permissionService.ModifyPermission(1, It.IsAny<PermissionDto>());

            // Assert
            Assert.IsType<PermissionDto>(result);
            Assert.Equal(1, result.Id);
            _mockRepositoryWrapper
                .Verify(mrw => mrw._permissionRepository.FindByCondition(It.IsAny<Expression<Func<PermissionEntity, bool>>>()), Times.Once);
            _mockRepositoryWrapper
                .Verify(mrw => mrw._permissionRepository.Update(It.IsAny<PermissionEntity>()), Times.Once);
        }

        [Fact]
        public void Should_ModifyPermission_EntityNotFound()
        {
            // Arrange
            var permissionService = GetPermissionService();
            _mockRepositoryWrapper
                .Setup(mrw => mrw._permissionRepository.FindByCondition(It.IsAny<Expression<Func<PermissionEntity, bool>>>()));

            // Act - Assert
            var result = Assert.Throws<Exception>(() => permissionService.ModifyPermission(1, It.IsAny<PermissionDto>()));
            Assert.Equal(result.Message, PermissionService.notFoundMessage.Replace("[id]", "1"));
            _mockRepositoryWrapper
                .Verify(mrw => mrw._permissionRepository.FindByCondition(It.IsAny<Expression<Func<PermissionEntity, bool>>>()), Times.Once);
            _mockRepositoryWrapper
                .Verify(mrw => mrw._permissionRepository.Update(It.IsAny<PermissionEntity>()), Times.Never);
        }

        [Fact]
        public void Should_GetPermissions()
        {
            // Arrange
            var permissionService = GetPermissionService();
            _mockRepositoryWrapper
                .Setup(mrw => mrw._permissionRepository.GetAll())
                .Returns(GetEntitiesQueryable());

            // Act
            var result = permissionService.GetPermissions();

            // Assert
            Assert.IsType<List<PermissionDto>>(result);
            Assert.Equal(3, result.Count);
            _mockRepositoryWrapper
                .Verify(mrw => mrw._permissionRepository.GetAll(), Times.Once);
        }

        #region Private Methods

        private IPermissionService GetPermissionService()
        {
            return new PermissionService(_mapper, _mockRepositoryWrapper.Object);
        }

        private static IQueryable<PermissionEntity> GetEntitiesQueryable()
        {
            var permissions = new List<PermissionEntity>
            {
                new PermissionEntity(),
                new PermissionEntity(),
                new PermissionEntity(),
            };

            return permissions.AsQueryable();
        }
        #endregion
    }
}
