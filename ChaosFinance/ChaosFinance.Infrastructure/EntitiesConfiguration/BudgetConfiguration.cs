using ChaosFinance.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChaosFinance.Infrastructure.Persistence.Configurations
{
    public class BudgetConfiguration : IEntityTypeConfiguration<Budget>
    {
        public void Configure(EntityTypeBuilder<Budget> builder)
        {
            builder.HasKey(b => b.Id);

            builder.Property(t => t.Amount)
                .HasPrecision(12, 2)
                .IsRequired();

            builder.Property(b => b.Month)
                .IsRequired();

            builder.Property(b => b.Year)
                .IsRequired();

            builder.Property(b => b.CreatedAt)
                .IsRequired();

            builder.Property(b => b.UpdatedAt)
                .IsRequired();

            builder.HasOne(b => b.User)
                .WithMany(u => u.Budgets)
                .HasForeignKey(b => b.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(b => b.Category)
                .WithMany(c => c.Budgets)
                .HasForeignKey(b => b.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);

            // Restrição de unicidade (usuário + categoria + ano + mês)
            builder.HasIndex(b => new { b.UserId, b.CategoryId, b.Year, b.Month })
                .IsUnique();
        }
    }
}
