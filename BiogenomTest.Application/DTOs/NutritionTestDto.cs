namespace BiogenomTest.Application.DTOs;

public class NutritionTestDto {
	public Guid Id { get; set; }
	public Guid UserId { get; set; }
	public DateTime CompletedAt { get; set; }

	public List<NutritionTestResultDto> Results { get; set; } = null!;
}