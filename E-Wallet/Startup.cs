using EWallet.Application;
using EWallet.Application.Validators;
using EWallet.Core.Models.DTO;
using EWallet.Filters;
using EWallet.Helper;
using EWallet.Persistence;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace EWallet
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSwagger();
            services.AddApplicationServices(Configuration);
            services.AddCoreServices();
            services.AddPersistenceServices();
            services.AddApplicationFilters();

            services.AddControllers()
                    .AddFluentValidation(ops =>
                    {
                        ops.RegisterValidatorsFromAssemblyContaining<UserRegistrationValidator>();
                        ops.ImplicitlyValidateChildProperties = false;
                        ops.RunDefaultMvcValidationAfterFluentValidationExecutes = false;
                        ops.LocalizationEnabled = false;
                    });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();
            
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.RoutePrefix = string.Empty;
            });


            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
                endpoints.MapControllers());
        }
    }
}
