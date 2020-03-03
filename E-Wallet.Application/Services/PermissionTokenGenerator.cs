using EWallet.Application.Options;
using EWallet.Core.Models.Domain;
using EWallet.Core.Services.Application;
using EWallet.Core.Services.Persistence;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace EWallet.Application.Services
{
    public class PermissionTokenGenerator : IPermissionTokenGenerator
    {
        private readonly IPermissionHelper permissionHelper;
        private readonly ICurrentUserService currentUserService;
        private readonly JwtOptions jwtOptions;

        public PermissionTokenGenerator(IPermissionHelper permissionHelper,
                                       ICurrentUserService currentUserService,
                                       IOptionsMonitor<JwtOptions> jwtOptionsMonitor)
        {
            this.permissionHelper = permissionHelper;
            this.currentUserService = currentUserService;
            this.jwtOptions = jwtOptionsMonitor.CurrentValue;
        }


        public async Task<string> GenerateTokenAsync(IEnumerable<string> permissionNames)
        {
            IEnumerable<PermissionClaim> permissionClaims = await permissionHelper.BuildClaimsAsync(permissionNames.Select(x => x.Trim()).Distinct());

            List<Claim> tokenClaims = new AuthTokenClaimsBuilder(user: await currentUserService.GetCurrentUserAsync())
                                     .Build()
                                     .ToList();

            tokenClaims.AddRange(permissionClaims.Select(x => (Claim)x)); // explicit conversion operator

            var tokenDesciptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(tokenClaims),
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