using DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.DBSetup
{
    public class MaritalStatusModelSetup : IEntityTypeConfiguration<MaritalStatusModel>
    {
        public void Configure(EntityTypeBuilder<MaritalStatusModel> entity)
        {
            var maritalStatuses = new List<MaritalStatusModel>()
            {
                new() { Id = 1, Name = "Холост/Не замужем" },
                new() { Id = 2, Name = "В браке" },
                new() { Id = 3, Name = "Разведен(а)" },
                new() { Id = 4, Name = "Вдовец/Вдова" }
            };
            entity.HasData(maritalStatuses);
        }
    }
}
