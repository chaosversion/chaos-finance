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
    public class TransactionTagConfiguration : IEntityTypeConfiguration<TransactionTag>
    {
        public void Configure(EntityTypeBuilder<TransactionTag> builder)
        {
            
        }
    }
}
