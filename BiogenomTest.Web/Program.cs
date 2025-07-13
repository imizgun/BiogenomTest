using BiogenomTest.Application.Services;
using BiogenomTest.Core.Abstraction;
using BiogenomTest.Core.Domains;
using BiogenomTest.DatabaseAccess;
using BiogenomTest.DatabaseAccess.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BiogenomTest.Web;

internal class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        
        builder.Services.AddAutoMapper(cfg => cfg.AddProfile<MapperProfile>());

        builder.Services.AddDbContext<NutritionDbContext>(options =>
        {
            options.UseNpgsql(builder.Configuration.GetConnectionString(nameof(NutritionDbContext)));   
        });

        builder.Services.AddScoped<INutritionTestRepository, NutritionTestRepository>();
        builder.Services.AddScoped<IBaseRepository<NutritionCriterion>, NutritionCriterionRepository>();
        builder.Services.AddScoped<INutritionTestResultRepository, NutritionTestResultRepository>();
        builder.Services.AddScoped<NutritionTestService>();
        
        builder.Services.AddControllers();

        var app = builder.Build();
        
        app.MapControllers();

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