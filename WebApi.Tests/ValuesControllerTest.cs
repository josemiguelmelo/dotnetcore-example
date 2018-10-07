using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebApi.Api.Controllers;
using WebApi.BusinessEntities;
using WebApi.BusinessServices.Interfaces;
using WebApi.BusinessServices.Implementations;
using Xunit;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace WebApi.Tests
{
    public class ValuesControllerTest
    {
        ValuesController _controller;
        IValueService _service;

        public static IConfiguration InitConfiguration()
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(AppContext.BaseDirectory, "../../../"))
                .AddJsonFile("appsettings.test.json", optional: false)
                .Build();
            return config;
        }
        public ValuesControllerTest()
        {
            var config = InitConfiguration();

            _service = new ValueService(config);
            _controller = new ValuesController(_service);
        }
        [Fact]
        public void Get_ReturnsOk()
        {
            var okResult = _controller.Get();

            Assert.IsType<OkObjectResult>(okResult.Result);
        }

        [Fact]
        public void Get_ReturnsAllValues()
        {
            var okResult = _controller.Get().Result as OkObjectResult;

            var values = Assert.IsType<List<ValueEntity>>(okResult.Value);

            Assert.Equal(0, values.Count);
        }
    }
}
