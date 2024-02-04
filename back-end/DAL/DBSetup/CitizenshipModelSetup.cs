using DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.DBSetup
{
    public class CitizenshipModelSetup : IEntityTypeConfiguration<CitizenshipModel>
    {
        public void Configure(EntityTypeBuilder<CitizenshipModel> entity)
        {
            var citizenships = new List<CitizenshipModel>()
            {
                new() { Id = 1, Name = "Россиянин" },
                new() { Id = 2, Name = "Белорус" },
                new() { Id = 3, Name = "Украинец" },
                new() { Id = 4, Name = "Казах" },
                new() { Id = 5, Name = "Армянин" },
                new() { Id = 6, Name = "Узбек" }
            };

            entity.HasData(citizenships);
        }
    }
}
