using DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configuration
{
    public class DisabilityModelConfiguration : IEntityTypeConfiguration<DisabilityModel>
    {
        public void Configure(EntityTypeBuilder<DisabilityModel> entity)
        {
            entity.ToTable("Disabilities");
            entity.HasKey(e => e.Id).HasName("PRIMARY");
            entity.Property(e => e.Name).IsRequired().HasMaxLength(255);
        }
    }
}
