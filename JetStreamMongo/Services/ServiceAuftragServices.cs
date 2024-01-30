using AutoMapper;
using JetStreamMongo.DTOs.Request;
using JetStreamMongo.DTOs.Respons;
using JetStreamMongo.Interfaces;
using JetStreamMongo.Models;

namespace JetStreamMongo.Services
{
    public class ServiceAuftragService
    {
        private readonly IMongoDbContext _dbContext;
        private readonly IMapper _mapper;

        public ServiceAuftragService(IMongoDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetServiceAuftragResponseDTO>> GetAllAsync()
        {
            var entities = await _dbContext.ServiceAuftrags.GetAllAsync();
            return _mapper.Map<IEnumerable<GetServiceAuftragResponseDTO>>(entities);
        }

        public async Task<GetServiceAuftragResponseDTO?> GetByIdAsync(string id)
        {
            var entities = await _dbContext.ServiceAuftrags.GetAllAsync();
            var entity = entities.FirstOrDefault(e => e.Id == id);
            return _mapper.Map<GetServiceAuftragResponseDTO>(entity);
        }

        public async Task<GetServiceAuftragResponseDTO> CreateAsync(CreateServiceAuftragRequestDTO createDto)
        {
            var entity = _mapper.Map<ServiceAuftrag>(createDto);
            entity = await _dbContext.ServiceAuftrags.InsertOneAsync(entity);
            return _mapper.Map<GetServiceAuftragResponseDTO>(entity);
        }

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


        public async Task DeleteAsync(string id)
        {
            await _dbContext.ServiceAuftrags.DeleteAsync(id);
        }
    }

}
