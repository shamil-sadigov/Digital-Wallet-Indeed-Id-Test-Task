using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;

namespace EWallet.Application.Options
{
    public class JwtOptions
    {
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string SecretKey { get; set; }
        public TimeSpan ExpirationTime { get; set; }

        public static explicit operator TokenValidationParameters(JwtOptions ops)
        {
            return new TokenValidationParameters()
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(ops.SecretKey)),
                ValidIssuer = ops.Issuer,
                ValidAudience = ops.Audience,
                ValidateIssuer = true,
                ValidateAudience = true,
                RequireExpirationTime = true,
                ValidateLifetime = false,
                ClockSkew = TimeSpan.Zero
            };
        }

        public byte[] GetSecretBytes()
            => Encoding.UTF8.GetBytes(SecretKey);
    }
}
