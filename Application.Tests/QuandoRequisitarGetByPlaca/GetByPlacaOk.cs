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
    public class GetByPlacaOk
    {
        private CarController? _controller;

        [Fact(DisplayName = "É possível obter todos os carro pela placa")]
        public async Task E_Possivel_Invocar_Controller_GetByPlaca()
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
                    Message = "Success",
                    Success = true,
                    Cars = entityResult,
                    Count = entityResult.Count
                }
            );

            _controller = new CarController(serviceMock.Object);
            var result = await _controller.GetAllCarsByPlaca("Branco");
            Assert.True(result is OkObjectResult);

            var resultValue = ((OkObjectResult)result).Value as GetMultipleCarResultDto;
            Assert.True(resultValue?.Count == 2);
            Assert.True(resultValue?.Success);
        }
    }
}