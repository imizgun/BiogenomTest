using BiogenomTest.Core.Abstraction;
using Microsoft.EntityFrameworkCore;

namespace BiogenomTest.DatabaseAccess.Repositories;

public class BaseRepository<T> : IBaseRepository<T> 
	where T: class, IIdentifiable
{
	protected NutritionDbContext Context;
	protected DbSet<T> DbSet;

	public BaseRepository(NutritionDbContext context) {
		Context = context ?? throw new ArgumentNullException(nameof(context));
		DbSet = context.Set<T>();
	}
	
	public virtual async Task<T?> GetByIdAsync(Guid id) {
		return await DbSet.FirstOrDefaultAsync(x => x.Id == id);
	}
	
	public virtual async Task<bool> CreateAsync(T entity) {
		await DbSet.AddAsync(entity);
		return await Context.SaveChangesAsync() > 0;
	}
}