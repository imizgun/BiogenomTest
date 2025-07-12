using BiogenomTest.Core.Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BiogenomTest.DatabaseAccess.Configurations;

public class NutritionCriterionConfiguration : IEntityTypeConfiguration<NutritionCriterion> {
	public void Configure(EntityTypeBuilder<NutritionCriterion> builder) {
		builder.HasKey(x => x.Id);
		builder.Property(x => x.CriterionName).IsRequired();
		builder.Property(x => x.MinimalNormalValue).IsRequired();
		builder.Property(x => x.MaximalNormalValue).IsRequired(false);
		builder.Property(x => x.FromCureCourseValue).IsRequired();
	}
}