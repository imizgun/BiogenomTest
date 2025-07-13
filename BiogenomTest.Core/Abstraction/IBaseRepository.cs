namespace BiogenomTest.Core.Abstraction;

public interface IBaseRepository<T> where T : IIdentifiable
{
    Task<T?> GetByIdAsync(Guid id);
    Task<Guid> CreateAsync(T entity);
    Task<bool> ExistsAsync(Guid id);
}