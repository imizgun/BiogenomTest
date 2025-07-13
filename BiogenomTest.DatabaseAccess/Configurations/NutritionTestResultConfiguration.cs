using BiogenomTest.Core.Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BiogenomTest.DatabaseAccess.Configurations;

public class NutritionTestResultConfiguration : IEntityTypeConfiguration<NutritionTestResult>
{
    public void Configure(EntityTypeBuilder<NutritionTestResult> builder)
    {
        builder.HasKey(nutritionTestResult => nutritionTestResult.Id);
        builder.Property(x => x.CurrentValue).IsRequired();
        builder.Property(x => x.NutritionCriterionId).IsRequired();
        builder.Property(x => x.NutritionTestId).IsRequired();

        builder.HasOne(x => x.NutritionCriterion)
            .WithMany(x => x.Results)
            .HasForeignKey(x => x.NutritionCriterionId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.NutritionTest)
            .WithMany(x => x.Results)
            .HasForeignKey(x => x.NutritionTestId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}