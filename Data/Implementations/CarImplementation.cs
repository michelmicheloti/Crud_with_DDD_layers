using Data.Context;
using Data.Repository;
using Domain.Entity;
using Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace Data.Implementations
{
    public class CarImplementation : BaseRepository<CarEntity>, ICarRepository
    {
        private readonly DbSet<CarEntity> _dataset;

        public CarImplementation(DataContext context) : base(context)
        {
            _dataset = context.Set<CarEntity>();
        }

        public async Task<IEnumerable<CarEntity>> SelectByMarcaAsync(string marca)
                => await _dataset.AsNoTracking()
                                .Where(car => car.Marca.Equals(marca))
                                .ToListAsync();
        public async Task<IEnumerable<CarEntity>> SelectByModeloAsync(string modelo)
                => await _dataset.AsNoTracking()
                                .Where(car => car.Modelo.Equals(modelo))
                                .ToListAsync();
        public async Task<IEnumerable<CarEntity>> SelectByPlacaAsync(string placa)
                => await _dataset.AsNoTracking()
                                .Where(car => car.Placa.Equals(placa))
                                .ToListAsync();
        public async Task<IEnumerable<CarEntity>> SelectByCorAsync(string cor)
                => await _dataset.AsNoTracking()
                                .Where(car => car.Cor.Equals(cor))
                                .ToListAsync();
    }
}
