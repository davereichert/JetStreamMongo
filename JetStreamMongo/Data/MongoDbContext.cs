
using JetStreamMongo.Interfaces;
using JetStreamMongo.Models;
using MongoDB.Driver;
using System.Diagnostics;


namespace JetStreamMongo.Data
{
    /// <summary>
    /// Context class for MongoDB operations, implementing the IMongoDbContext interface.
    /// </summary>
    public class MongoDbContext : IMongoDbContext
    {
        private readonly IMongoDatabase _database;
        private readonly IConfiguration _configuration;

        /// <summary>
        /// Initializes a new instance of the <see cref="MongoDbContext"/> class.
        /// </summary>
        /// <param name="configuration">The application configuration with database settings.</param>

        public MongoDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
            var client = new MongoClient(_configuration["MongoDB:URL"]);
            _database = client.GetDatabase(_configuration["MongoDB:Database"]);

        }

        /// <summary>
        /// Ensures the database is properly set up, including collection creation and seeding, if necessary.
        /// </summary>
        public void Initialize()
        {
            // Check and create collections, indexes, or seed data as needed
            EnsureDatabaseSetup();
        }

        /// <summary>
        /// Ensures required collections exist and are properly configured.
        /// </summary>
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
        /// <summary>
        /// Gets the service orders collection from the database.
        /// </summary>
        public DataCollection<ServiceAuftrag> ServiceAuftrags => new DataCollection<ServiceAuftrag>(_database, "ServiceAuftrag");

        /// <summary>
        /// Gets the employees collection from the database.
        /// </summary>
        public DataCollection<Mitarbeiter> Mitarbeiters => new DataCollection<Mitarbeiter>(_database, "Mitarbeiter");


        /// <summary>
        /// Seeds the Mitarbeiter collection with initial data if it is empty.
        /// </summary>
        public async Task MitarbeiterSeedAsync()
        {
            
            if (await Mitarbeiters.NotAny())
            {

                var mitarbeiters = new List<Mitarbeiter>
                {
                new Mitarbeiter { Name = "Max Mustermann", Benutzername = "maxmuster1", Passwort = "sicheresPasswort123", Email = "max.mustermann1@example.com", Telefonnummer = "0123456781", Rolle = Role.User },
                new Mitarbeiter { Name = "Julia Schmidt", Benutzername = "juliasch2", Passwort = "sicheresPasswort123", Email = "julia.schmidt2@example.com", Telefonnummer = "0123456782", Rolle = Role.User },
                new Mitarbeiter { Name = "Tobias Müller", Benutzername = "tobiasm3", Passwort = "sicheresPasswort123", Email = "tobias.mueller3@example.com", Telefonnummer = "0123456783", Rolle = Role.User },
                new Mitarbeiter { Name = "Sophia Becker", Benutzername = "sophiab4", Passwort = "sicheresPasswort123", Email = "sophia.becker4@example.com", Telefonnummer = "0123456784", Rolle = Role.User },
                new Mitarbeiter { Name = "Felix Klein", Benutzername = "felixk5", Passwort = "sicheresPasswort123", Email = "felix.klein5@example.com", Telefonnummer = "0123456785", Rolle = Role.User },
                new Mitarbeiter { Name = "Emma Zimmermann", Benutzername = "emmaz6", Passwort = "sicheresPasswort123", Email = "emma.zimmermann6@example.com", Telefonnummer = "0123456786", Rolle = Role.User },
                new Mitarbeiter { Name = "Maximilian Hofmann", Benutzername = "maximilianh7", Passwort = "sicheresPasswort123", Email = "maximilian.hofmann7@example.com", Telefonnummer = "0123456787", Rolle = Role.User },
                new Mitarbeiter { Name = "Anna Schneider", Benutzername = "annas8", Passwort = "sicheresPasswort123", Email = "anna.schneider8@example.com", Telefonnummer = "0123456788", Rolle = Role.User },
                new Mitarbeiter { Name = "Noah Fischer", Benutzername = "noahf9", Passwort = "sicheresPasswort123", Email = "noah.fischer9@example.com", Telefonnummer = "0123456789", Rolle = Role.User },
                new Mitarbeiter { Name = "Mia Wolf", Benutzername = "miaw10", Passwort = "sicheresPasswort123", Email = "mia.wolf10@example.com", Telefonnummer = "0123456790", Rolle = Role.Admin }
                };
                
                foreach (var mitarbeiter in mitarbeiters)
                {
                    await Mitarbeiters.InsertOneAsync(mitarbeiter);
                }

            }
        }


    }

}
