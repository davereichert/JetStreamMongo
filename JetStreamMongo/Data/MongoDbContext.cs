
using JetStreamMongo.Interfaces;
using JetStreamMongo.Models;
using MongoDB.Driver;
using System.Diagnostics;


namespace JetStreamMongo.Data
{
    public class MongoDbContext : IMongoDbContext
    {
        private readonly IMongoDatabase _database;
        private readonly IConfiguration _configuration;

        public MongoDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
            var client = new MongoClient(_configuration["MongoDB:URL"]);
            _database = client.GetDatabase(_configuration["MongoDB:Database"]);

        }

        public void Initialize()
        {
            // Check and create collections, indexes, or seed data as needed
            EnsureDatabaseSetup();
        }

        private void EnsureDatabaseSetup()
        {
            // Example: Create collections if they don't exist
            var requiredCollections = new List<string> { "ServiceAuftrag", "Mitarbeiter" };
            var existingCollections = _database.ListCollectionNames().ToList();

            foreach (var collectionName in requiredCollections)
            {
                if (!existingCollections.Contains(collectionName))
                {
                    _database.CreateCollection(collectionName);
                    // Additional setup like indexing or seeding can go here
                }
            }

            // Additional database-wide setup tasks can be performed here
        }

        // Properties to access collections
        public DataCollection<ServiceAuftrag> ServiceAuftrags => new DataCollection<ServiceAuftrag>(_database, "ServiceAuftrag");

        public DataCollection<Mitarbeiter> Mitarbeiters => new DataCollection<Mitarbeiter>(_database, "Mitarbeiter");


        public async Task MitarbeiterSeedAsync()
        {
            Debug.WriteLine(Mitarbeiters,"bommmmmmm");
            if (await Mitarbeiters.NotAny())
            {

                var mitarbeiters = new List<Mitarbeiter>
            {
                new Mitarbeiter { Name = "Max Mustermann", Benutzername = "maxmuster1", Passwort = "sicheresPasswort123", Email = "max.mustermann1@example.com", Telefonnummer = "0123456781", Rolle = "Administrator" },
                new Mitarbeiter { Name = "Julia Schmidt", Benutzername = "juliasch2", Passwort = "sicheresPasswort123", Email = "julia.schmidt2@example.com", Telefonnummer = "0123456782", Rolle = "Mitarbeiter" },
                new Mitarbeiter { Name = "Tobias Müller", Benutzername = "tobiasm3", Passwort = "sicheresPasswort123", Email = "tobias.mueller3@example.com", Telefonnummer = "0123456783", Rolle = "Mitarbeiter" },
                new Mitarbeiter { Name = "Sophia Becker", Benutzername = "sophiab4", Passwort = "sicheresPasswort123", Email = "sophia.becker4@example.com", Telefonnummer = "0123456784", Rolle = "Mitarbeiter" },
                new Mitarbeiter { Name = "Felix Klein", Benutzername = "felixk5", Passwort = "sicheresPasswort123", Email = "felix.klein5@example.com", Telefonnummer = "0123456785", Rolle = "Mitarbeiter" },
                new Mitarbeiter { Name = "Emma Zimmermann", Benutzername = "emmaz6", Passwort = "sicheresPasswort123", Email = "emma.zimmermann6@example.com", Telefonnummer = "0123456786", Rolle = "Mitarbeiter" },
                new Mitarbeiter { Name = "Maximilian Hofmann", Benutzername = "maximilianh7", Passwort = "sicheresPasswort123", Email = "maximilian.hofmann7@example.com", Telefonnummer = "0123456787", Rolle = "Mitarbeiter" },
                new Mitarbeiter { Name = "Anna Schneider", Benutzername = "annas8", Passwort = "sicheresPasswort123", Email = "anna.schneider8@example.com", Telefonnummer = "0123456788", Rolle = "Mitarbeiter" },
                new Mitarbeiter { Name = "Noah Fischer", Benutzername = "noahf9", Passwort = "sicheresPasswort123", Email = "noah.fischer9@example.com", Telefonnummer = "0123456789", Rolle = "Mitarbeiter" },
                new Mitarbeiter { Name = "Mia Wolf", Benutzername = "miaw10", Passwort = "sicheresPasswort123", Email = "mia.wolf10@example.com", Telefonnummer = "0123456790", Rolle = "Mitarbeiter" }
            };
                
                foreach (var mitarbeiter in mitarbeiters)
                {
                    await Mitarbeiters.InsertOneAsync(mitarbeiter);
                }

            }
        }


    }

}
