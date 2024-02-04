using BLL.Contracts;
using BLL.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Presentation.Controllers;

[ApiController]
[Route("[controller]")]
public class MaritalStatusController : ControllerBase
{
    private readonly IMaritalStatusService _maritalStatusService;

    // Constructor with dependency injection
    public MaritalStatusController(IMaritalStatusService maritalStatusService)
    {
        _maritalStatusService = maritalStatusService;
    }

    /// <summary>
    /// Retrieves a list of all marital statuses.
    /// </summary>
    /// <param name="cancellationToken">Cancellation token (optional).</param>
    /// <returns>An IActionResult containing the list of all marital statuses.</returns>
    [HttpGet]
    [ProducesResponseType(typeof(List<MaritalStatusResponseDto>), 200)]
    public async Task<IActionResult> GetAllMaritalStatusAsync(
        CancellationToken cancellationToken = default
    )
    {
        var result = await _maritalStatusService.GetAllMaritalStatusAsync(cancellationToken);

        return Ok(result);
    }
}
