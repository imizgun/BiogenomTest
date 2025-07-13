using BiogenomTest.Core.Abstraction;

namespace BiogenomTest.Core.Domains;

public class NutritionCriterion : IIdentifiable
{
    public Guid Id { get; set; }
    public string CriterionName { get; set; } = string.Empty;
    public float MinimalNormalValue { get; set; }
    public float? MaximalNormalValue { get; set; }
    public float FromCureCourseValue { get; set; }
    public List<NutritionTestResult> Results { get; set; } = null!;

    public NutritionCriterion() { }

    private NutritionCriterion(Guid id, string criterionName, float minimalNormalValue, float maximalNormalValue,
        float fromCureCourseValue)
    {
        Id = id;
        CriterionName = criterionName;
        MinimalNormalValue = minimalNormalValue;
        MaximalNormalValue = maximalNormalValue;
        FromCureCourseValue = fromCureCourseValue;
    }

    public static NutritionCriterion Create(string criterionName, float minimalNormalValue, float maximalNormalValue,
        float fromCureCourseValue)
    {
        return new NutritionCriterion(Guid.NewGuid(), criterionName, minimalNormalValue, maximalNormalValue,
            fromCureCourseValue);
    }
}