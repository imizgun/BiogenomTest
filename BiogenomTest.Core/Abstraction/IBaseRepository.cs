namespace BiogenomTest.Core.Abstraction;

public interface IBaseRepository<T> where T : IIdentifiable
{
    Task<T?> GetByIdAsync(Guid id);
    Task<bool> CreateAsync(T entity);
}