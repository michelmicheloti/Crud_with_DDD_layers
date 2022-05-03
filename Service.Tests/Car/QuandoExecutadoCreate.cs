using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Interfaces.Services;
using Moq;
using Xunit;

namespace Service.Tests.Car
{
    public class QuandoExecutadoCreate : CarTest
    {
        private ICarService? _service;
        private Mock<ICarService>? _serviceMock;

        [Fact(DisplayName = "É Possivel Executar Create")]
        [Trait("Car Service Create", "E Possivel Executar")]
        public async Task E_Possivel_Executar_Create()
        {
            _serviceMock = new Mock<ICarService>();
            _serviceMock.Setup(m => m.CreateCarAsync(carCreateDto))
                        .ReturnsAsync(carCreateResultDto);
            _service = _serviceMock.Object;

            var result = await _service.CreateCarAsync(carCreateDto);
            Assert.NotNull(result);
            Assert.Equal(MessageCar, result.Message);
            Assert.Equal(SuccessCar, result.Success);
        }
    }
}