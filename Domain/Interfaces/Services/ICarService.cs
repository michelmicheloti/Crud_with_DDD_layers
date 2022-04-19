using Domain.Dto.Base;
using Domain.Dto.Car;
using Domain.Entity;

namespace Domain.Interfaces.Services
{
    public interface ICarService : IBaseService<CarEntity>
    {
        Task<CarCreateResultDto> CreateCarAsync(CarCreateDto car);
        Task<GetMultipleCarResultDto> GetAllCarAsync();
        Task<GetMultipleCarResultDto> GetByMarcaCarAsync(string marca);
        Task<GetMultipleCarResultDto> GetByModeloCarAsync(string modelo);
        Task<GetMultipleCarResultDto> GetByPlacaCarAsync(string placa);
        Task<GetMultipleCarResultDto> GetByCorCarAsync(string cor);
        Task<CarUpdateResultDto> UpdateCarAsync(CarUpdateDto car);
        Task<ResultDto> DeleteCarAsync(int id);
    }
}