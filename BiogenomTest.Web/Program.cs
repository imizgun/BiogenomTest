using BiogenomTest.Core.Abstraction;
using BiogenomTest.Core.Domains;
using BiogenomTest.DatabaseAccess.Repositories;

namespace BiogenomTest.Web;

internal class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddScoped<INutritionTestRepository, NutritionTestRepository>();
        builder.Services.AddScoped<IBaseRepository<NutritionCriterion>, NutritionCriterionRepository>();
        builder.Services.AddScoped<IBaseRepository<NutritionTestResult>, NutritionTestResultRepository>();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.Run();
    }
}