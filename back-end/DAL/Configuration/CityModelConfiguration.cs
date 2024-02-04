using DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configuration
{
    public class CityModelConfiguration : IEntityTypeConfiguration<CityModel>
    {
        public void Configure(EntityTypeBuilder<CityModel> entity)
        {
            entity.ToTable("Cities");
            entity.HasKey(e => e.Id).HasName("PRIMARY");
            entity.Property(e => e.Name).IsRequired().HasMaxLength(255);
        }
    }
}
