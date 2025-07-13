using BiogenomTest.Core.Abstraction;

namespace BiogenomTest.Core.Domains;

public class NutritionTest : IIdentifiable
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public DateTime CompletedAt { get; set; }

    public List<NutritionTestResult> Results { get; set; } = null!;

    public NutritionTest() { }

    private NutritionTest(Guid id, Guid userId, DateTime completedAt)
    {
        Id = id;
        UserId = userId;
        CompletedAt = completedAt;
    }

    public static NutritionTest Create(Guid userId)
    {
        return new NutritionTest(Guid.NewGuid(), userId, DateTime.UtcNow);
    }
}