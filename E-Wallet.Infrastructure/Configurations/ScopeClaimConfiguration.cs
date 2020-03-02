using EWallet.Core.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EWallet.Persistence.Configurations
{
    public class PermissionClaimConfiguration : IEntityTypeConfiguration<PermissionClaim>
    {
        public void Configure(EntityTypeBuilder<PermissionClaim> PermissionClaim)
        {
            PermissionClaim.HasKey(x => x.Id);

            PermissionClaim.Property(x => x.Id).ValueGeneratedOnAdd();

            PermissionClaim.ToTable("PermissionClaims");

            PermissionClaim.Property(x => x.Name)
                      .HasMaxLength(20)
                      .IsRequired();


            PermissionClaim.HasOne(x => x.Permission)
                      .WithMany(s => s.Claims)
                      .HasForeignKey(x => x.PermissionId)
                      .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
