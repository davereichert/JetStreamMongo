

using JetStreamMongo.Interfaces;

namespace JetStreamMongo.Services
{
    public class MitarbeiterService
    {
        private readonly IMongoDbContext _dbContext;

        public MitarbeiterService(IMongoDbContext dbContext)
        {

            _dbContext = dbContext;

        }






    }
}
