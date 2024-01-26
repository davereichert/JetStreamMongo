using JetStreamMongo.Data;
using JetStreamMongo.Models;

namespace JetStreamMongo.Interfaces

{
    public interface IMongoDbContext
    {
        DataCollection<Mitarbeiter> Mitarbeiters { get; }
        DataCollection<ServiceAuftrag> ServiceAuftrags { get; }

        void Initialize();
        Task MitarbeiterSeedAsync();
    }
}