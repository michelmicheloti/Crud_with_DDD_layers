using Microsoft.EntityFrameworkCore;
using Domain.Entity;
using Domain.Interfaces;
using Data.Context;

namespace Data.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected readonly DataContext _context;
        private readonly DbSet<T> _dataset;
        public BaseRepository(DataContext context)
        {
            _context = context;
            _dataset = _context.Set<T>();
        }

        public async Task<bool> ExistAsync(int id) => await _dataset.AsNoTracking().AnyAsync(p => p.Id.Equals(id));
        public async Task<T> InsertAsync(T entity)
        {
            try
            {
                _dataset.Add(entity);

                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }

            return entity;
        }
        public async Task ReloadAsync(T entity) => await _context.Entry(entity).ReloadAsync();
        public async Task<T?> SelectAsync(int id)
        {
            try
            {
                return await _dataset.AsNoTracking().FirstOrDefaultAsync(p => p.Id.Equals(id));
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<IEnumerable<T>> SelectAsync(Func<T, object>? funcToOrderBy = null)
        {
            try
            {
                return funcToOrderBy != null
                    ? _dataset.AsNoTracking().OrderBy(funcToOrderBy).ToList()
                    : await _dataset.AsNoTracking().ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<T?> UpdateAsync(T entity)
        {
            try
            {
                T? result = await _dataset.SingleOrDefaultAsync(p => p.Id.Equals(entity.Id));

                if (result == null) { return null; }

                _context.Entry(result).CurrentValues.SetValues(entity);
                await _context.SaveChangesAsync();

            }
            catch (Exception)
            {
                throw;
            }

            return entity;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                T? result = await _dataset.SingleOrDefaultAsync(p => p.Id.Equals(id));
                if (result == null)
                {
                    return false;
                }

                _dataset.Remove(result);
                await _context.SaveChangesAsync();
                return true;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async void Dispose()
        {
            await Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual async Task Dispose(bool dispose)
        {
            if (dispose)
            {
                await _context.DisposeAsync();
            }
        }
    }
}
