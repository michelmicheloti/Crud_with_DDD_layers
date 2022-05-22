using Domain.Entity;
using Domain.Interfaces;
using Domain.Interfaces.Services;
using Domain.Repository;
using Domain.Dto.Car;
using Domain.Dto.Base;
using Domain.Dto.DatabaseEntities;

namespace Service.Services
{
    public class CarService : BaseService<CarEntity>, ICarService
    {
        private readonly ICarRepository _carRepository;
        public CarService(IBaseRepository<CarEntity> baseRepository, ICarRepository CarRepository) : base(baseRepository)
        {
            _carRepository = CarRepository;
        }

        public async Task<CarCreateResultDto> CreateCarAsync(CarCreateDto car)
        {
            try
            {
                CarEntity CarEntity = new()
                {
                    Cor = car.Cor.ToLower(),
                    Marca = car.Marca.ToLower(),
                    Modelo = car.Modelo.ToLower(),
                    Placa = car.Placa.ToLower()
                };

                await InsertAsync(CarEntity);

                return new CarCreateResultDto
                {
                    Message = "Success",
                    Success = true
                };
            }
            catch
            {
                return new CarCreateResultDto
                {
                    Message = $"Errou ao criar o carro com a placa {car.Placa}",
                    Success = false
                };
            }
        }

        public async Task<ResultDto> DeleteCarAsync(int id)
        {
            try
            {
                await DeleteAsync(id);

                return new ResultDto
                {
                    Message = "Success",
                    Success = true
                };
            }
            catch
            {
                return new ResultDto
                {
                    Message = "Internal server error",
                    Success = false
                };
            }
        }

        public async Task<GetMultipleCarResultDto> GetAllCarAsync()
        {
            try
            {
                List<CarEntityDto>? entityResult = 
                                (await SelectAsync())
                                .Select(car => new CarEntityDto(car))
                                .ToList();

                return new GetMultipleCarResultDto
                {
                    Message = "Success",
                    Success = true,
                    Cars = entityResult,
                    Count = entityResult.Count
                };
            }
            catch
            {
                return new GetMultipleCarResultDto
                {
                    Message = "Internal server error",
                    Success = false
                };
            }
        }

        public async Task<GetMultipleCarResultDto> GetByCorCarAsync(string cor)
        {
            try
            {
                List<CarEntityDto>? entityResult = 
                            (await _carRepository.SelectByCorAsync(cor))
                            .Select(car => new CarEntityDto(car))
                            .ToList();

                return new GetMultipleCarResultDto
                {
                    Message = "Success",
                    Success = true,
                    Cars = entityResult,
                    Count = entityResult.Count
                };
            }
            catch
            {
                return new GetMultipleCarResultDto
                {
                    Message = "Internal server error",
                    Success = false
                };
            }
        }

        public async Task<GetMultipleCarResultDto> GetByMarcaCarAsync(string marca)
        {
            try
            {
                List<CarEntityDto>? entityResult = (await _carRepository.SelectByMarcaAsync(marca))
                                                                            .Select(car => new CarEntityDto(car))
                                                                            .ToList();

                return new GetMultipleCarResultDto
                {
                    Message = "Success",
                    Success = true,
                    Cars = entityResult,
                    Count = entityResult.Count
                };

            }
            catch
            {
                return new GetMultipleCarResultDto
                {
                    Message = "Internal server error",
                    Success = false
                };
            }
        }

        public async Task<GetMultipleCarResultDto> GetByModeloCarAsync(string modelo)
        {

            try
            {
                List<CarEntityDto>? entityResult = (await _carRepository.SelectByModeloAsync(modelo))
                                                                            .Select(car => new CarEntityDto(car))
                                                                            .ToList();

                return new GetMultipleCarResultDto
                {
                    Message = "Success",
                    Success = true,
                    Cars = entityResult,
                    Count = entityResult.Count
                };

            }
            catch
            {
                return new GetMultipleCarResultDto
                {
                    Message = "Internal server error",
                    Success = false
                };
            }
        }

        public async Task<GetMultipleCarResultDto> GetByPlacaCarAsync(string placa)
        {
            try
            {
                List<CarEntityDto>? entityResult = (await _carRepository.SelectByPlacaAsync(placa))
                                                                        .Select(car => new CarEntityDto(car))
                                                                        .ToList();

                return new GetMultipleCarResultDto
                {
                    Message = "Success",
                    Success = true,
                    Cars = entityResult,
                    Count = entityResult.Count
                };
            }
            catch
            {
                return new GetMultipleCarResultDto
                {
                    Message = "Internal server error",
                    Success = false
                };
            }
        }

        public async Task<CarUpdateResultDto> UpdateCarAsync(CarUpdateDto car)
        {
            try
            {
                CarEntity entity = new()
                {
                    Id = car.Id,
                    Cor = car.Cor.ToLower(),
                    Marca = car.Marca.ToLower(),
                    Modelo = car.Modelo.ToLower(),
                    Placa = car.Placa.ToLower()
                };

                await UpdateAsync(entity);

                return new CarUpdateResultDto
                {
                    Message = "Success",
                    Success = true
                }; 
            }
            catch
            {
                return new CarUpdateResultDto
                {
                    Message = "Internal server error",
                    Success = false
                };
            }
        }
    }
}
