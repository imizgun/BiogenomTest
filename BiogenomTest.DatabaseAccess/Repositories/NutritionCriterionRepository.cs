using BiogenomTest.Core.Domains;

namespace BiogenomTest.DatabaseAccess.Repositories;

public class NutritionCriterionRepository : BaseRepository<NutritionCriterion>
{
    public NutritionCriterionRepository(NutritionDbContext context) : base(context) { }
}