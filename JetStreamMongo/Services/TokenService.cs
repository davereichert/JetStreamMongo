
    using System;
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;
    using System.Text;
    using Microsoft.IdentityModel.Tokens;
    using JetStreamMongo.Models; // Stellen Sie sicher, dass Sie Ihren Namespace entsprechend anpassen
    using JetStreamMongo.Interfaces;

 namespace JetStreamMongo.Services
{

    /// <summary>
    /// Provides JWT token generation functionality for authenticated users.
    /// </summary>
    
    public class TokenService : ITokenService
    {
        private readonly SymmetricSecurityKey _key;

        /// <summary>
        /// Initializes the TokenService with a symmetric security key from configuration.
        /// </summary>
        /// <param name="config">Application configuration containing JWT key.</param>

        public TokenService(IConfiguration config)
        {
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]));
        }

        /// <summary>
        /// Creates a JWT token for an authenticated Mitarbeiter.
        /// </summary>
        /// <param name="mitarbeiter">The authenticated Mitarbeiter for whom the token is created.</param>
        /// <returns>A JWT token string.</returns>

        public string CreateToken(Mitarbeiter mitarbeiter)
        {
            //Creating Claims. You can add more information in these claims. For example email id.
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.NameId, mitarbeiter.Benutzername),
                new Claim(ClaimTypes.Role, mitarbeiter.Rolle.ToString())
            };

            //Creating credentials. Specifying which type of Security Algorithm we are using
            var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);

            //Creating Token description
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            //Finally returning the created token
            return tokenHandler.WriteToken(token);
        }
    }
}

