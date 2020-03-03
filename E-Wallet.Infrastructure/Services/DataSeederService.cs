using EWallet.Core.Models.Domain;
using EWallet.Core.Services.Application;
using EWallet.Persistence.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EWallet.Application.Services
{
    public class DataSeederService : BackgroundService
    {
        private readonly IServiceProvider serviceProvider;

        public DataSeederService(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<ApplicationContext>();
                var permissionFactory = scope.ServiceProvider.GetRequiredService<IPermissionAbstractFactory>();

                context.Database.EnsureCreated();

                if (!context.Currencies.Any())
                {
                    using (var transaction = context.Database.BeginTransaction())
                    {
                        try
                        {
                            context.Currencies.AddRange(new Currency[]
                            {
                                new Currency(Currency.Names.CZK.ISOCodeNum, Currency.Names.CZK.ISOCodeAlfa),
                                new Currency(Currency.Names.JPY.ISOCodeNum, Currency.Names.JPY.ISOCodeAlfa),
                                new Currency(Currency.Names.MXN.ISOCodeNum, Currency.Names.MXN.ISOCodeAlfa),
                                new Currency(Currency.Names.NZD.ISOCodeNum, Currency.Names.NZD.ISOCodeAlfa),
                                new Currency(Currency.Names.RUB.ISOCodeNum, Currency.Names.RUB.ISOCodeAlfa),
                                new Currency(Currency.Names.THB.ISOCodeNum, Currency.Names.THB.ISOCodeAlfa),
                                new Currency(Currency.Names.USD.ISOCodeNum, Currency.Names.USD.ISOCodeAlfa),
                            });

                            context.SaveChanges();

                            if (!context.Permissions.Any())
                            {
                                context.Permissions.AddRange(new Permission[]
                                {
                                    permissionFactory.ForAccountCreate(),
                                    permissionFactory.ForAccountReplenish(),
                                    permissionFactory.ForAccountTransfer(),
                                    permissionFactory.ForAccountWithdraw(),
                                    permissionFactory.ForFullPermission(),
                                    permissionFactory.ForWalletState(),
                                 });

                            }

                            context.SaveChanges();
                            transaction.Commit();
                        }
                        catch (Exception)
                        {
                            transaction.Rollback();
                            throw;
                        }
                    }
                }

                return Task.CompletedTask;
            }
        }
    }
}