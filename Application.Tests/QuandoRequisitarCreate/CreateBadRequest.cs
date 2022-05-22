using System.Threading.Tasks;
using Application.Controllers;
using Domain.Dto.Car;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Application.Tests.QuandoRequisitarCreate;

public class CreateBadRequest

{
    private CarController? _controller;

    [Fact(DisplayName = "Não é possível realizar o create")]
    public async Task Nao_E_Possivel_Invocar_Controller_Create()
    {

        var service = new Mock<ICarService>();
        service.Setup(m => m.CreateCarAsync(It.IsAny<CarCreateDto>())).ReturnsAsync(
            new CarCreateResultDto
            {
                Message = "Error",
                Success = false,
            }
        );

        _controller = new CarController(service.Object);
        _controller.ModelState.AddModelError("Error", "Internal Error");

        CarCreateDto carCreateDto = new()
        {
            Cor = "Rosa",
            Marca = "Audi",
            Modelo = "TT",
            Placa = "DFA-1034"
        };
        var result = await _controller.CreateCar(carCreateDto);

        Assert.True(result is BadRequestObjectResult);
        Assert.False(_controller.ModelState.IsValid);
    }
}