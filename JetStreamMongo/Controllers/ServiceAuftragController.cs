using JetStreamMongo.DTOs.Request;
using JetStreamMongo.DTOs.Respons;
using JetStreamMongo.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JetStreamMongo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceAuftragController : ControllerBase
    {
        public readonly ServiceAuftragService _service;

        public ServiceAuftragController(ServiceAuftragService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetServiceAuftragResponseDTO>>> GetAll()
        {
            var aufträge = await _service.GetAllAsync();
            return Ok(aufträge);
        }

        [HttpPost]
        public async Task<ActionResult<GetServiceAuftragResponseDTO>> Create([FromBody] CreateServiceAuftragRequestDTO createDto)
        {
            var aufträge = await _service.CreateAsync(createDto);
            return Ok(aufträge);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetServiceAuftragResponseDTO>> GetById(string id)
        {
            var aufträge = await _service.GetByIdAsync(id);
            if (aufträge == null)
            {
                return NotFound();
            }
            return Ok(aufträge);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] UpdateServiceAuftragRequestDTO updateDto)
        {
            var service = await _service.UpdateAsync(id, updateDto);
            return service == null ? NotFound(): Ok(updateDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _service.DeleteAsync(id);
            var responseDto = new DeleteResponse_DTO { Id = id };
            return Ok(responseDto);
        }
    }
}
