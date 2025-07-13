using BiogenomTest.Core.Abstraction;

namespace BiogenomTest.Core.Domains;

public class NutritionTestResult : IIdentifiable
{
    public Guid Id { get; set; }
    public Guid NutritionTestId { get; set; }
    public NutritionTest NutritionTest { get; set; } = null!;
    public Guid NutritionCriterionId { get; set; }
    public NutritionCriterion NutritionCriterion { get; set; } = null!;
    public float CurrentValue { get; set; }

    public NutritionTestResult() { }

    private NutritionTestResult(Guid id, Guid nutritionTestId, Guid nutritionCriterionId, float currentValue)
    {
        Id = id;
        NutritionTestId = nutritionTestId;
        NutritionCriterionId = nutritionCriterionId;
        CurrentValue = currentValue;
    }

    public static NutritionTestResult Create(Guid nutritionTestId, Guid nutritionCriterionId, float currentValue)
    {
        return new NutritionTestResult(Guid.NewGuid(), nutritionTestId, nutritionCriterionId, currentValue);
    }
}