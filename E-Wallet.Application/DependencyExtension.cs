using EWallet.Application.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace EWallet.Application
{
    public static class DependencyExtension
    {
        public static void AddAuthenticationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<JwtOptions>(ops =>
            configuration.GetSection(nameof(JwtOptions)).Bind(ops));


            JwtOptions jwtOptions = configuration.GetSection(nameof(JwtOptions)).Get<JwtOptions>();

            services.AddAuthentication(ops =>
            {
                ops.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                ops.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                ops.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
              .AddJwtBearer(ops =>
              {
                  ops.SaveToken = true;           // explicit operator
                  ops.TokenValidationParameters = (TokenValidationParameters)jwtOptions;
              });


        }
    }
}
