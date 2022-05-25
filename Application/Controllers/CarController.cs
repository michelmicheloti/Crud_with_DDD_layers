using Microsoft.AspNetCore.Mvc;
using Domain.Dto.Car;
using Domain.Interfaces.Services;
using Domain.Dto.Base;

namespace Application.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarController : Controller
    {
        private readonly ICarService _CarService;

        public CarController(ICarService CarService)
        {
            _CarService = CarService;
        }

        [HttpPost("Post/Create")]
        [ProducesResponseType(typeof(CarCreateResultDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(CarCreateResultDto), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateCar(CarCreateDto CarDTO)
        {
            CarCreateResultDto result = await _CarService.CreateCarAsync(CarDTO);

            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("Get/All")]
        [ProducesResponseType(typeof(GetMultipleCarResultDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(GetMultipleCarResultDto), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAllCars()
        {
            GetMultipleCarResultDto result = await _CarService.GetAllCarAsync();

            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("Get/All/Cor/{cor}")]
        [ProducesResponseType(typeof(GetMultipleCarResultDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(GetMultipleCarResultDto), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAllCarsByCor(string cor)
        {
            GetMultipleCarResultDto result = await _CarService.GetByCorCarAsync(cor);

            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("Get/All/Marca/{marca}")]
        [ProducesResponseType(typeof(GetMultipleCarResultDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(GetMultipleCarResultDto), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAllCarsByMarca(string marca)
        {
            GetMultipleCarResultDto result = await _CarService.GetByMarcaCarAsync(marca);

            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("Get/All/Modelo/{modelo}")]
        [ProducesResponseType(typeof(GetMultipleCarResultDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(GetMultipleCarResultDto), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAllCarsByModelo(string modelo)
        {
            GetMultipleCarResultDto result = await _CarService.GetByModeloCarAsync(modelo);

            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("Get/All/Placa/{placa}")]
        [ProducesResponseType(typeof(GetMultipleCarResultDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(GetMultipleCarResultDto), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAllCarsByPlaca(string placa)
        {
            GetMultipleCarResultDto result = await _CarService.GetByPlacaCarAsync(placa);

            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPut("Put/")]
        [ProducesResponseType(typeof(CarUpdateResultDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(CarUpdateResultDto), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateCar([FromBody] CarUpdateDto car)
        {
            CarUpdateResultDto? result = await _CarService.UpdateCarAsync(car);

            return result.Success ? Ok(result) : BadRequest(result);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpDelete("Delete/{id}")]
        [ProducesResponseType(typeof(CarUpdateResultDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(CarUpdateResultDto), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteCar(int id)
        {
            ResultDto? result = await _CarService.DeleteCarAsync(id);

            return result.Success ? Ok(result) : BadRequest(result);
        }
    }
}
