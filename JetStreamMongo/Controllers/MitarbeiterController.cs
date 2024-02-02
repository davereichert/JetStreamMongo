using Microsoft.AspNetCore.Mvc;
using JetStreamMongo.DTOs.Request;
using JetStreamMongo.Interfaces;
using MongoDB.Bson;
using Microsoft.AspNetCore.Authorization;
using JetStreamMongo.Models;
using JetStreamMongo.DTOs.Respons;

[Route("api/[controller]")]
[ApiController]
public class MitarbeiterController : ControllerBase
{
    private readonly MitarbeiterService _mitarbeiterService;
    private readonly ITokenService _tokenService;

    public MitarbeiterController(MitarbeiterService mitarbeiterService, ITokenService tokenService)
    {
        _mitarbeiterService = mitarbeiterService;
        _tokenService = tokenService;
    }

    /// <summary>
    /// Retrieves all Mitarbeiter records.
    /// </summary>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<GetMitarbeiterResponseDTO>>> GetAll()
    {
        var mitarbeiterDtos = await _mitarbeiterService.GetAllAsync();
        return Ok(mitarbeiterDtos);
    }

    /// <summary>
    /// Creates a new Mitarbeiter record.
    /// </summary>
    /// <remarks>
    /// Requires Admin role.
    /// </remarks>
    [HttpPost]
    [Authorize(Roles = nameof(Role.Admin))]
    public async Task<ActionResult<CreateMitarbeiterRequestDTO>> CreateMitarbeiter([FromBody] CreateMitarbeiterRequestDTO createDto)
    {
        var mitarbeiterDtos = await _mitarbeiterService.CreateAsync(createDto);
        return Ok(mitarbeiterDtos);
    }

    /// <summary>
    /// Retrieves a specific Mitarbeiter by ID.
    /// </summary>
    [HttpGet("{id}")]
    [Authorize] // Authorization required, but role not specified.
    public async Task<ActionResult<GetMitarbeiterResponseDTO>> GetById(string id)
    {
        var mitarbeiter = await _mitarbeiterService.GetByIdAsync(ObjectId.Parse(id));
        if (mitarbeiter == null)
        {
            return NotFound();
        }
        return Ok(mitarbeiter);
    }

    /// <summary>
    /// Updates a specific Mitarbeiter record.
    /// </summary>
    /// <remarks>
    /// Requires Admin role.
    /// </remarks>
    [HttpPut("{id}")]
    [Authorize(Roles = nameof(Role.Admin))]
    public async Task<IActionResult> Update(string id, [FromBody] UpdateMitarbeiterRequestDTO mitarbeiterDto)
    {
        await _mitarbeiterService.UpdateAsync(id, mitarbeiterDto);
        return Ok(mitarbeiterDto);
    }

    /// <summary>
    /// Deletes a specific Mitarbeiter record.
    /// </summary>
    /// <remarks>
    /// Requires Admin role.
    /// </remarks>
    [HttpDelete("{id}")]
    [Authorize(Roles = nameof(Role.Admin))]
    public async Task<IActionResult> Delete(string id)
    {
        await _mitarbeiterService.DeleteAsync(id);
        var responseDto = new DeleteResponse_DTO { Id = id }; // Correct DTO class name if necessary
        return Ok(responseDto);
    }

    /// <summary>
    /// Authenticates a Mitarbeiter and returns a JWT token.
    /// </summary>
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] MitarbeiterLoginRequestDTO loginRequest)
    {
        var result = await _mitarbeiterService.LoginAsync(loginRequest);
        if (result)
        {
            var mitarbeiter = await _mitarbeiterService.GetMitarbeiterByBenutzername(loginRequest.Benutzername);
            if (mitarbeiter == null)
            {
                return Unauthorized("Benutzer nicht gefunden.");
            }
            var token = _tokenService.CreateToken(mitarbeiter);
            return Ok(new { token = token });
        }
        else
        {
            return Unauthorized("Ungültige Anmeldeinformationen.");
        }
    }
}
