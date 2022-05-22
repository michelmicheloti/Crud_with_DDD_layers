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

namespace Application.Tests.QuandoRequisitarGetByPlaca
{
    public class GetByPlacaRequest
    {
        private CarController? _controller;

        [Fact(DisplayName = "Não é possível obter todos os carro pela placa")]
        public async Task Nao_E_Possivel_Invocar_Controller_GetByPlaca()
        {
            var serviceMock = new Mock<ICarService>();

            CarEntity car = new()
            {
                Id = Faker.RandomNumber.Next(),
                Cor = Faker.Name.First(),
                Marca = Faker.Name.First(),
                Modelo = Faker.Name.First(),
                Placa = "Branco",
            };

            List<CarEntityDto>? entityResult = new()
            {
                new CarEntityDto(car),
                new CarEntityDto(car)
            };            

            serviceMock.Setup(m => m.GetByPlacaCarAsync(It.IsAny<string>())).ReturnsAsync(
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

            var result = await _controller.GetAllCarsByPlaca("Branco");
            Assert.True(result is BadRequestObjectResult);
            Assert.False(_controller.ModelState.IsValid);
        }
    }
}