using EWallet.Core.Services.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EWallet.Persistence.Services
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T :class
    {
        private readonly ApplicationContext context;

        public RepositoryBase(ApplicationContext ctx)
            =>context = ctx;
        
        public DbSet<T> Set()
            => context.Set<T>();
        
        public event Func<IRepository<T>, Task> OnRepositoryUpdateAsync;

        public async Task SaveChangesAsync()
        {
            await context.SaveChangesAsync();
            await OnRepositoryUpdateAsync(this);
        }
    }
}
