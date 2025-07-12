using BiogenomTest.Core.Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BiogenomTest.DatabaseAccess.Configurations;

public class NutritionTestConfiguration : IEntityTypeConfiguration<NutritionTest> {
	public void Configure(EntityTypeBuilder<NutritionTest> builder) {
		builder.HasKey(x => x.Id);
		builder.Property(x => x.UserId).IsRequired();
		builder.Property(x => x.CompletedAt).IsRequired();
	}
}