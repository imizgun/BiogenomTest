using BiogenomTest.Core.Abstraction;
using BiogenomTest.Core.Domains;
using Microsoft.EntityFrameworkCore;

namespace BiogenomTest.DatabaseAccess.Repositories;

public class NutritionTestRepository : BaseRepository<NutritionTest>, INutritionTestRepository {
	public NutritionTestRepository(NutritionDbContext context) : base(context) { }
	
	public async Task<NutritionTest?> GetByUserIdAsync(Guid userId) {
		return await DbSet
			.Include(x => x.Results)
			.FirstOrDefaultAsync(x => x.UserId == userId);
	}

	public override async Task<NutritionTest?> GetByIdAsync(Guid id) {
		return await DbSet
			.Include(x => x.Results)
			.FirstOrDefaultAsync(x => x.Id == id);
	}
}
