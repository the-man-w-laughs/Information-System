using BLL.Contracts;
using BLL.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Presentation.Controllers;

[ApiController]
[Route("[controller]")]
public class CityController : ControllerBase
{
    private readonly ICityService _cityService;

    // Constructor with dependency injection
    public CityController(ICityService cityService)
    {
        _cityService = cityService;
    }

    /// <summary>
    /// Retrieves a list of all cities.
    /// </summary>
    /// <param name="cancellationToken">Cancellation token (optional).</param>
    /// <returns>An IActionResult containing the list of all cities.</returns>
    [HttpGet]
    [ProducesResponseType(typeof(List<CityResponseDto>), 200)]
    public async Task<IActionResult> GetAllCityAsync(CancellationToken cancellationToken = default)
    {
        var result = await _cityService.GetAllCityAsync(cancellationToken);

        return Ok(result);
    }
}
