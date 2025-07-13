using AutoMapper;
using BiogenomTest.Application.DTOs;
using BiogenomTest.Core.Domains;

namespace BiogenomTest.Web;

public class MapperProfile : Profile {
	public MapperProfile() {
		CreateMap<NutritionTestResult, NutritionTestResultDto>()
			.PreserveReferences()
			.MaxDepth(5);
		
		CreateMap<NutritionCriterion, NutritionCriterionDto>()
			.PreserveReferences()
			.MaxDepth(5);
		
		CreateMap<NutritionTest, NutritionTestDto>()
			.PreserveReferences()
			.MaxDepth(5);
	}
}