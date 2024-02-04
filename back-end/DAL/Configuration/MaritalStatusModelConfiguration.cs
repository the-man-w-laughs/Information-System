using DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configuration
{
    public class MaritalStatusModelConfiguration : IEntityTypeConfiguration<MaritalStatusModel>
    {
        public void Configure(EntityTypeBuilder<MaritalStatusModel> entity)
        {
            entity.ToTable("MaritalStatuses");
            entity.HasKey(e => e.Id).HasName("PRIMARY");
            entity.Property(e => e.Name).IsRequired().HasMaxLength(255);
        }
    }
}
