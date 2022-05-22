using System.Threading.Tasks;
using Application.Controllers;
using Domain.Dto.Base;
using Domain.Dto.Car;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Application.Tests.QuandoRequisitarDelete;

public class DeleteOk
{
    private CarController? _controller;

    [Fact(DisplayName = "É possível deletar um carro")]
    public async Task E_Possivel_Invocar_Controller_Delete()
    {
        var serviceMock = new Mock<ICarService>();

        serviceMock.Setup(m => m.DeleteCarAsync(It.IsAny<int>())).ReturnsAsync(
            new ResultDto
            {
                Message = "Success",
                Success = true,
            }
        );

        _controller = new CarController(serviceMock.Object);

        var result = await _controller.DeleteCar(Faker.RandomNumber.Next());

        Assert.True(result is OkObjectResult);

        var resultValue = ((OkObjectResult)result).Value as ResultDto;
        Assert.NotNull(resultValue);
        Assert.True(resultValue?.Success);
    }
}