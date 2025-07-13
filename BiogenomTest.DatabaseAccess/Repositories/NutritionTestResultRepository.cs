using BiogenomTest.Core.Abstraction;
using BiogenomTest.Core.Domains;
using Microsoft.EntityFrameworkCore;

namespace BiogenomTest.DatabaseAccess.Repositories;

public class NutritionTestResultRepository : BaseRepository<NutritionTestResult>, INutritionTestResultRepository
{
    public NutritionTestResultRepository(NutritionDbContext context) : base(context) { }

    public override Task<Guid> CreateAsync(NutritionTestResult entity)
    {
        Context.Attach(entity.NutritionTest);
        Context.Attach(entity.NutritionCriterion);
        return base.CreateAsync(entity);
    }

    public async Task<bool> SetCurrentValueAsync(Guid nutritionTestId, Guid nutritionCriterionId, float newValue)
    {
        var res = await Context.NutritionTestResults
            .Where(x => x.NutritionTestId == nutritionTestId && x.NutritionCriterionId == nutritionCriterionId)
            .ExecuteUpdateAsync(s =>
                s.SetProperty(x => x.CurrentValue, newValue));

        return res > 0;
    }
}