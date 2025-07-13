using BiogenomTest.Core.Domains;

namespace BiogenomTest.Core.Abstraction;

public interface INutritionTestResultRepository : IBaseRepository<NutritionTestResult>
{
    Task<bool> SetCurrentValueAsync(Guid nutritionTestId, Guid nutritionCriterionId, float newValue);
}