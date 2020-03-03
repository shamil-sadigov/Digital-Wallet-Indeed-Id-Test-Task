using EWallet.Core.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EWallet.Persistence.Configurations
{
    public class OperationConfiguration : IEntityTypeConfiguration<Operation>
    {
        public void Configure(EntityTypeBuilder<Operation> operation)
        {
            operation.HasKey(x => x.Id);

            operation.Property(x => x.Id).ValueGeneratedOnAdd();

            operation.ToTable("Operations");

            operation.Property(x => x.Direction).HasConversion(new EnumToStringConverter<OperationDirection>());

            operation.HasOne(x => x.Account)
                     .WithMany(x => x.Operations)
                     .HasForeignKey(x => x.AccountId)
                     .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
