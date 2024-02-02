using AutoMapper;
using JetStreamMongo.DTOs.Request;
using JetStreamMongo.DTOs.Respons;
using JetStreamMongo.Interfaces;
using JetStreamMongo.Models;

namespace JetStreamMongo.Services
{
    /// <summary>
    /// Service layer for handling CRUD operations for ServiceAuftrag entities.
    /// </summary>
    public class ServiceAuftragService
    {
        private readonly IMongoDbContext _dbContext;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the ServiceAuftragService with specified database context and AutoMapper.
        /// </summary>
        public ServiceAuftragService(IMongoDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        /// <summary>
        /// Retrieves all service orders as DTOs.
        /// </summary>
        /// <returns>A collection of GetServiceAuftragResponseDTO.</returns>

        public async Task<IEnumerable<GetServiceAuftragResponseDTO>> GetAllAsync()
        {
            var entities = await _dbContext.ServiceAuftrags.GetAllAsync();
            return _mapper.Map<IEnumerable<GetServiceAuftragResponseDTO>>(entities);
        }

        /// <summary>
        /// Retrieves a single service order by ID.
        /// </summary>
        /// <param name="id">The ID of the service order to find.</param>
        /// <returns>A GetServiceAuftragResponseDTO or null if not found.</returns>

        public async Task<GetServiceAuftragResponseDTO?> GetByIdAsync(string id)
        {
            var entities = await _dbContext.ServiceAuftrags.GetAllAsync();
            var entity = entities.FirstOrDefault(e => e.Id == id);
            return _mapper.Map<GetServiceAuftragResponseDTO>(entity);
        }

        /// <summary>
        /// Creates a new service order from a DTO.
        /// </summary>
        /// <param name="createDto">The DTO to create a new service order from.</param>
        /// <returns>The created GetServiceAuftragResponseDTO.</returns>

        public async Task<GetServiceAuftragResponseDTO> CreateAsync(CreateServiceAuftragRequestDTO createDto)
        {
            var entity = _mapper.Map<ServiceAuftrag>(createDto);
            entity = await _dbContext.ServiceAuftrags.InsertOneAsync(entity);
            return _mapper.Map<GetServiceAuftragResponseDTO>(entity);
        }

        /// <summary>
        /// Updates an existing service order by ID with data from a DTO.
        /// </summary>
        /// <param name="id">The ID of the service order to update.</param>
        /// <param name="updateDto">The DTO containing update data.</param>
        /// <returns>The updated ServiceAuftrag entity.</returns>

        public async Task<ServiceAuftrag> UpdateAsync(string id, UpdateServiceAuftragRequestDTO updateDto)
        {
            // Laden des bestehenden ServiceAuftrag-Objekts aus der Datenbank
            var entity = await _dbContext.ServiceAuftrags.GetByIdAsync(id);
            if (entity == null)
            {
                // Handle nicht vorhandenen ServiceAuftrag
                throw new KeyNotFoundException($"ServiceAuftrag with ID '{id}' not found.");
            }

            // Mappen des DTO auf das bestehende Objekt
            _mapper.Map(updateDto, entity);

            // Aktualisieren des Objekts in der Datenbank
            await _dbContext.ServiceAuftrags.UpdateAsync(id, entity);
            return entity; // Return updated entity
        }

        /// <summary>
        /// Deletes a service order by ID.
        /// </summary>
        /// <param name="id">The ID of the service order to delete.</param>


        public async Task DeleteAsync(string id)
        {
            await _dbContext.ServiceAuftrags.DeleteAsync(id);
        }
    }

}
