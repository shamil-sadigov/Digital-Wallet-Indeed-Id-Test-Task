using EWallet.Core.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EWallet.Persistence.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> user)
        {
            user.ToTable("Users");

            user.Property(x => x.LastName)
                .HasMaxLength(50)
                .IsRequired();

            user.Property(x => x.LastName)
                .HasMaxLength(50)
                .IsRequired();


            user.Property(x => x.Email)
                .IsRequired();

        }
    }
}
