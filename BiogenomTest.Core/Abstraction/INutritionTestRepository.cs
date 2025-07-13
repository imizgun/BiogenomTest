using BiogenomTest.Core.Domains;

namespace BiogenomTest.Core.Abstraction;

public interface INutritionTestRepository : IBaseRepository<NutritionTest>
{
    Task<NutritionTest?> GetByUserIdAsync(Guid userId);
    Task<bool> ExistsWithUserIdAsync(Guid userId);
}