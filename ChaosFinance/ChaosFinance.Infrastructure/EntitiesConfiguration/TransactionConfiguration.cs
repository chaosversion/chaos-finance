using ChaosFinance.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChaosFinance.Infrastructure.EntitiesConfiguration
{
    public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id)
                .ValueGeneratedOnAdd();

            builder.Property(t => t.UserId)
                .IsRequired();

            builder.Property(t => t.AccountId)
                .IsRequired();

            builder.Property(t => t.Description)
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(t => t.Amount)
                .HasPrecision(12, 2)
                .IsRequired();

            builder.Property(t => t.Date)
            .IsRequired();

            builder.Property(t => t.Type)
                .HasConversion<string>()
                .IsRequired();

            builder.Property(t => t.CreatedAt)
                .HasDefaultValueSql("NOW()")
                .IsRequired();

            builder.Property(t => t.UpdatedAt)
                .HasDefaultValueSql("NOW()")
                .IsRequired();

            builder.Ignore(t => t.CategoryName);
            builder.Ignore(t => t.AccountName);

            builder.HasOne(t => t.User)
                .WithMany(u => u.Transactions)
                .HasForeignKey(t => t.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(t => t.Account)
                .WithMany()
                .HasForeignKey(t => t.AccountId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(t => t.DestinationAccount)
                .WithMany()
                .HasForeignKey(t => t.DestinationAccountId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(t => t.Category)
                .WithMany()
                .HasForeignKey(t => t.CategoryId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(t => t.TransactionTags)
                .WithOne(tt => tt.Transaction)
                .HasForeignKey(tt => tt.TransactionId);
        }
    }
}
