using BiogenomTest.Core.Abstraction;

namespace BiogenomTest.Core.Domains;

public class NutritionTest : IIdentifiable
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public DateTime CompletedAt { get; set; }

    public List<NutritionTestResult> Results { get; set; } = null!;
}