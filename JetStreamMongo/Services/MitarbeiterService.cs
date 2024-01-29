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

    
    public async Task<IEnumerable<GetMitarbeiterResponseDTO>> GetAllMitarbeiterAsync()
    {
        var mitarbeiters = await _dbContext.Mitarbeiters.GetAllAsync();
        return _mapper.Map<IEnumerable<GetMitarbeiterResponseDTO>>(mitarbeiters);
    }

    public async Task<GetMitarbeiterResponseDTO?> GetMitarbeiterByIdAsync(string id)
    {
        var mitarbeiters = await _dbContext.Mitarbeiters.GetAllAsync();
        var mitarbeiter = mitarbeiters.FirstOrDefault(m => m.Id == id);
        return _mapper.Map<GetMitarbeiterResponseDTO>(mitarbeiter);
    }


    public async Task<GetMitarbeiterResponseDTO> CreateMitarbeiterAsync(CreateMitarbeiterRequestDTO createDto)
    {
        
        var mitarbeiter = _mapper.Map<Mitarbeiter>(createDto);
        mitarbeiter = await _dbContext.Mitarbeiters.InsertOneAsync(mitarbeiter);
        return _mapper.Map<GetMitarbeiterResponseDTO>(mitarbeiter);
    }

    public async Task<Mitarbeiter> UpdateMitarbeiterAsync(string id, UpdateMitarbeiterRequestDTO mitarbeiterDto)
    {
        var mitarbeiter = _mapper.Map<Mitarbeiter>(mitarbeiterDto);
        mitarbeiter.Id = id; // Sicherstellen, dass die ID korrekt gesetzt ist
        await _dbContext.Mitarbeiters.UpdateAsync(id, mitarbeiter);
        return mitarbeiter; // Rückgabe des aktualisierten Mitarbeiters
    }


    public async Task DeleteMitarbeiterAsync(string id)
    {
        await _dbContext.Mitarbeiters.DeleteAsync(id);
    }






}
