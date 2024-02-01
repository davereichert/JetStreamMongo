using AutoMapper;
using JetStreamMongo.DTOs.Respons;
using JetStreamMongo.Interfaces;
using JetStreamMongo.DTOs.Request;
using JetStreamMongo.Models;
using MongoDB.Driver;
using MongoDB.Bson;


public class MitarbeiterService
{
    private readonly IMongoDbContext _dbContext;
    private readonly IMapper _mapper;

    public MitarbeiterService(IMongoDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<IEnumerable<GetMitarbeiterResponseDTO>> GetAllAsync()
    {
        var entities = await _dbContext.Mitarbeiters.GetAllAsync();
        return _mapper.Map<IEnumerable<GetMitarbeiterResponseDTO>>(entities);
    }

    public async Task<GetMitarbeiterResponseDTO?> GetByIdAsync(ObjectId id)
    {
        var entities = await _dbContext.Mitarbeiters.GetAllAsync();
        var entity = entities.FirstOrDefault(e => e.Id == id);
        return _mapper.Map<GetMitarbeiterResponseDTO>(entity);
    }

    public async Task<GetMitarbeiterResponseDTO> CreateAsync(CreateMitarbeiterRequestDTO createDto)
    {
        var entity = _mapper.Map<Mitarbeiter>(createDto);
        entity = await _dbContext.Mitarbeiters.InsertOneAsync(entity);
        return _mapper.Map<GetMitarbeiterResponseDTO>(entity);
    }

    public async Task<Mitarbeiter> UpdateAsync(string id, UpdateMitarbeiterRequestDTO updateDto)
    {
        // Laden des bestehenden ServiceAuftrag-Objekts aus der Datenbank
        var entity = await _dbContext.Mitarbeiters.GetByIdAsync(id);
        if (entity == null)
        {
            // Handle nicht vorhandenen ServiceAuftrag
            throw new KeyNotFoundException($"ServiceAuftrag with ID '{id}' not found.");
        }

        // Mappen des DTO auf das bestehende Objekt
        _mapper.Map(updateDto, entity);

        // Aktualisieren des Objekts in der Datenbank
        await _dbContext.Mitarbeiters.UpdateAsync(id, entity);
        return entity; // Return updated entity
    }

    public async Task DeleteAsync(string id)
    {
        await _dbContext.Mitarbeiters.DeleteAsync(id);
    }

    public async Task<bool> LoginAsync(MitarbeiterLoginRequestDTO loginDto)
    {
        var mitarbeiter = await _dbContext.Mitarbeiters.FindOneAsync(m => m.Benutzername == loginDto.Benutzername);
        if (mitarbeiter == null)
        {
            // Benutzername nicht gefunden
            return false;
        }

        // Passwortüberprüfung (sollte in der Praxis gehasht und gesalzen werden)
        return mitarbeiter.Passwort == loginDto.Passwort;
    }

    public async Task<Mitarbeiter> GetMitarbeiterByBenutzername(string benutzername)
    {
        // Annahme, dass _dbContext.Mitarbeiters eine Methode FindOneAsync oder eine ähnliche Methode bietet
        // Diese Methode muss entsprechend Ihrer Datenbankabstraktion angepasst werden
        var mitarbeiter = await _dbContext.Mitarbeiters.FindOneAsync(m => m.Benutzername == benutzername);
        return mitarbeiter;
    }
}

