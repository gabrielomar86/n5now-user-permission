
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
    public class UserPermissionServicioTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IRepositorioWrapper> _mockRepositorioWrapper;

        public UserPermissionServicioTest()
        {
            _mapper = new MapperConfiguration(opts => { opts.AddProfile(typeof(UserPermissionMappingProfile)); }).CreateMapper();
            _mockRepositorioWrapper = new Mock<IRepositorioWrapper>();
        }

        [Fact]
        public void Should_ObtenerPorId()
        {
            // Arrange
            var UserPermissionServicio = ObtenerUserPermissionServicio();
            _mockRepositorioWrapper
                .Setup(mrw => mrw.UserPermissionRepositorio.BuscarPorCondicion(It.IsAny<Expression<Func<UserPermissionEntity, bool>>>()))
                .Returns(ObtenerEntidadesQueryable());

            // Act
            var resultado = UserPermissionServicio.ObtenerPorId(It.IsAny<Guid>());

            // Assert
            Assert.IsType<UserPermissionDto>(resultado);
            _mockRepositorioWrapper
                .Verify(mrw => mrw.UserPermissionRepositorio.BuscarPorCondicion(It.IsAny<Expression<Func<UserPermissionEntity, bool>>>()), Times.Once);
        }

        [Fact]
        public void Should_ObtenerTodos()
        {
            // Arrange
            var UserPermissionServicio = ObtenerUserPermissionServicio();
            _mockRepositorioWrapper
                .Setup(mrw => mrw.UserPermissionRepositorio.ObtenerTodo())
                .Returns(ObtenerEntidadesQueryable());

            // Act
            var resultado = UserPermissionServicio.ObtenerTodos();

            // Assert
            Assert.IsType<List<UserPermissionDto>>(resultado);
            Assert.Single(resultado);
            _mockRepositorioWrapper
                .Verify(mrw => mrw.UserPermissionRepositorio.ObtenerTodo(), Times.Once);
        }

        #region Private Methods

        private IUserPermissionServicio ObtenerUserPermissionServicio()
        {
            return new UserPermissionServicio(_mapper, _mockRepositorioWrapper.Object);
        }

        private IQueryable<UserPermissionEntity> ObtenerEntidadesQueryable()
        {
            var listado = new List<UserPermissionEntity>
            {
                new UserPermissionEntity()
            };

            return listado.AsQueryable();
        }
        #endregion
    }
}
