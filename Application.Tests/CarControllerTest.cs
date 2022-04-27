using System.Threading.Tasks;
using Application.Controllers;
using Domain.Dto.Car;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Application.Tests;

public class CarControllerTest
{
    private CarController? _controller;

    [Fact(DisplayName = "Foi possível criar um carro")]
    public async Task CreateCar()
    {

        var service = new Mock<ICarService>();
        service.Setup(m => m.CreateCarAsync(It.IsAny<CarCreateDto>())).ReturnsAsync(

        new CarCreateResultDto
        {
            Message = "Success",
            Success = true,
        }
        );

        _controller = new CarController(service.Object);
        CarCreateDto carCreateDto = new()
        {
            Cor = "Rosa",
            Marca = "Audi",
            Modelo = "TT",
            Placa = "DFA-1034"
        };
        var result = await _controller.CreateCar(carCreateDto);

        Assert.True(result is OkObjectResult);
    }
}