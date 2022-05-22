using System.Threading.Tasks;
using Application.Controllers;
using Domain.Dto.Car;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Application.Tests.QuandoRequisitarUpdate;

public class UpdateOk
{
    private CarController? _controller;

    [Fact(DisplayName = "É possível criar um carro")]
    public async Task E_Possivel_Invocar_Controller_Update()
    {
        var serviceMock = new Mock<ICarService>();

        serviceMock.Setup(m => m.UpdateCarAsync(It.IsAny<CarUpdateDto>())).ReturnsAsync(
            new CarUpdateResultDto
            {
                Message = "Success",
                Success = true,
            }
        );

        _controller = new CarController(serviceMock.Object);

        CarUpdateDto carUpdateDto = new()
        {
            Id = Faker.RandomNumber.Next(),
            Cor = Faker.Name.First(),
            Marca = Faker.Name.First(),
            Modelo = Faker.Name.First(),
            Placa = Faker.Name.First()
        };

        var result = await _controller.UpdateCar(carUpdateDto);

        Assert.True(result is OkObjectResult);

        var resultValue = ((OkObjectResult)result).Value as CarUpdateResultDto;
        Assert.NotNull(resultValue);
        Assert.True(resultValue?.Success);
    }
}