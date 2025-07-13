namespace BiogenomTest.Application.DTOs;

public class NutritionCriterionDto {
	public Guid Id { get; set; }
	public string CriterionName { get; set; } = string.Empty;
	public float MinimalNormalValue { get; set; }
	public float MaximalNormalValue { get; set; }
	public float FromCureCourseValue { get; set; }
}