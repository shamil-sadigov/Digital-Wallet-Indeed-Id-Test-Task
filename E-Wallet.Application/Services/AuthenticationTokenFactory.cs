using EWallet.Application.Options;
using EWallet.Core.Models.Domain;
using EWallet.Core.Services.Persistence;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace EWallet.Application.Services
{
    public class AuthenticationTokenFactory : IAuthenticationTokenFactory
    {
        private readonly JwtOptions jwtOptions;

        public AuthenticationTokenFactory(IOptionsMonitor<JwtOptions> jwtOptions)
        {
            this.jwtOptions = jwtOptions.CurrentValue;

        }

        public string GenerateToken(User user)
        {
            if (user is null)
                throw new ArgumentNullException(nameof(user));

            Claim[] claims = new AuthTokenClaimsBuilder(user).Build();
            
            var tokenDesciptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.Add(jwtOptions.ExpirationTime),
                Audience = jwtOptions.Audience,
                Issuer = jwtOptions.Issuer,
                SigningCredentials = new SigningCredentials(key: new SymmetricSecurityKey(jwtOptions.GetSecretBytes()),
                                                            algorithm: SecurityAlgorithms.HmacSha256)
            };

            var jwtTokenHandler = new JwtSecurityTokenHandler();

            SecurityToken securityToken = jwtTokenHandler.CreateToken(tokenDesciptor);

            string accessToken = jwtTokenHandler.WriteToken(securityToken);

            return accessToken;
        }
    }
}
