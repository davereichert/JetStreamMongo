using Microsoft.AspNetCore.Mvc;
using JetStreamMongo.DTOs.Respons;
using System.Collections.Generic;
using System.Threading.Tasks;
using JetStreamMongo.DTOs.Request;
using JetStreamMongo.Interfaces;

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

    [HttpGet]
    public async Task<ActionResult<IEnumerable<GetMitarbeiterResponseDTO>>> GetAll()
    {
        var mitarbeiterDtos = await _mitarbeiterService.GetAllAsync();
        return Ok(mitarbeiterDtos);
    }

    [HttpPost]
    public async Task<ActionResult<CreateMitarbeiterRequestDTO>> CreateMitarbeiter([FromBody] CreateMitarbeiterRequestDTO createDto)
    {
        var mitarbeiterDtos = await _mitarbeiterService.CreateAsync(createDto);
        return Ok(mitarbeiterDtos);
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<GetMitarbeiterResponseDTO>> GetById(string id)
    {
        var mitarbeiter = await _mitarbeiterService.GetByIdAsync(id);
        if (mitarbeiter == null)
        {
            return NotFound();
        }
        return Ok(mitarbeiter);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(string id, [FromBody] UpdateMitarbeiterRequestDTO mitarbeiterDto)
    {
        await _mitarbeiterService.UpdateAsync(id, mitarbeiterDto);
        return Ok(mitarbeiterDto);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        await _mitarbeiterService.DeleteAsync(id);

        var responseDto = new DeleteResponse_DTO { Id = id };
        return Ok(responseDto);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] MitarbeiterLoginRequestDTO loginRequest)
    {
        var result = await _mitarbeiterService.LoginAsync(loginRequest);

        if (result)
        {
            return Ok("Login erfolgreich");
        }
        else
        {
            return Unauthorized("Ungültige Anmeldeinformationen");
        }
    }

}

