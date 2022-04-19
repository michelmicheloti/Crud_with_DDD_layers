using Domain.Interfaces;
using Domain.Interfaces.Services;

namespace Service.Services
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : class
    {
        protected readonly IBaseRepository<TEntity> _baseRepository;

        public BaseService(IBaseRepository<TEntity> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public async Task<bool> DeleteAsync(int id) => await _baseRepository.DeleteAsync(id);
        public async Task<bool> ExistAsync(int id) => await _baseRepository.ExistAsync(id);
        public async Task<TEntity> InsertAsync(TEntity entity) => await _baseRepository.InsertAsync(entity);
        public async Task ReloadAsync(TEntity entity) => await _baseRepository.ReloadAsync(entity);
        public async Task<TEntity?> SelectAsync(int id) => await _baseRepository.SelectAsync(id);
        public async Task<IEnumerable<TEntity>> SelectAsync(Func<TEntity, object>? funcToOrderBy = null) => await _baseRepository.SelectAsync();
        public async Task<TEntity?> UpdateAsync(TEntity entity) => await _baseRepository.UpdateAsync(entity);

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool dispose)
        {
            if (dispose)
            {
                _baseRepository.Dispose();
            }
        }
    }
}
