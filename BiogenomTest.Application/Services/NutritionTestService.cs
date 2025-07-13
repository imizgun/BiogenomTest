using AutoMapper;
using BiogenomTest.Application.DTOs;
using BiogenomTest.Core.Abstraction;
using BiogenomTest.Core.Domains;

namespace BiogenomTest.Application.Services;

public class NutritionTestService
{
    private readonly INutritionTestRepository _nutritionTestRepository;
    private readonly INutritionTestResultRepository _nutritionTestResultRepository;
    private readonly IBaseRepository<NutritionCriterion> _nutritionCriterionRepository;
    private readonly IMapper _mapper;

    public NutritionTestService(
        INutritionTestRepository nutritionTestRepository,
        INutritionTestResultRepository nutritionTestResultRepository,
        IBaseRepository<NutritionCriterion> nutritionCriterionRepository,
        IMapper mapper)
    {
        _nutritionTestRepository = nutritionTestRepository;
        _nutritionTestResultRepository = nutritionTestResultRepository;
        _nutritionCriterionRepository = nutritionCriterionRepository;
        _mapper = mapper;
    }

    public async Task<Guid> SaveTestData(Guid userId, List<TestResultDto> testResults)
    {
        var test = await _nutritionTestRepository.GetByUserIdAsync(userId);

        if (test is not null)
        {
            foreach (var x in testResults)
            {
                await _nutritionTestResultRepository
                    .SetCurrentValueAsync(test.Id, x.CriterionId, x.CurrentValue);
            }
        }
        else
        {
            test = NutritionTest.Create(userId);
            test.Id = await _nutritionTestRepository.CreateAsync(test);
        
            foreach (var res in testResults)
            {
                var criterion = await _nutritionCriterionRepository.GetByIdAsync(res.CriterionId);
                if (criterion is null)
                {
                    throw new ArgumentException($"Criterion with ID {res.CriterionId} not found.");
                }
                var result = NutritionTestResult.Create(test.Id, criterion.Id, res.CurrentValue);
                result.NutritionCriterion = criterion;
                result.NutritionTest = test;
                await _nutritionTestResultRepository.CreateAsync(result);
            }
        }
        return test.Id;
    }


    public async Task<NutritionTestDto?> GetTestByUserIdAsync(Guid userId)
    {
        var res = await _nutritionTestRepository.GetByUserIdAsync(userId);

        if (res is null) return null;
        
        var response = _mapper.Map<NutritionTestDto>(res);

        foreach (var result in response.Results) {
            result.IsInDeficit = result.CurrentValue < result.NutritionCriterion.MinimalNormalValue;
            result.IsInExcess = result.CurrentValue > result.NutritionCriterion.MaximalNormalValue;
        }

        return response;
    }
}