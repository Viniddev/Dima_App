using Dima.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dima.Api.Data.Mappings
{
    public class CategoryMapping : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Category");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.CreationDate)
                .IsRequired(true)
                .HasColumnType("DATETIME2");

            builder.Property(x => x.UpdateDate)
               .IsRequired(false)
               .HasColumnType("DATETIME2");

            builder.Property(x => x.Active)
               .IsRequired(true)
               .HasColumnType("BOOLEAN");

            builder.Property(x=>x.Title)
                .IsRequired(true)
                .HasColumnType("NVARCHAR")
                .HasMaxLength(80);

            builder.Property(x=>x.Description)
                .IsRequired(false)
                .HasColumnType("NVARCHAR")
                .HasMaxLength(80);

            builder.Property(x=>x.UserId)
                .IsRequired(true)
                .HasColumnType("VARCHAR")
                .HasMaxLength(160);
        }
    }
}
