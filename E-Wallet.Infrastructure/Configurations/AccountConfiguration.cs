using EWallet.Core.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EWallet.Persistence.Configurations
{
    public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> account)
        {
            account.HasKey(x => x.Id);

            account.Property(x => x.Id).ValueGeneratedOnAdd();

            account.ToTable("Accounts");

            account.HasOne(x => x.Wallet)
                   .WithMany(w => w.Accounts)
                   .HasForeignKey(x => x.WalletId)
                   .OnDelete(DeleteBehavior.Restrict);

            account.HasOne(x => x.Currency)
                   .WithMany(c => c.Accounts)
                   //.HasForeignKey(x => x.CurrencyId)
                   .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
