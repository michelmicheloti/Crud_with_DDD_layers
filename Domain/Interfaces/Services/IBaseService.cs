namespace Domain.Interfaces.Services
{
    public interface IBaseService<T> : IDisposable where T : class
    {

        Task<bool> DeleteAsync(int id);
        Task<bool> ExistAsync(int id);
        Task<T> InsertAsync(T entity);
        Task ReloadAsync(T entity);
        Task<T?> SelectAsync(int id);
        Task<IEnumerable<T>> SelectAsync(Func<T, object>? funcToOrderBy);
        Task<T?> UpdateAsync(T entity);
    }
}
