namespace BiogenomTest.Application.DTOs;

public class NutritionTestResultDto {
	public Guid Id { get; set; }
	public Guid NutritionTestId { get; set; }
	public Guid NutritionCriterionId { get; set; }
	public NutritionCriterionDto NutritionCriterion { get; set; } = null!;
	public float CurrentValue { get; set; }
	public bool IsInDeficit { get; set; }
	public bool IsInExcess { get; set; }
}