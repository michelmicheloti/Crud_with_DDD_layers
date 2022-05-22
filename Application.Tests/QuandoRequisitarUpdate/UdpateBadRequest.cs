using System.Threading.Tasks;
using Application.Controllers;
using Domain.Dto.Car;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Application.Tests.QuandoRequisitarUpdate;

public class UdpateBadRequest
{
    private CarController? _controller;

    [Fact(DisplayName = "Não é possível criar um carro")]
    public async Task Nao_E_Possivel_Invocar_Controller_Update()
    {
        var serviceMock = new Mock<ICarService>();

        serviceMock.Setup(m => m.UpdateCarAsync(It.IsAny<CarUpdateDto>())).ReturnsAsync(
            new CarUpdateResultDto
            {
                Message = "Error",
                Success = false,
            }
        );

        _controller = new CarController(serviceMock.Object);
        _controller.ModelState.AddModelError("Error","Internal Error");

        CarUpdateDto carUpdateDto = new()
        {
            Id = Faker.RandomNumber.Next(),
            Cor = Faker.Name.First(),
            Marca = Faker.Name.First(),
            Modelo = Faker.Name.First(),
            Placa = Faker.Name.First()
        };

        var result = await _controller.UpdateCar(carUpdateDto);

        Assert.True(result is BadRequestObjectResult);
        Assert.False(_controller.ModelState.IsValid);
    }
}