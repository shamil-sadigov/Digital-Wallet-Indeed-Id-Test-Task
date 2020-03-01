using EWallet.Core.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EWallet.Persistence.Configurations
{
    public class ScopeClaimConfiguration : IEntityTypeConfiguration<ScopeClaim>
    {
        public void Configure(EntityTypeBuilder<ScopeClaim> scopeClaim)
        {
            scopeClaim.HasKey(x => x.Id);

            scopeClaim.Property(x => x.Id).ValueGeneratedOnAdd();

            scopeClaim.ToTable("ScopeClaims");

            scopeClaim.Property(x => x.Permission)
                      .HasMaxLength(20)
                      .IsRequired();


            scopeClaim.HasOne(x => x.Scope)
                      .WithMany(s => s.Claims)
                      .HasForeignKey(x => x.ScopeId)
                      .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
