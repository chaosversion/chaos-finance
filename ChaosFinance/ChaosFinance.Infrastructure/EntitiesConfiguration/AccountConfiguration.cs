using ChaosFinance.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChaosFinance.Infrastructure.EntitiesConfiguration
{
    public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.Id)
                .ValueGeneratedOnAdd();

            builder.Property(a => a.UserId)
                .IsRequired();

            builder.Property(a => a.Name)
                .IsRequired()
                .HasMaxLength(255);

            builder.HasIndex(a => new { a.UserId, a.Name })
                .IsUnique();

            builder.Property(a => a.Type)
                .HasConversion<string>() // Grava como texto. Remova se preferir como int
                .IsRequired();

            builder.Property(a => a.CreatedAt)
                .HasDefaultValueSql("NOW()")
                .IsRequired();

            builder.Property(a => a.UpdatedAt)
                .HasDefaultValueSql("NOW()")
                .IsRequired();

            builder.HasIndex(a => new { a.UserId, a.Name })
                .IsUnique();

            builder.HasOne(a => a.User)
                .WithMany(u => u.Accounts)
                .HasForeignKey(a => a.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(a => a.TransactionsAsOrigin)
                .WithOne(t => t.Account)
                .HasForeignKey(t => t.AccountId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(a => a.TransactionsAsDestination)
                .WithOne(t => t.DestinationAccount)
                .HasForeignKey(t => t.DestinationAccountId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
