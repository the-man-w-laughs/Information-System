using BLL.Contracts;
using BLL.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Presentation.Controllers;

[ApiController]
[Route("[controller]")]
public class PersonalInfoController : ControllerBase
{
    private readonly IPersonalInfoService _personalInfoService;

    public PersonalInfoController(IPersonalInfoService personalInfoService)
    {
        _personalInfoService = personalInfoService;
    }

    [HttpPost]
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

    [HttpGet(":id")]
    public async Task<IActionResult> GetPersonalInfoByIdAsync(
        [FromQuery] int id,
        CancellationToken cancellationToken = default
    )
    {
        var result = await _personalInfoService.GetPersonalInfoByIdAsync(id, cancellationToken);

        return Ok(result);
    }

    [HttpGet(":id")]
    public async Task<IActionResult> GetAllPersonalInfoAsync(
        CancellationToken cancellationToken = default
    )
    {
        var result = await _personalInfoService.GetAllPersonalInfoAsync(cancellationToken);

        return Ok(result);
    }

    [HttpPut(":id")]
    public async Task<IActionResult> UpdatePersonalInfoByIdAsync(
        [FromQuery] int id,
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

    [HttpDelete(":id")]
    public async Task<IActionResult> DeletePersonalInfoByIdAsync(
        [FromQuery] int id,
        CancellationToken cancellationToken = default
    )
    {
        var result = await _personalInfoService.DeletePersonalInfoByIdAsync(id, cancellationToken);

        return Ok(result);
    }
}
