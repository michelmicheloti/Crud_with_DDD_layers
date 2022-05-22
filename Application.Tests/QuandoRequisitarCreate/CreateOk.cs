using System.Threading.Tasks;
using Application.Controllers;
using Domain.Dto.Car;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Application.Tests.QuandoRequisitarCreate;

public class CreateOk

{
    private CarController? _controller;

    [Fact(DisplayName = "É possível realizar o create")]
    public async Task E_Possivel_Invocar_Controller_Create()
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