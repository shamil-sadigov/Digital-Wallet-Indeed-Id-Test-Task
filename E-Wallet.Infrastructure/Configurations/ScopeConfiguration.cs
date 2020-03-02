using EWallet.Core.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EWallet.Persistence.Configurations
{
    public class PermissionConfiguration : IEntityTypeConfiguration<Permission>
    {
        public void Configure(EntityTypeBuilder<Permission> Permission)
        {
            Permission.HasKey(x => x.Id);

            Permission.Property(x => x.Id).ValueGeneratedOnAdd();

            Permission.ToTable("Permissions");

            Permission.Property(x => x.Name)
                .HasMaxLength(20)
                .IsRequired();
        }
    }
}
