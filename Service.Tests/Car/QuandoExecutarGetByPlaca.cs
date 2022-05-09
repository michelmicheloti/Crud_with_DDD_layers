using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Dto.Car;
using Domain.Interfaces.Services;
using Moq;
using Service.Services;
using Xunit;

namespace Service.Tests.Car
{
    public class QuandoExecutarGetByPlaca : CarTest
    {
        private ICarService? _service;
        private Mock<ICarService>? _serviceMock;

        [Fact(DisplayName = "É Possivel Executar Get By Placa")]
        [Trait("Car Service GetByPlaca", "E Possivel Executar")]
        public async Task E_Possivel_Executar_Get_By_Placa()
        {
            _serviceMock = new Mock<ICarService>();
            _serviceMock.Setup(m => m.GetByPlacaCarAsync(PlacaCar))
                        .Returns(Task.FromResult(getMultipleCarResultDto));
            _service = _serviceMock.Object;

            var result = await _service.GetByPlacaCarAsync(PlacaCar);
            Assert.NotNull(result);
            Assert.True(result.Count == 10);

            var emptyListResult = new GetMultipleCarResultDto();
            _serviceMock = new Mock<ICarService>();
            _serviceMock.Setup(m => m.GetByPlacaCarAsync(PlacaCar))
                        .Returns(Task.FromResult(emptyListResult));
            _service = _serviceMock.Object;

            GetMultipleCarResultDto? resultEmpty = await _service.GetByPlacaCarAsync(PlacaCar);
            Assert.True(resultEmpty.Cars == null);
            Assert.True(resultEmpty.Count == 0);
            Assert.True(resultEmpty.Message == null);
            Assert.False(resultEmpty.Success);
        }
    }
}