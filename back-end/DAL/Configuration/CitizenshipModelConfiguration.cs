using DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configuration
{
    public class CitizenshipModelConfiguration : IEntityTypeConfiguration<CitizenshipModel>
    {
        public void Configure(EntityTypeBuilder<CitizenshipModel> entity)
        {
            entity.ToTable("Citizenships");
            entity.HasKey(e => e.Id).HasName("PRIMARY");
            entity.Property(e => e.Name).IsRequired().HasMaxLength(255);
        }
    }
}
