using Dima.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dima.Api.Data.Mappings
{
    public class TransactionMapping : BaseEntityConfig<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            base.Configure(builder);

            builder.ToTable("Transaction");

            builder.Property(x => x.Title)
               .IsRequired(true)
               .HasColumnType("NVARCHAR")
               .HasMaxLength(80);

            builder.Property(x => x.PaidOrReceivedAt)
               .IsRequired(false)
               .HasColumnType("DATETIME2");

            builder.Property(x => x.Type)
               .IsRequired(true)
               .HasColumnType("SMALLINT");

            builder.Property(x => x.Amount)
               .IsRequired(true)
               .HasColumnType("MONEY");

            builder.Property(x => x.CategoryId)
               .IsRequired(true)
               .HasColumnType("BIGINT");

            builder.Property(x => x.UserId)
               .IsRequired(true)
               .HasColumnType("NVARCHAR")
               .HasMaxLength(160) ;


        }
    }
}
