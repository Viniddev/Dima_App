using Dima.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dima.Api.Data.Mappings
{
    public abstract class BaseEntityConfig<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : BaseEntity
    {
        public void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnOrder(0);

            builder.Property(x => x.CreationDate)
                .IsRequired(true)
                .HasColumnType("DATETIME2")
                .HasColumnOrder(1);

            builder.Property(x => x.UpdateDate)
               .IsRequired(false)
               .HasColumnType("DATETIME2")
               .HasColumnOrder(2);

            builder.Property(x => x.Active)
               .IsRequired(true)
               .HasColumnType("BIT")
               .HasColumnOrder(3);
        }
    }
}
