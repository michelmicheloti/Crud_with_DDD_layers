namespace Domain.Interfaces
{
    public interface IBaseRepository<T> : IDisposable where T : class
    {
        Task<bool> DeleteAsync(int id);
        Task<bool> ExistAsync(int id);
        Task<T> InsertAsync(T entity);
        Task ReloadAsync(T entity);
        Task<T?> SelectAsync(int id);
        Task<IEnumerable<T>> SelectAsync(Func<T, object>? funcToOrderBy = null);
        Task<T?> UpdateAsync(T entity);
    }
}
