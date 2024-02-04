using BLL.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Presentation.Controllers;

[ApiController]
[Route("[controller]")]
public class CitizenshipController : ControllerBase
{
    private readonly ICitizenshipService _citizenshipService;

    // Constructor with dependency injection
    public CitizenshipController(ICitizenshipService citizenshipService)
    {
        _citizenshipService = citizenshipService;
    }

    /// <summary>
    /// Gets all citizenship information.
    /// </summary>
    /// <param name="cancellationToken">Cancellation token (optional).</param>
    /// <returns>All citizenship information available.</returns>
    [HttpGet]
    public async Task<IActionResult> GetAllCitizenshipAsync(
        CancellationToken cancellationToken = default
    )
    {
        var result = await _citizenshipService.GetAllCitizenshipAsync(cancellationToken);

        return Ok(result);
    }
}
