using BLL.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Presentation.Controllers;

[ApiController]
[Route("[controller]")]
public class DisabilityController : ControllerBase
{
    private readonly IDisabilityService _disabilityService;

    // Constructor with dependency injection
    public DisabilityController(IDisabilityService disabilityService)
    {
        _disabilityService = disabilityService;
    }

    /// <summary>
    /// Retrieves a list of all disabilities.
    /// </summary>
    /// <param name="cancellationToken">Cancellation token (optional).</param>
    /// <returns>An IActionResult containing the list of all disabilities.</returns>
    [HttpGet]
    public async Task<IActionResult> GetAllDisabilityAsync(
        CancellationToken cancellationToken = default
    )
    {
        var result = await _disabilityService.GetAllDisabilityAsync(cancellationToken);

        return Ok(result);
    }
}
