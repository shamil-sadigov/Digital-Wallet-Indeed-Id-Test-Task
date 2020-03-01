using EWallet.Core.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EWallet.Persistence.Configurations
{
    public class CurrencyConfiguration : IEntityTypeConfiguration<Currency>
    {
        public void Configure(EntityTypeBuilder<Currency> currency)
        {
            currency.HasKey(x => x.IsoNumberCode ); // natural key

            currency.Property(x => x.IsoNumberCode).ValueGeneratedNever();

            currency.ToTable("Currencies");

            currency.Property(x => x.IsoAlfaCode)
                    .HasMaxLength(3)
                    .IsRequired();
        }
    }
}
