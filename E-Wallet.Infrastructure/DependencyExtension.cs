using EWallet.Application.Services;
using EWallet.Core.Models.Domain;
using EWallet.Core.Services.Persistence;
using EWallet.Persistence.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace EWallet.Persistence
{
    public static class DependencyExtension
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            services.AddIdentityCore<User>(ops =>
            {
                ops.User.RequireUniqueEmail = true;
                ops.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(3);
                ops.Lockout.MaxFailedAccessAttempts = 4;
            })
            .AddEntityFrameworkStores<ApplicationContext>();

            services.AddDbContext<ApplicationContext>(ops =>
                ops.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=TestDb222;Integrated Security=True;"));
                //ops.UseSqlite("Data Source=application-database.db"));


            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(IObservableRepository<>), typeof(Repository<>));
            services.AddHostedService<DataSeederService>();
        }
    }
}
