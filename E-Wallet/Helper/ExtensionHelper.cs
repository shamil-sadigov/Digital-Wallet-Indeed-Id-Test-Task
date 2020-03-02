using EWallet.Filters;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace EWallet.Helper
{
    public static class HelperExtensions
    {
        public static void AddSwagger(this IServiceCollection services)
        {
            var assemblyName = string.Concat(Assembly.GetExecutingAssembly().GetName().Name, ".xml");
            var pathToAssembly = Path.Combine(AppContext.BaseDirectory, assemblyName);

            services.AddSwaggerGen(ops =>
            {
                ops.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Schoolman - WebAPI",
                    Version = "v1"

                });
                ops.IncludeXmlComments(pathToAssembly);
            });
        }


        public static void AddApplicationFilters(this IServiceCollection services)
        {
            services.AddScoped<ValidateUserRegistration>();
            services.AddScoped<ValidateUserAuthTokenRequest>();
        }

    }
}
