using Dima.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dima.Api.Data.Mappings
{
    public class TransactionMapping : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.ToTable("Transaction");
            builder.HasKey(t => t.Id);

            builder.Property(x => x.CreationDate)
                .IsRequired(true)
                .HasColumnType("DATETIME2");

            builder.Property(x => x.UpdateDate)
               .IsRequired(false)
               .HasColumnType("DATETIME2");

            builder.Property(x => x.Active)
               .IsRequired(true)
               .HasColumnType("BOOLEAN");

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
               .HasColumnType("LONG");

            builder.Property(x => x.UserId)
               .IsRequired(true)
               .HasColumnType("NVARCHAR")
               .HasMaxLength(160) ;


        }
    }
}
