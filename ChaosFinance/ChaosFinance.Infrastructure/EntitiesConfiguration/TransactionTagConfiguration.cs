using ChaosFinance.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChaosFinance.Infrastructure.Persistence.Configurations
{
    public class TransactionTagConfiguration : IEntityTypeConfiguration<TransactionTag>
    {
        public void Configure(EntityTypeBuilder<TransactionTag> builder)
        {
            builder.HasKey(tt => new { tt.TransactionId, tt.TagId });

            builder.HasOne(tt => tt.Transaction)
                .WithMany(t => t.TransactionTags)
                .HasForeignKey(tt => tt.TransactionId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(tt => tt.Tag)
                .WithMany(t => t.TransactionTags)
                .HasForeignKey(tt => tt.TagId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
