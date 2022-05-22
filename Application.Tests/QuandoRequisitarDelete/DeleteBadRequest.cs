using System.Threading.Tasks;
using Application.Controllers;
using Domain.Dto.Base;
using Domain.Dto.Car;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Application.Tests.QuandoRequisitarDelete;

public class DeleteBadRequest
{
    private CarController? _controller;

    [Fact(DisplayName = "Não é possível deletar um carro")]
    public async Task Nao_E_Possivel_Invocar_Controller_Delete()
    {
        var serviceMock = new Mock<ICarService>();

        serviceMock.Setup(m => m.DeleteCarAsync(It.IsAny<int>())).ReturnsAsync(
            new ResultDto
            {
                Message = "Error",
                Success = false,
            }
        );

        _controller = new CarController(serviceMock.Object);
        _controller.ModelState.AddModelError("Error","Internal Error");

        var result = await _controller.DeleteCar(Faker.RandomNumber.Next());

        Assert.True(result is BadRequestObjectResult);
        Assert.False(_controller.ModelState.IsValid);
    }
}