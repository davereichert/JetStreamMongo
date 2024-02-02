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
        private readonly ServiceAuftragService _service;

        public ServiceAuftragController(ServiceAuftragService service)
        {
            _service = service;
        }

        /// <summary>
        /// Retrieves all service orders.
        /// </summary>
        /// <returns>A list of service orders.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetServiceAuftragResponseDTO>>> GetAll()
        {
            var aufträge = await _service.GetAllAsync();
            return Ok(aufträge);
        }

        /// <summary>
        /// Creates a new service order.
        /// </summary>
        /// <param name="createDto">The service order data to create.</param>
        /// <returns>The created service order.</returns>
        [HttpPost]
        public async Task<ActionResult<GetServiceAuftragResponseDTO>> Create([FromBody] CreateServiceAuftragRequestDTO createDto)
        {
            var aufträge = await _service.CreateAsync(createDto);
            return CreatedAtAction(nameof(GetById), new { id = aufträge.Id }, aufträge); // Use CreatedAtAction for a more RESTful response
        }

        /// <summary>
        /// Retrieves a specific service order by ID.
        /// </summary>
        /// <param name="id">The ID of the service order.</param>
        /// <returns>The service order if found; otherwise, a 404 Not Found.</returns>
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

        /// <summary>
        /// Updates an existing service order.
        /// </summary>
        /// <param name="id">The ID of the service order to update.</param>
        /// <param name="updateDto">The updated service order data.</param>
        /// <returns>An IActionResult indicating the outcome of the operation.</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] UpdateServiceAuftragRequestDTO updateDto)
        {
            try
            {
                await _service.UpdateAsync(id, updateDto);
                return Ok(updateDto); // Consider returning the updated entity instead of the DTO used for update
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        /// <summary>
        /// Deletes a specific service order.
        /// </summary>
        /// <param name="id">The ID of the service order to delete.</param>
        /// <returns>An IActionResult indicating the outcome of the operation.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                await _service.DeleteAsync(id);
                return NoContent(); // NoContent is a more appropriate response for a successful delete operation
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }
    }
}
