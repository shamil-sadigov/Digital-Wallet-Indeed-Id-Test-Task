using EWallet.Core.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EWallet.Persistence.Configurations
{
    public class WalletConfiguration : IEntityTypeConfiguration<Wallet>
    {
        public void Configure(EntityTypeBuilder<Wallet> wallet)
        {
            wallet.HasKey(x => x.Id);

            wallet.Property(x => x.Id).ValueGeneratedOnAdd();

            wallet.ToTable("Wallets");

            wallet.HasOne(x => x.User)
                  .WithOne(u => u.Wallet)
                  .HasForeignKey<Wallet>(x => x.UserId)
                  .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
