using EWallet.Application.Options;
using EWallet.Application.Services;
using EWallet.Core.Services.Persistence;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;

namespace EWallet.Application
{
    public static class DependencyExtension
    {
        public static void AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMemoryCache();


            services.AddHttpClient<ExchangeWebService>(ops 
                => ops.BaseAddress = new Uri("https://api.exchangeratesapi.io"));


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

            services.AddScoped<IUserService, UserService>();
            services.AddHttpContextAccessor();
        }
    }
}
