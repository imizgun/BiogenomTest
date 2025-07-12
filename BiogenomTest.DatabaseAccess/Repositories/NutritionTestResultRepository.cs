using BiogenomTest.Core.Domains;

namespace BiogenomTest.DatabaseAccess.Repositories;

public class NutritionTestResultRepository : BaseRepository<NutritionTestResult> {
	public NutritionTestResultRepository(NutritionDbContext context) : base(context) { }
}