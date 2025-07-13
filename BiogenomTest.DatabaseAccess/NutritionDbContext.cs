using BiogenomTest.Core.Domains;
using BiogenomTest.DatabaseAccess.Configurations;
using Microsoft.EntityFrameworkCore;

namespace BiogenomTest.DatabaseAccess;

public class NutritionDbContext : DbContext
{
    public NutritionDbContext(DbContextOptions<NutritionDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new NutritionCriterionConfiguration());
        modelBuilder.ApplyConfiguration(new NutritionTestResultConfiguration());
        modelBuilder.ApplyConfiguration(new NutritionTestConfiguration());
    }

    public DbSet<NutritionTest> NutritionTests { get; set; }
    public DbSet<NutritionCriterion> NutritionCriteria { get; set; }
    public DbSet<NutritionTestResult> NutritionTestResults { get; set; }
}