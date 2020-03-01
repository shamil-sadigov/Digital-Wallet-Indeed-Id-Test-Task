using EWallet.Core.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EWallet.Persistence.Configurations
{
    public class ScopeConfiguration : IEntityTypeConfiguration<Scope>
    {
        public void Configure(EntityTypeBuilder<Scope> scope)
        {
            scope.HasKey(x => x.Id);

            scope.Property(x => x.Id).ValueGeneratedOnAdd();

            scope.ToTable("Scopes");

            scope.Property(x => x.Name)
                .HasMaxLength(20)
                .IsRequired();
        }
    }
}
