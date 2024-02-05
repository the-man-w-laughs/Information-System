using BLL.Contracts;
using BLL.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Presentation.Controllers;

[ApiController]
[Route("[controller]")]
public class PersonalInfoController : ControllerBase
{
    private readonly IPersonalInfoService _personalInfoService;

    // Constructor with dependency injection
    public PersonalInfoController(IPersonalInfoService personalInfoService)
    {
        _personalInfoService = personalInfoService;
    }

    /// <summary>
    /// Creates personal information.
    /// </summary>
    /// <param name="personalInfoRequestDto">The personal information to create.</param>
    /// <param name="cancellationToken">Cancellation token (optional).</param>
    /// <returns>The result of the creation operation.</returns>
    [HttpPost]
    [ProducesResponseType(typeof(PersonalInfoResponseDto), 200)]
    public async Task<IActionResult> CreatePersonalInfoAsync(
        [FromBody] PersonalInfoRequestDto personalInfoRequestDto,
        CancellationToken cancellationToken = default
    )
    {
        var result = await _personalInfoService.CreatePersonalInfoAsync(
            personalInfoRequestDto,
            cancellationToken
        );

        return Ok(result);
    }

    /// <summary>
    /// Gets personal information by ID.
    /// </summary>
    /// <param name="id">The ID of the personal information to retrieve.</param>
    /// <param name="cancellationToken">Cancellation token (optional).</param>
    /// <returns>The personal information with the specified ID.</returns>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(PersonalInfoResponseDto), 200)]
    public async Task<IActionResult> GetPersonalInfoByIdAsync(
        [FromRoute] int id,
        CancellationToken cancellationToken = default
    )
    {
        var result = await _personalInfoService.GetPersonalInfoByIdAsync(id, cancellationToken);

        return Ok(result);
    }

    /// <summary>
    /// Gets all personal information.
    /// </summary>
    /// <param name="cancellationToken">Cancellation token (optional).</param>
    /// <returns>All personal information available.</returns>
    [HttpGet]
    [ProducesResponseType(typeof(List<PersonalInfoResponseDto>), 200)]
    public async Task<IActionResult> GetAllPersonalInfoAsync(
        CancellationToken cancellationToken = default
    )
    {
        var result = await _personalInfoService.GetAllPersonalInfoAsync(cancellationToken);

        return Ok(result);
    }

    /// <summary>
    /// Updates personal information by ID.
    /// </summary>
    /// <param name="id">The ID of the personal information to update.</param>
    /// <param name="personalInfoRequestDto">The updated personal information.</param>
    /// <param name="cancellationToken">Cancellation token (optional).</param>
    /// <returns>The result of the update operation.</returns>
    [HttpPut("{id}")]
    [ProducesResponseType(typeof(PersonalInfoResponseDto), 200)]
    public async Task<IActionResult> UpdatePersonalInfoByIdAsync(
        [FromRoute] int id,
        [FromBody] PersonalInfoRequestDto personalInfoRequestDto,
        CancellationToken cancellationToken = default
    )
    {
        var result = await _personalInfoService.UpdatePersonalInfoByIdAsync(
            id,
            personalInfoRequestDto,
            cancellationToken
        );

        return Ok(result);
    }

    /// <summary>
    /// Deletes personal information by ID.
    /// </summary>
    /// <param name="id">The ID of the personal information to delete.</param>
    /// <param name="cancellationToken">Cancellation token (optional).</param>
    /// <returns>The result of the deletion operation.</returns>
    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(PersonalInfoResponseDto), 200)]
    public async Task<IActionResult> DeletePersonalInfoByIdAsync(
        [FromRoute] int id,
        CancellationToken cancellationToken = default
    )
    {
        var result = await _personalInfoService.DeletePersonalInfoByIdAsync(id, cancellationToken);

        return Ok(result);
    }
}
