using EWallet.Aplication.Services;
using EWallet.Application.Options;
using EWallet.Application.Services;
using EWallet.Core.Models;
using EWallet.Core.Services.Application;
using EWallet.Core.Services.Persistence;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Linq;
using static EWallet.Core.Models.ApplicationClaims;

namespace EWallet.Application
{
    public static class DependencyExtension
    {
        public static void AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMemoryCache();

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAuthenticationTokenGenerator, AuthenticationTokenGenerator>();
            services.AddScoped<ICurrencyHelper, CurrencyHelper>();
            services.AddScoped<ICurrentUserService, CurrentUserService>();
            services.AddScoped<IPermissionHelper, PermissionHelper>();
            services.AddScoped<IPermissionTokenGenerator, PermissionTokenGenerator>();
            services.AddScoped<IWalletService, WalletService>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<ITokenFactory, TokenFactory>();
            services.AddScoped<IPermissionAbstractFactory, PermissionAbstractFactory>();
            services.AddAuthorizationPolicies();
            services.AddHttpClient<ExchangeWebService>(ops 
                => ops.BaseAddress = new Uri("https://api.exchangeratesapi.io"));


            #region Authentication service

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

            #endregion

            services.AddHttpContextAccessor();
        }



        private static void AddAuthorizationPolicies(this IServiceCollection services)
        {
            services.AddAuthorization(ops =>
            {
                ops.AddPolicy(name: AuthorizationPolicy.Names.AccountCreate,
                   configurePolicy: AuthorizationPolicy.Configurations.AccountCreationOnly());

                ops.AddPolicy(name: AuthorizationPolicy.Names.AccountReplenish,
                   configurePolicy: AuthorizationPolicy.Configurations.AccountReplenish());

                ops.AddPolicy(name: AuthorizationPolicy.Names.AccountWithdraw,
                 configurePolicy: AuthorizationPolicy.Configurations.AccountWithdraw());

                ops.AddPolicy(name: AuthorizationPolicy.Names.TransferBetweenAccounts,
                 configurePolicy: AuthorizationPolicy.Configurations.TransferBetweenAccounts());

                ops.AddPolicy(name: AuthorizationPolicy.Names.ViewWalletStateAndHistory,
                 configurePolicy: AuthorizationPolicy.Configurations.ViewWalletState());

            });
        }
    }
}
