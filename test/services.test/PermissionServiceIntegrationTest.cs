
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Moq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
using UserPermission.api;
using UserPermission.core.dto;
using UserPermission.core.extensiones;
using UserPermission.core.interfaces.contratos;
using UserPermission.core.interfaces.contratos.servicios;
using UserPermission.infrastructure.data;
using Xunit;

namespace UserPermission.services.test
{
    public class PermissionServiceIntegrationTest
    {
        private readonly IHost _host;

        public PermissionServiceIntegrationTest()
        {
            Environment.SetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", "Development");
            _host = new HostBuilder()
                .ConfigureWebHost(webHostBuilder =>
                {
                    webHostBuilder.UseEnvironment("Development");
                    webHostBuilder.UseStartup<Startup>();
                    webHostBuilder.UseTestServer();
                }).Build();
        }

        [Fact]
        public async void GetPermissionsTest()
        {
            await _host.StartAsync();
            var response = await _host.GetTestServer().CreateClient().GetAsync("/Permissions");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async void RequestPermissionTest()
        {
            await _host.StartAsync();
            var body = new PermissionDto()
            {
                EmployeeForename = "Juan",
                EmployeeSurname = "Perez",
                PermissionTypeId = 1,
                PermissionDate = DateTime.Now
            };
            var bodyString = new StringContent(JsonConvert.SerializeObject(body));
            bodyString.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            var response = await _host.GetTestServer().CreateClient().PostAsync("/Permissions", bodyString);
            var responseObject = JsonConvert.DeserializeObject<PermissionDto>(await response.Content.ReadAsStringAsync());
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
            Assert.True(responseObject.Id > 0);
        }
    }
}
