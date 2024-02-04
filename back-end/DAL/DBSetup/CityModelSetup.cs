using DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.DBSetup
{
    public class CityModelSetup : IEntityTypeConfiguration<CityModel>
    {
        public void Configure(EntityTypeBuilder<CityModel> entity)
        {
            var cities = new List<CityModel>()
            {
                new() { Id = 1, Name = "Минск" },
                new() { Id = 2, Name = "Гомель" },
                new() { Id = 3, Name = "Могилёв" },
                new() { Id = 4, Name = "Витебск" },
                new() { Id = 5, Name = "Брест" },
                new() { Id = 6, Name = "Гродно" }
            };

            entity.HasData(cities);
        }
    }
}
