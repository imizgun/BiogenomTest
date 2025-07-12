using BiogenomTest.Core.Abstraction;

namespace BiogenomTest.Core.Domains;

public class NutritionCriterion : IIdentifiable
{
    public Guid Id { get; set; }
    public string CriterionName { get; set; } = string.Empty;
    public float MinimalNormalValue { get; set; }
    public float MaximalNormalValue { get; set; }
    public float FromCureCourseValue { get; set; }
    public List<NutritionTestResult> Results { get; set; } = null!;
}