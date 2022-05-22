using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Controllers;
using Domain.Dto.Car;
using Domain.Dto.DatabaseEntities;
using Domain.Entity;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Application.Tests.QuandoRequisitarGetByModelo
{
    public class GetByModeloRequest
    {
        private CarController? _controller;

        [Fact(DisplayName = "Não é possível obter todos os carro pela modelo")]
        public async Task Nao_E_Possivel_Invocar_Controller_GetByModelo()
        {
            var serviceMock = new Mock<ICarService>();

            CarEntity car = new()
            {
                Id = Faker.RandomNumber.Next(),
                Cor = Faker.Name.First(),
                Marca = Faker.Name.First(),
                Modelo  = "Branco",
                Placa = Faker.Name.First(),
            };

            List<CarEntityDto>? entityResult = new()
            {
                new CarEntityDto(car),
                new CarEntityDto(car)
            };            

            serviceMock.Setup(m => m.GetByModeloCarAsync(It.IsAny<string>())).ReturnsAsync(
                new GetMultipleCarResultDto
                {
                    Message = "Error",
                    Success = false,
                    Cars = entityResult,
                    Count = entityResult.Count
                }
            );

            _controller = new CarController(serviceMock.Object);
            _controller.ModelState.AddModelError("Error", "Internal Error");

            var result = await _controller.GetAllCarsByModelo("Branco");
            Assert.True(result is BadRequestObjectResult);
            Assert.False(_controller.ModelState.IsValid);
        }
    }
}