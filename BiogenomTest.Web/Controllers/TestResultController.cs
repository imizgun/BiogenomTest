using BiogenomTest.Application.DTOs;
using BiogenomTest.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace BiogenomTest.Web.Controllers;

[ApiController]
[Route("api/nutrition_tests")]
public class TestResultController : ControllerBase {
	private readonly NutritionTestService _nutritionTestService;

	public TestResultController(NutritionTestService nutritionTestService) {
		_nutritionTestService = nutritionTestService;
	}

	[HttpGet("{userId:guid}")]
	public async Task<ActionResult<NutritionTestDto>> GetTestByUserIdAsync(Guid userId) {
		var test = await _nutritionTestService.GetTestByUserIdAsync(userId);
		if (test is null) {
			return NotFound();
		}

		return Ok(test);
	}
	
	[HttpPost("{userId:guid}")]
	public async Task<IActionResult> SaveTestDataAsync(Guid userId, [FromBody] List<TestResultDto> testResults) {
		var testId = await _nutritionTestService.SaveTestData(userId, testResults);
		
		return testId == Guid.Empty ? Conflict() : Ok(new {message = "Test data saved successfully. Test ID: " + testId});
	}
}