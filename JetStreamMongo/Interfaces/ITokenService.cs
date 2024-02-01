using JetStreamMongo.Models;

namespace JetStreamMongo.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(Mitarbeiter mitarbeiter);
    }
}