using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entity;
using Domain.Interfaces;

namespace Domain.Repository
{
    public interface ICarRepository : IBaseRepository<CarEntity>
    {
        Task<IEnumerable<CarEntity>> SelectByMarcaAsync(string marca);
        Task<IEnumerable<CarEntity>> SelectByModeloAsync(string modelo);
        Task<IEnumerable<CarEntity>> SelectByPlacaAsync(string placa);
        Task<IEnumerable<CarEntity>> SelectByCorAsync(string cor);
    }
}