using EWallet.Core.Models.Domain;
using EWallet.Core.Services.Application;
using EWallet.Core.Services.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EWallet.Application.Services
{
    public class PermissionHelper : IPermissionHelper
    {
        private readonly IMemoryCache memoryCache;
        private readonly IRepository<Permission> permissiontRepository;
        private List<Permission> permissions;
        private const string key = "permissions";

        public PermissionHelper(IMemoryCache memoryCache,
                                IRepository<Permission> permissiontRepository)
        {
            this.memoryCache = memoryCache;
            permissiontRepository.OnRepositoryUpdateAsync += OnPermissionListRepositoryUpdate;
            this.permissiontRepository = permissiontRepository;

        }



        public async Task<bool> AreValidAsync(IEnumerable<string> permissionsNames)
        {
            await EnsurePermissionsInitialized();

            var foundPermissions = permissions.Select(x => x.Name).Intersect(permissionsNames);

            if (foundPermissions.Count() == permissions.Count())
                return true;

            return false;
        }



        public async Task<IEnumerable<PermissionClaim>> BuildClaimsAsync(IEnumerable<string> permissionsNames)
        {
            await EnsurePermissionsInitialized();
            var foundPermissions = permissions.Where(x => permissionsNames.Contains(x.Name));
            return foundPermissions.SelectMany(x => x.Claims);
        }




        #region Local methods

        private async Task EnsurePermissionsInitialized()
        {
            if (permissions is null)
                permissions = await memoryCache.GetOrCreateAsync(key,
                    async entry =>
                    {
                        entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5);
                        return await permissiontRepository.Set().ToListAsync();
                    });
        }


        private async Task OnPermissionListRepositoryUpdate(IRepositoryBase<Permission> permissionRepository)
        {
            permissions = await permissionRepository.Set().ToListAsync();
            memoryCache.Remove(key);
            memoryCache.Set(key, permissions, TimeSpan.FromMinutes(5));
        }


        #endregion
    }
}
