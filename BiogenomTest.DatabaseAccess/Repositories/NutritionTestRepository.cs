using BiogenomTest.Core.Abstraction;
using BiogenomTest.Core.Domains;
using Microsoft.EntityFrameworkCore;

namespace BiogenomTest.DatabaseAccess.Repositories;

public class NutritionTestRepository : BaseRepository<NutritionTest>, INutritionTestRepository
{
    public NutritionTestRepository(NutritionDbContext context) : base(context) { }

    public async Task<NutritionTest?> GetByUserIdAsync(Guid userId)
    {
        return await DbSet
            .AsNoTracking()
            .Include(x => x.Results)
            .ThenInclude(x => x.NutritionCriterion)
            .FirstOrDefaultAsync(x => x.UserId == userId);
    }

    public override async Task<NutritionTest?> GetByIdAsync(Guid id)
    {
        return await DbSet
            .AsNoTracking()
            .Include(x => x.Results)
            .ThenInclude(x => x.NutritionCriterion)
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<bool> ExistsWithUserIdAsync(Guid userId)
    {
        return await DbSet.AnyAsync(x => x.UserId == userId);
    }
}
