using EWallet.Filters;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

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
                    Title = "E-Wallet- WebAPI",
                    Version = "v1"

                });
                ops.IncludeXmlComments(pathToAssembly);
                ops.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Type = SecuritySchemeType.ApiKey,
                    In = ParameterLocation.Header,
                    Name = "Authorization",
                    Scheme = "Bearer"
                });

                ops.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                     {
                         new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                },
                                    Scheme = "Bearer",
                                    Name = "Bearer",
                                    In = ParameterLocation.Header,
                         }, new List<string>()
                     }
                });
            });
        }


        /// <summary>
        /// Registers all filters in current assembly
        /// </summary>
        /// <param name="services"></param>
        public static void AddApplicationFilters(this IServiceCollection services)
        {
            Assembly.GetExecutingAssembly()
                    .GetExportedTypes()
                    .Where(x => (typeof(ValidationAttributeBase).IsAssignableFrom(x)) && !x.IsAbstract)
                    .ToList()
                    .ForEach(filterType => services.AddScoped(filterType));
        }
    }
}
